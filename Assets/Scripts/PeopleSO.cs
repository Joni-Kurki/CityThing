using UnityEngine;

[CreateAssetMenu(fileName = "People", menuName = "Create People")]
public class PeopleSO : ScriptableObject {

    public bool _hasJob;
    public bool _isBusy;
    public bool _isBored;
    public float _getsBoredInterval;
    public float _doesSomethingInterval;
    public Enums.People.Sex _sex;
    public Enums.People.Relationship _relationship;
    public Enums.People.Age _age;
    public Material _materialToUse;
    
}
