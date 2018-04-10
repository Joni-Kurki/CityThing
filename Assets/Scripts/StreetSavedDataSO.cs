using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Saved street", menuName = "Create Saved Street")]
public class StreetSavedDataSO : ScriptableObject {

    public LivingHouseSO[] savedHouses;

    public void SaveHouses(LivingHouseSO [] saved) {
        savedHouses = saved;

        Debug.Log("Saved "+savedHouses.Length + " houses.");
    }
}
