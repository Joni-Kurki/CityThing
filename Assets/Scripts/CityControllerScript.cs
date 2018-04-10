using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityControllerScript : MonoBehaviour {

    public int numberOfLivingHouses;
    public LivingHouseSO [] livingHouseSOs;
    public GameObject livingHousePrefab;
    List<GameObject> livingHouses;

    public bool toggleLights;
    float lastAction = 0;
    float interval = 2;
	// Use this for initialization
	void Start () {
        InstantiateLivingHouses();
        var gos = GameObject.FindGameObjectsWithTag("LivingHouse");

        livingHouses = new List<GameObject>();
        foreach(GameObject go in gos) {
            livingHouses.Add(go);
        }
    }
	
	// Update is called once per frame
	void Update () {
         livingHouses.ForEach((h => h.GetComponent<LivingHouseControllerScript>().SetElectricity(toggleLights)));


	}

    void InstantiateLivingHouses() {
        var rowY = 0;
        var rowX = 0;
        for(int i=0; i<numberOfLivingHouses; i++) {
            if (i % 5 == 0 && i != 0) {
                if (i % 10 == 0)
                    rowY++;
                rowY++;
                rowX = 0;
            }

            var randomSo = Random.Range(0, Constants.LivingHouse.NUMBER_OF_LIVING_HOUSE_SO);

            var go = Instantiate(livingHousePrefab, new Vector3((rowX * 2) - 4, 0 , (rowY * 2) - 4), livingHousePrefab.transform.rotation, transform);
            go.GetComponent<LivingHouseControllerScript>().Init(livingHouseSOs[randomSo]);

            go.GetComponent<MeshRenderer>().material = livingHouseSOs[randomSo]._materialToUse;

            go.name = livingHouseSOs[randomSo]._livingHouseType == Enums.LivingHouseType.couple ? "LivingHouse_Couple" :
                livingHouseSOs[randomSo]._livingHouseType == Enums.LivingHouseType.family ? "LivingHouse_Family" : "LivingHouse_Single";
            rowX++;
        }
    }
}
