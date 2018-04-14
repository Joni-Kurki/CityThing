using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManagerScript : MonoBehaviour {

    public GameObject PowerCreatorPrefab;
    GameObject powerCreatorGo;
    bool powerCreatorSpawned = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // POWER STUFF
        if (powerCreatorGo != null && powerCreatorGo.GetComponent<PowerLineScript>().startSet && powerCreatorGo.GetComponent<PowerLineScript>().endSet && Input.GetMouseButtonDown(0)) {
            powerCreatorGo.GetComponent<PowerLineScript>().SpawnPoles();
        }
        if (Input.GetKeyDown(KeyCode.F1) && !powerCreatorSpawned) {
            powerCreatorGo = Instantiate(PowerCreatorPrefab);
            powerCreatorSpawned = true;
        }
        if (powerCreatorSpawned) {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.rigidbody != null) {
                        if (powerCreatorGo.GetComponent<PowerLineScript>().startSet) {
                            if (!powerCreatorGo.GetComponent<PowerLineScript>().endSet) {
                                powerCreatorGo.GetComponent<PowerLineScript>().SetEnd(hit.transform.gameObject);
                            }
                        } else if (!powerCreatorGo.GetComponent<PowerLineScript>().startSet) {
                            powerCreatorGo.GetComponent<PowerLineScript>().SetStart(hit.transform.gameObject);
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F2)){
            var road = GameObject.FindGameObjectWithTag("Road_Progen").GetComponent<RoadMeshScript>();
            Vector2[] points = new Vector2[6];

            points[0] = new Vector2(-10, -10);
            points[1] = new Vector2(-10, -5);
            points[2] = new Vector2(-5, -5);
            points[3] = new Vector2(-5, -10);
            points[4] = new Vector2(-7.5f, -10);
            points[5] = new Vector2(-7.5f, -7.5f);


            road.SetWayPoints(points);
        }
    }

}
