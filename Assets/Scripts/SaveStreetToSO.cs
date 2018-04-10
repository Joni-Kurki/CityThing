using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStreetToSO : MonoBehaviour {

    public List<LivingHouseSO> livingHouseArray;

	// Use this for initialization
	void Start () {
        livingHouseArray = new List<LivingHouseSO>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            var gos = GameObject.FindGameObjectsWithTag("LivingHouse");
            foreach(GameObject go in gos) {
                livingHouseArray.Add(go.GetComponent<LivingHouseControllerScript>().houseSO);
            }
        }
	}
}
