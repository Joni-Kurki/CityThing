using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityStatsTrackerScript : MonoBehaviour {

    [SerializeField]
    int numberOfMales;
    [SerializeField]
    int numberOfFemales;
    [SerializeField]
    int numberOfKids;
    [SerializeField]
    int totalNumberOfPeople;
    [SerializeField]
    int numberOfPeopleWhoCanWork;
    [SerializeField]
    int numberOfUnemployed;
    [SerializeField]
    float unemployementRate;
    [SerializeField]
    int numberOfHouses;
    [SerializeField]
    float numberOfPeopleInHouseAvg;


    bool statsCollectingDone = false;

    // Use this for initialization
    void Start () {
		
	}
	
    GameObject [] GetNumberOfWithTag(string tag) {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    public void ReCalculateStats() {
        statsCollectingDone = false;
    }

	// Update is called once per frame
	void Update () {
        if (!statsCollectingDone) {
            var adultMaleGos = GetNumberOfWithTag("People_Adult_Male");
            var adultFemaleGos = GetNumberOfWithTag("People_Adult_Female");
            var kidGos = GetNumberOfWithTag("People_Kid");

            // People Counts
            numberOfMales = adultMaleGos.Length;
            numberOfFemales = adultFemaleGos.Length;
            numberOfKids = kidGos.Length;
            totalNumberOfPeople = numberOfMales + numberOfFemales + numberOfKids;

            // Work stuff
            numberOfPeopleWhoCanWork = numberOfMales + numberOfFemales;

            // Unemployement rate unempl / people * 100
            numberOfUnemployed = 0;
            foreach(GameObject go in adultMaleGos) {
                numberOfUnemployed = go.GetComponent<PeopleControllerScript>()._hasJob == false ? numberOfUnemployed += 1 : numberOfUnemployed;
            }
            foreach (GameObject go in adultFemaleGos) {
                numberOfUnemployed = go.GetComponent<PeopleControllerScript>()._hasJob == false ? numberOfUnemployed += 1 : numberOfUnemployed;
            }
            unemployementRate = (float)(numberOfUnemployed / (numberOfPeopleWhoCanWork) * 100);

            // Living house stuff
            numberOfHouses = GetNumberOfWithTag("LivingHouse").Length;
            numberOfPeopleInHouseAvg = ((float)totalNumberOfPeople / (float)numberOfHouses);

            statsCollectingDone = true;
        }
	}
}
