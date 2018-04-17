using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People {

    bool _hasJob;
    bool _isBusy;
    bool _isBored;
    float _getsBoredInterval;
    float _doesSomethingInterval;
    Enums.People.Sex _sex;
    Enums.People.Relationship _relationship;
    Enums.People.Age _age;

    public People(bool hasJob, bool isBusy, bool isBored, float getBoredInterval, float doesSomethingInterval, Enums.People.Sex sex, Enums.People.Relationship relationship, Enums.People.Age age) {
        _hasJob = hasJob;
        _isBusy = isBusy;
        _isBored = isBored;
        _getsBoredInterval = getBoredInterval;
        _doesSomethingInterval = doesSomethingInterval;
        _sex = sex;
        _relationship = relationship;
        _age = age;
    }
}
