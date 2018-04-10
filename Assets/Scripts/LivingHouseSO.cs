using UnityEngine;

[CreateAssetMenu(fileName = "Living building", menuName = "Create Living building")]
public class LivingHouseSO : ScriptableObject {

    public int _adults;
    public int _kids;
    public int _cars;
    public bool _hasElectricity;
    public bool _isConnectedByRoad;
    public Material _materialToUse;

    public Enums.LivingHouseType _livingHouseType;
}
