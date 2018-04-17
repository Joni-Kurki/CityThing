using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingHouseControllerScript : MonoBehaviour {

    public LivingHouseSO houseSO;

    [SerializeField]
    private int adults;
    [SerializeField]
    private int kids;
    [SerializeField]
    private int cars;
    [SerializeField]
    private bool hasElectricity;
    [SerializeField]
    private bool isConnectedByRoad;
    [SerializeField]
    private Material materialToUse;
    [SerializeField]
    private Enums.LivingHouseType livingHouseType;

    public GameObject peoplePrefab;

    public PeopleSO[] soOptions;

    public void Init(LivingHouseSO houseSO) {
        this.houseSO = houseSO;

        adults = houseSO._adults;
        kids = houseSO._kids;
        cars = houseSO._cars;
        hasElectricity = houseSO._hasElectricity;
        isConnectedByRoad = houseSO._isConnectedByRoad;
        materialToUse = houseSO._materialToUse;
        livingHouseType = houseSO._livingHouseType;

        if (hasElectricity) {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        InstantiatePeople();
    }

    void InstantiatePeople() {
        // Instantiate prefabs
        List<GameObject> goList = new List<GameObject>();
        for (int i = 0; i < kids + adults; i++) {
            // TODO Delete 
            Vector3 offset = Vector3.zero;
            if(i == 0) {
                offset = new Vector3(-.25f, -.4f, .25f);
            } else if (i == 1) {
                offset = new Vector3(-.25f, -.4f, -.25f);
            } else if (i == 2) {
                offset = new Vector3(.25f, -.4f, -.25f);
            } else if (i == 3) {
                offset = new Vector3(.25f, -.4f, .25f);
            }
            var go = Instantiate(peoplePrefab, transform.position + Vector3.up + offset, peoplePrefab.transform.rotation, transform);
            goList.Add(go);
        }
        SetPeopleSO(goList);
    }

    void SetPeopleSO(List<GameObject> goList) {
        PeopleControllerScript pcs = goList[0].GetComponent<PeopleControllerScript>();
        switch (livingHouseType) {
        case Enums.LivingHouseType.couple:
                // TODO
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Female.UNEMPLOYED_INRELATIONSHIP]);
                goList[0].name = "People_F_INRela";
                goList[0].tag = Constants.People.Tags.ADULT_FEMALE;
                // TODO
                pcs = goList[1].GetComponent<PeopleControllerScript>();
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Male.UNEMPLOYED_INRELATIONSHIP]);
                goList[1].name = "People_M_INRela";
                goList[1].tag = Constants.People.Tags.ADULT_MALE;
                break;
        case Enums.LivingHouseType.single:
                // TODO
                var rng = Random.Range(0, 2);
                pcs.SetPeopleSO(rng == 0 ? soOptions[Constants.People.DataSOIndecies.Female.UNEMPLOYED_SINGLE] : soOptions[Constants.People.DataSOIndecies.Male.UNEMPLOYED_SINGLE]);
                goList[0].name = "People_Single";
                goList[0].tag = rng == 0 ? Constants.People.Tags.ADULT_FEMALE : Constants.People.Tags.ADULT_MALE;
            break;
        case Enums.LivingHouseType.family:
                // TODO
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Female.UNEMPLOYED_INRELATIONSHIP]);
                goList[0].name = "People_F_INRela";
                goList[0].tag = Constants.People.Tags.ADULT_FEMALE;
                // TODO
                pcs = goList[1].GetComponent<PeopleControllerScript>();
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Male.UNEMPLOYED_INRELATIONSHIP]);
                goList[1].name = "People_M_INRela";
                goList[1].tag = Constants.People.Tags.ADULT_MALE;
                // TODO
                pcs = goList[2].GetComponent<PeopleControllerScript>();
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Kid.KID]);
                goList[2].name = "People_KID";
                goList[2].tag = Constants.People.Tags.KID;
                // TODO
                pcs = goList[3].GetComponent<PeopleControllerScript>();
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Kid.KID]);
                goList[3].name = "People_KID";
                goList[3].tag = Constants.People.Tags.KID;
                break;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetElectricity(bool value) {
        hasElectricity = value;
        if (hasElectricity)
            transform.GetChild(0).gameObject.SetActive(true);
        else
            transform.GetChild(0).gameObject.SetActive(false);
    }
}
