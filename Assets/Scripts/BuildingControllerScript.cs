using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingControllerScript : MonoBehaviour {

    public BuildingSO buildingSO;

    [SerializeField]
    private int workersMax;
    [SerializeField]
    private int customersMax;
    [SerializeField]
    List<PeopleControllerScript> customers;
    [SerializeField]
    List<PeopleControllerScript> workers;
    [SerializeField]
    private Material materialToUse;
    [SerializeField]
    private Enums.Building.Type buildingType;

    bool canStart = false;
    bool hasSentPulse = false;
    public bool hasRoomForCustomers = true;

    public GameObject radialPulsePrefab;
    public float recruitingDelay;

    public int moneyInBuilding;

    public void Init(BuildingSO buildingSO) {
        this.buildingSO = buildingSO;
        workersMax = buildingSO._workersMax;
        customersMax = buildingSO._customersMax;
        buildingType = buildingSO._buildingType;
        materialToUse = buildingSO._materialToUse;


        GetComponent<MeshRenderer>().material = materialToUse;

        canStart = true;
    }

    // Use this for initialization
    void Start () {
        Init(buildingSO);
    }
	
    public bool HasRoomForCustomers() {
        return hasRoomForCustomers;
    }

    public void AddWorker(PeopleControllerScript worker) {
        if(workers.Count < workersMax) {
            workers.Add(worker);
        }
    }

    public void AddCustomer(PeopleControllerScript customer) {
        if(customers.Count < customersMax) {
            customers.Add(customer);
        }
    }

	// Update is called once per frame
	void Update () {
        if (customers.Count >= customersMax) {
            hasRoomForCustomers = false;
        }
        if (canStart && !hasSentPulse) {
            var pulse = Instantiate(radialPulsePrefab, transform.position, radialPulsePrefab.transform.rotation, transform);
            pulse.GetComponent<RadialPulseScript>().SetEffect(Enums.RadialPulseEffectType.newJob, workersMax, .3f, 15);

            hasSentPulse = true;
            canStart = false;
        }
        
	}
}
