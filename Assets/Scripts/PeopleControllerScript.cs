using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleControllerScript : MonoBehaviour {

    public PeopleSO peopleSO;

    [SerializeField]
    public bool _hasJob;
    [SerializeField]
    public bool _isBusy;
    [SerializeField]
    public Enums.People.Sex _sex;
    [SerializeField]
    public Enums.People.Relationship _relationship;
    [SerializeField]
    public Enums.People.Age _age;
    [SerializeField]
    public Material _materialToUse;

    // Use this for initialization
    void Start () {
		
	}
	
    // Sets PeopleSO
    public void SetPeopleSO(PeopleSO peopleSO) {
        this.peopleSO = peopleSO;

        _hasJob = peopleSO._hasJob;
        _isBusy = peopleSO._isBusy;
        _sex = peopleSO._sex;
        _relationship = peopleSO._relationship;
        _age = peopleSO._age;
    }

    public void SetBusy(bool value) {
        peopleSO._isBusy = value;
    }

    public void SetJob(bool value) {
        peopleSO._hasJob = value;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
