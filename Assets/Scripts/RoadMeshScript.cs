using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class RoadMeshScript : MonoBehaviour {

    public int xSize;
    public int ySize;

    public Vector2[] roadLocationsWaypoints;
    public List<Vector2> roadTiles;

    private Mesh mesh;
    private Vector3[] verticies;

    // Use this for initialization
    void Start () {
        roadTiles = new List<Vector2>();
        GeneratePath();

        Generate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Generate each tile for waypoint to waypoint
    void GeneratePath() {
        var index = 0;
    
        for (int i = 0; i < roadLocationsWaypoints.Length - 1; i++) {
            if (i == 0) {
                roadTiles.Add(roadLocationsWaypoints[i]);
            }

            var step = CalculateHowManyStepsAreNeeded(roadLocationsWaypoints[i], roadLocationsWaypoints[i + 1]);

            for (var steps = 0; steps < step; steps++) {
                var currentLocation = roadTiles[index];
                currentLocation += GetNextStep(currentLocation, roadLocationsWaypoints[i+1]);
                roadTiles.Add(currentLocation);
                index++;
            }
        }

        VisualizeRoadGizmos();
    }

    int CalculateHowManyStepsAreNeeded(Vector2 start, Vector2 end) {
        var x = 0;
        var y = 0;
        if(start.x > end.x) {
            x = (int)(start.x - end.x);
        }else if (start.x < end.x) {
            x = (int)(end.x - start.x);
        } else {
            x = 0;
        }
        if (start.y > end.y) {
            y = (int)(start.y - end.y);
        } else if (start.y < end.y) {
            y = (int)(end.y - start.y);
        } else {
            y = 0;
        }
        return x + y;
    }

    Vector2 GetNextStep(Vector2 currentLocation, Vector2 endLocation) {
        // Move x first
        if((int)currentLocation.x != (int)endLocation.x) {

            return currentLocation.x > endLocation.x ? Vector2.left : Vector2.right;
        } else if (((int)currentLocation.x == (int)endLocation.x) && ((int)currentLocation.y != (int)endLocation.y)) {

            return currentLocation.y > endLocation.y ? Vector2.down : Vector2.up;
        } else {
            return currentLocation;
        }
    }

    void VisualizeRoadGizmos() {
        for(int i=0; i < roadTiles.Count - 1; i++) {
            Debug.DrawLine(new Vector3(roadTiles[i].x - .25f, 1, roadTiles[i].y - .25f), new Vector3(roadTiles[i + 1].x, 1, roadTiles[i + 1].y), Color.red, 30);
            Debug.DrawLine(new Vector3(roadTiles[i].x + .25f, 1, roadTiles[i].y + .25f), new Vector3(roadTiles[i + 1].x, 1, roadTiles[i + 1].y), Color.red, 30);
        }
    }

    void Generate() {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural grid";

        verticies = new Vector3[(xSize + 1) * (ySize + 1)];
        Vector2[] uv = new Vector2[verticies.Length];

        for (int i = 0, y = 0; y <= ySize; y++) {
            for (int x = 0; x <= xSize; x++, i++) {
                verticies[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
            }
        }

        mesh.vertices = verticies;
        mesh.uv = uv;

        int[] triangles = new int[xSize * ySize * 6];
        // ti = triangleIndex , vi = vertexIndex
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
            for (int x = 0; x < xSize; x++, ti += 6, vi++) {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
        }

        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
