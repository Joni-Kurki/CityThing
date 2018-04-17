using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialPulseScript : MonoBehaviour {

    SphereCollider sphere;
    public float maxRadius;
    public float radiusExpandSpeedTick;
    float lastCheck;

    public Enums.RadialPulseEffectType effectType;
    public Material hitMaterial;

	// Use this for initialization
	void Start () {
        sphere = GetComponent<SphereCollider>();
        sphere.radius = 0;
        lastCheck = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time > radiusExpandSpeedTick + lastCheck && sphere.radius <= maxRadius) {
            sphere.radius++;
            lastCheck = Time.time;
        }
	}

    private void OnTriggerEnter(Collider other) {
        var hit = other.gameObject;
        if(hit.GetComponent<BoxCollider>() && hit.tag == "LivingHouse") {
            var renderer = hit.GetComponent<LivingHouseControllerScript>().GetComponent<MeshRenderer>();
            renderer.material = hitMaterial;
        }
    }

}
