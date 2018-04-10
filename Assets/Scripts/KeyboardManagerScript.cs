using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManagerScript : MonoBehaviour {

    public GameObject PowerCreatorPrefab;
    GameObject powerCreatorGo;
    bool powerCreatorSpawned = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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

        
	}


}
