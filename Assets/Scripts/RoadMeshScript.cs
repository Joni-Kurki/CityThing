using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class RoadMeshScript : MonoBehaviour {

    public Vector2[] roadLocationsWaypoints;
    public List<Vector2> roadTiles;

    private Mesh mesh;
    public Vector3[] verts;
    public int[] tris;

    private Vector2[] uvs;

    public Material mat;

    // Use this for initialization
    void Start () {
        roadTiles = new List<Vector2>();
        GeneratePath();
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

        int numberOfVerts = CalculateVerts(roadTiles.Count);

        verts = GenerateVertsFromWaypoints(numberOfVerts, roadTiles);

        //tris = GenerateTris(roadTiles.Count);

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.vertices = verts;
        mesh.uv = uvs;
        mesh.triangles = tris;

        mesh.RecalculateNormals();
        GetComponent<MeshRenderer>().material = mat;

        //VisualizeRoadWaypoints();
        //VisualizeRoadVerts(verts);
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

    void VisualizeRoadWaypoints() {
        for(int i=0; i < roadTiles.Count - 1; i++) {
            Debug.DrawLine(new Vector3(roadTiles[i].x - .25f, 1, roadTiles[i].y - .25f), new Vector3(roadTiles[i + 1].x, 1, roadTiles[i + 1].y), Color.yellow, 60);
            Debug.DrawLine(new Vector3(roadTiles[i].x + .25f, 1, roadTiles[i].y + .25f), new Vector3(roadTiles[i + 1].x, 1, roadTiles[i + 1].y), Color.yellow, 60);
        }
    }

    void VisualizeRoadVerts(Vector3 [] verts) {
        float visualOffset = 0.1f;

        for (int i = 0; i < verts.Length; i++) {
            Debug.DrawLine(new Vector3(verts[i].x - visualOffset, 1, verts[i].z + visualOffset), 
                new Vector3(verts[i].x + visualOffset, 1, verts[i].z + visualOffset), Color.red, 60);
            Debug.DrawLine(new Vector3(verts[i].x + visualOffset, 1, verts[i].z + visualOffset), 
                new Vector3(verts[i].x + visualOffset, 1, verts[i].z - visualOffset), Color.red, 60);
            Debug.DrawLine(new Vector3(verts[i].x + visualOffset, 1, verts[i].z - visualOffset), 
                new Vector3(verts[i].x - visualOffset, 1, verts[i].z - visualOffset), Color.red, 60);
            Debug.DrawLine(new Vector3(verts[i].x - visualOffset, 1, verts[i].z - visualOffset), 
                new Vector3(verts[i].x - visualOffset, 1, verts[i].z + visualOffset), Color.red, 60);
        }
    }

    int CalculateVerts(int numberOfWaypoints) {
        return numberOfWaypoints * 4;
    }

    int CalculateTris(int numberOfWaypoints) {
        return numberOfWaypoints * 6;
    }

    Vector3[] GenerateVertsFromWaypoints(int numbofverts, List<Vector2> waypoints) {
        Debug.Log("Starting mesh creation. Verts : " + numbofverts + " waypoints: " + waypoints.Count);

        float vertOffSet = .5f;

        Vector2[] uvs = new Vector2[waypoints.Count * 4];

        int v = 0;
        int t = 0;

        verts = new Vector3[waypoints.Count * 4];
        tris = new int[waypoints.Count * 6];

        var index = 0;
        for(int i = 0; i < waypoints.Count; i++) {
            verts[index]    = new Vector3(waypoints[i].x - vertOffSet, 0, waypoints[i].y + vertOffSet);
            verts[index+1]  = new Vector3(waypoints[i].x - vertOffSet, 0, waypoints[i].y - vertOffSet);
            verts[index+2]  = new Vector3(waypoints[i].x + vertOffSet, 0, waypoints[i].y + vertOffSet);
            verts[index+3]  = new Vector3(waypoints[i].x + vertOffSet, 0, waypoints[i].y - vertOffSet);
            //uvs[index] = uvs[index + 1] = uvs[index + 2] = uvs[index + 3] = new Vector2((float)waypoints[i].x, waypoints[i].y);

            tris[t] = index;
            tris[t+1] = tris[t+4] = 2 + index;
            tris[t+2] = tris[t+3] = 1 + index;
            tris[t+5] = 3 + index;

            index += 4;
            t += 6;
        }

        return verts;
    }
}
