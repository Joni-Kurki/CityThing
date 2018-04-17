using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Create Building")]
public class BuildingSO : ScriptableObject {

    public int _workersMax;
    public int _customersMax;
    public int _size;
    public Material _materialToUse;
    public Enums.Building.Type _buildingType;
}
