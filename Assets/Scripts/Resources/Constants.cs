using System.Collections;
using System.Collections.Generic;

public class Constants  {

    public class Layers {
        public const int RADIAL_PULSE = 8;
        public const int LIVING_HOUSE = 9;
        public const int PEOPLE = 10;
    }

	public class LivingHouse {
        public const int NUMBER_OF_LIVING_HOUSE_SO = 3;
    }

    public class People {
        public class Tags {
            public const string ADULT_FEMALE = "People_Adult_Female";
            public const string ADULT_MALE = "People_Adult_Male";
            public const string KID = "People_Kid";
        }

        public class DataSOIndecies {
            public class Kid {
                public const int KID = 8;
            }
            public class Female {
                public const int EMPLOYED_INRELATIONSHIP = 0;
                public const int EMPLOYED_SINGLE = 1;
                public const int UNEMPLOYED_INRELATIONSHIP = 2;
                public const int UNEMPLOYED_SINGLE = 3;
            }
            public class Male {
                public const int EMPLOYED_INRELATIONSHIP = 4;
                public const int EMPLOYED_SINGLE = 5;
                public const int UNEMPLOYED_INRELATIONSHIP = 6;
                public const int UNEMPLOYED_SINGLE = 7;
            }
        }
    }
}
