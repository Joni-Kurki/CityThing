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
            var go = Instantiate(peoplePrefab, transform.parent.position, peoplePrefab.transform.rotation, transform);
            goList.Add(go);
        }
        SetPeopleSO(goList);
    }

    void SetPeopleSO(List<GameObject> goList) {
        PeopleControllerScript pcs = goList[0].GetComponent<PeopleControllerScript>();
        switch (livingHouseType) {
        case Enums.LivingHouseType.couple:
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Female.UNEMPLOYED_INRELATIONSHIP]);
                // TODO
                pcs._age = Enums.People.Age.adult;
                goList[0].name = "People_F_INRela";
                pcs = goList[1].GetComponent<PeopleControllerScript>();
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Male.UNEMPLOYED_INRELATIONSHIP]);
                // TODO
                pcs._age = Enums.People.Age.adult;
                goList[1].name = "People_M_INRela";
                break;
        case Enums.LivingHouseType.single:
                var rng = Random.Range(0, 1);
                pcs.SetPeopleSO(rng == 0 ? soOptions[Constants.People.DataSOIndecies.Female.UNEMPLOYED_SINGLE] : soOptions[Constants.People.DataSOIndecies.Male.UNEMPLOYED_SINGLE]);
                // TODO
                pcs._age = Enums.People.Age.adult;
                goList[0].name = "People_Single";
            break;
        case Enums.LivingHouseType.family:
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Female.UNEMPLOYED_INRELATIONSHIP]);
                // TODO
                pcs._age = Enums.People.Age.adult;
                goList[0].name = "People_F_INRela";
                pcs = goList[1].GetComponent<PeopleControllerScript>();
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Male.UNEMPLOYED_INRELATIONSHIP]);
                // TODO
                pcs._age = Enums.People.Age.adult;
                goList[1].name = "People_M_INRela";
                pcs = goList[2].GetComponent<PeopleControllerScript>();
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Female.UNEMPLOYED_INRELATIONSHIP]);
                // TODO
                pcs._age = Enums.People.Age.kid;
                goList[2].name = "People_KID";
                pcs = goList[3].GetComponent<PeopleControllerScript>();
                pcs.SetPeopleSO(soOptions[Constants.People.DataSOIndecies.Male.UNEMPLOYED_INRELATIONSHIP]);
                // TODO
                pcs._age = Enums.People.Age.kid;
                goList[3].name = "People_KID";
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
