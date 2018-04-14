using System.Collections;
using System.Collections.Generic;

public class Enums  {

	public enum LivingHouseType {
        single = 0,
        couple = 1,
        family = 2,
    }

    public class Building {
        public enum Type {
            bar = 0,
            groceryStore = 1,
            cityhall = 2,
            powerPlant = 3,
            church = 4,
        }
    }

    public class People {
        public enum Relationship {
            single = 0,
            InRelationShip = 1,
        }
        public enum Sex {
            male = 0,
            female = 1,
        }
        public enum Age {
            kid = 0,
            adult = 1,
        }
    }
}
