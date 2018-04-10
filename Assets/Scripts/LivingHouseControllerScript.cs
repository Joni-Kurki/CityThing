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
