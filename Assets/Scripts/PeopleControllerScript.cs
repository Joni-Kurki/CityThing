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
    private bool _isBored;
    [SerializeField]
    public float _getsBoredInterval;
    [SerializeField]
    public float _doesSomethingInterval;
    [SerializeField]
    public Enums.People.Sex _sex;
    [SerializeField]
    public Enums.People.Relationship _relationship;
    [SerializeField]
    public Enums.People.Age _age;
    [SerializeField]
    public Material _materialToUse;
    
    private float lastBoredCheck;
    private float lastDoCheck;

    public GameObject radialPulsePrefab;

    // Sets PeopleSO
    public void SetPeopleSO(PeopleSO peopleSO) {
        this.peopleSO = peopleSO;

        _hasJob = peopleSO._hasJob;
        _isBusy = peopleSO._isBusy;
        _isBored = peopleSO._isBored;
        _getsBoredInterval = peopleSO._getsBoredInterval;
        _doesSomethingInterval = peopleSO._doesSomethingInterval;
        _sex = peopleSO._sex;
        _relationship = peopleSO._relationship;
        _age = peopleSO._age;
        _materialToUse = peopleSO._materialToUse;

        MeshRenderer mRenderer = GetComponent<MeshRenderer>();
        mRenderer.material = peopleSO._materialToUse;

        lastBoredCheck = Time.time;
    }

    public void SetBusy(bool value) {
        peopleSO._isBusy = value;
    }

    public void SetJob(bool value) {
        peopleSO._hasJob = value;
    }

    public PeopleControllerScript GetPeopleController() {
        return GetComponent<PeopleControllerScript>();
    }

    void FindSomethingToDo() {
        lastDoCheck = Time.time + _doesSomethingInterval;
        _isBusy = true;
        // Lets look for something to do
        var lookingForSomethingToDo = Instantiate(radialPulsePrefab, transform.position, radialPulsePrefab.transform.rotation, transform);
        lookingForSomethingToDo.GetComponent<RadialPulseScript>().SetEffect(Enums.RadialPulseEffectType.lookingForSomethingToDo, 1, .3f, 100);
    }

	// Update is called once per frame
	void Update () {
        // 
        if (_isBored && !_isBusy && !_hasJob) {
            FindSomethingToDo();
        }
        //
        else if(_isBored && _isBusy && Time.time > lastDoCheck + _doesSomethingInterval) {
            var rng = Random.Range(0f, 1f) > .5f ? true : false;
            if (rng == true) {
                _isBusy = false;
                _isBored = false;
                lastBoredCheck = Time.time + _getsBoredInterval;
            }
        }
        // 
        if (Time.time > lastBoredCheck + _getsBoredInterval && !_isBored) {
            _isBored = Random.Range(0f, 1f) > .5f ? true : false;
            lastBoredCheck = Time.time;
        }
        
    }
}
