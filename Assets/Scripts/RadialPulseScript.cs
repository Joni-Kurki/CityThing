using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialPulseScript : MonoBehaviour {

    SphereCollider sphere;
    public float maxRadius;
    public float radiusExpandInterval;
    float lastCheck;

    public Enums.RadialPulseEffectType effectType;
    public Material hitMaterial;

    public int effectCount;
    public bool canBeStarted = false;

	// Use this for initialization
	void Start () {
        sphere = GetComponent<SphereCollider>();
        sphere.radius = 0;
        lastCheck = Time.time;

        // TODO tyyppi määrittää mihin voi osua esim:
        // Physics2D.IgnoreLayerCollision(Constants.Layers.RadialPulse, Constants.Layers.LivingHouse);
    }

    // Initiating this object
    public void SetEffect(Enums.RadialPulseEffectType effectType, int effectCount, float radiusExpandInterval, int maxRadius) {
        this.effectType = effectType;
        this.effectCount = effectCount;
        this.radiusExpandInterval = radiusExpandInterval;
        this.maxRadius = maxRadius;
        // We can start the effect
        canBeStarted = true;
    }

    // Update is called once per frame
    void Update () {
        // If we can check again
		if(Time.time > radiusExpandInterval + lastCheck && sphere.radius <= maxRadius && canBeStarted) {
            sphere.radius++;
            lastCheck = Time.time;
        }
        // If radial pulse effect count has been run out
        if (effectCount <= 0)
            Destroy(transform.gameObject);
	}

    private void OnTriggerEnter(Collider other) {
        var hit = other.gameObject;

        // ++LIVING HOUSE
        if (hit.tag == "LivingHouse" && effectType == Enums.RadialPulseEffectType.newJob) {
            var livingHouse = hit.GetComponent<LivingHouseControllerScript>();
            // If we can recruit more people
            if (effectCount > 0) {
                var people = livingHouse.GetPeople();
                foreach (GameObject go in people) {
                    var person = go.GetComponent<PeopleControllerScript>();
                    // If the person is unemployed adult -> give them a job
                    if (person._age != Enums.People.Age.kid && !person._hasJob) {
                        person._hasJob = true;
                        person._isBusy = true;
                        // Let's add worker to parent go, whom Instantiated this script
                        transform.parent.GetComponent<BuildingControllerScript>().AddWorker(person);

                        effectCount--;
                    }
                }
            }
        }
        // --LIVING HOUSE
        
        // ++PEOPLE LOOKING FOR SOMETHING TO DO
        if (hit.tag == "Building" && effectType == Enums.RadialPulseEffectType.lookingForSomethingToDo) {
            var building = hit.GetComponent<BuildingControllerScript>();
            var person = transform.parent.GetComponent<PeopleControllerScript>();

            if (effectCount > 0 && PassesSpecialRules(building, person)) {
                if (building.HasRoomForCustomers()) {
                    building.AddCustomer(person);

                    effectCount--;
                }
            }
        }
        // --PEOPLE LOOKING FOR SOMETHING TO DO
    }

    // Add special rules for check
    bool PassesSpecialRules(BuildingControllerScript building, PeopleControllerScript person) {
        if(building.buildingSO._buildingType == Enums.Building.Type.bar && person._age == Enums.People.Age.kid) {
            Debug.Log("Kid tried to go to the bar! no can jose!");
            return false;
        }
        return true;
    }

}
