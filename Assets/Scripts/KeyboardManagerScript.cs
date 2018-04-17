using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManagerScript : MonoBehaviour {

    public GameObject PowerCreatorPrefab;
    GameObject powerCreatorGo;
    bool powerCreatorSpawned = false;
    CityStatsTrackerScript stats;
    bool initDone = false;
    public GameObject radialPulsePrefab;
    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (!initDone) {
            
            if (stats)
                initDone = true;
        }

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

        if (Input.GetKeyDown(KeyCode.F4)) {
            var go = Instantiate(radialPulsePrefab, new Vector3(Random.Range(-5, 6), 0, Random.Range(-5, 6)), radialPulsePrefab.transform.rotation, transform.parent);
            go.GetComponent<RadialPulseScript>().SetEffect(Enums.RadialPulseEffectType.newJob, 5, 0.3f, 20);
        }

        if (Input.GetKeyDown(KeyCode.F5)) {
            stats = GameObject.FindWithTag("StatsTracker").GetComponent<CityStatsTrackerScript>();
            stats.ReCalculateStats();
        }
    }

}
