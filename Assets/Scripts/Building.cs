using System.Collections;
using System.Collections.Generic;


public class Building  {

    public int _workersMax;
    public int _customersMax;
    public int _size;
    public Enums.Building.Type _buildigType;

    public Building(int workers, int customers, int size, Enums.Building.Type buildigType) {
        _workersMax = workers;
        _customersMax = customers;
        _size = size;
        _buildigType = buildigType;
    }
}
