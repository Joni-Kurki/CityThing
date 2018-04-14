using UnityEngine;

[CreateAssetMenu(fileName = "People", menuName = "Create People")]
public class PeopleSO : ScriptableObject {

    public bool _hasJob;
    public bool _isBusy;
    public Enums.People.Sex _sex;
    public Enums.People.Relationship _relationship;
    public Enums.People.Age _age;
    public Material _materialToUse;
}
