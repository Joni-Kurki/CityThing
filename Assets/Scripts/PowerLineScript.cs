using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLineScript : MonoBehaviour {

    public GameObject StartGameObject;
    public bool startSet = false;
    public GameObject EndGameObject;
    public bool endSet = false;

    public GameObject polePrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnPoles() {
        var start = StartGameObject.transform;
        var end = EndGameObject.transform;

        bool startXBigger = false;
        bool startZBigger = false;
        if (startSet && endSet) {
            var x = start.position.x > end.position.x ? start.position.x - end.position.x : end.position.x - start.position.x;
            var z = start.position.z > end.position.z ? start.position.z - end.position.z : end.position.z - start.position.z;

            startXBigger = start.position.x > end.position.x ? true : false;
            startZBigger = start.position.z > end.position.z ? true : false;

            var locations = CreatePoleLocations(x, z, startXBigger, startZBigger, new Vector2(start.position.x, start.position.z), new Vector2(end.position.x, end.position.z));

            for (var i = 0; i < locations.Length; i++) {
                Instantiate(polePrefab, 
                    new Vector3(locations[i].x, 0 , locations[i].y),
                    polePrefab.transform.rotation, 
                    transform.parent);
            }
        }
    }

    Vector2 [] CreatePoleLocations(float x, float z, bool startXBigger, bool startZBigger, Vector2 start, Vector2 end) {
        Vector2[] returnArray = new Vector2[(int)(x + z)];

        for(var i=0; i<x; i++) {
            returnArray[i] = startXBigger ? new Vector2(end.x + i, end.y) : new Vector2(start.x + i, start.y);
        }
        for(var j=0; j<z; j++) {
            returnArray[(int)(x+j)] = startZBigger ? new Vector2(end.x , end.y + j) : new Vector2(start.x, start.y + j);
        }

        return returnArray;
    }

    public void SetStart(GameObject go) {
        StartGameObject = go;
        startSet = true;
    }

    public void SetEnd(GameObject go) {
        EndGameObject = go;
        endSet = true;
    }
}
