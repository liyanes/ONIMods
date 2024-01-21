using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRINGS
{
    public class MOREPOWER {
        public class OPTIONS
        {
            public class POWERTRANSFORMER
            {
                public static LocString CATEGORY = "Power Transformer Control";
            }

            public class POWERTRANSFORMERSMALLWATT
            {
                public static LocString NAME = "Power Transformer Watt";
                public static LocString TOOLTIP = "Max watt outputed by Power Transformer";
            }
            public class POWERTRANSFORMERWATT
            {
                public static LocString NAME = "Big Power Transformer Watt";
                public static LocString TOOLTIP = "Max watt outputed by Big Power Transformer";
            }

            public class WIRE
            {
                public static LocString CATEGORY = "Wire Control";
            }

            public class WIREMAXWATT {
                public static LocString NAME = "Wire max watt(Overload watt)";
                public static LocString TOOLTIP = "Max watt of wire. The wire will overload if the watt is over the value, including Wire Bridge.";
            }

            public class WIREREDEFINEDMAXWATT
            {
                public static LocString NAME = "Wire Redefined max watt";
                public static LocString TOOLTIP = "Max watt of wire redefined. The wire will overload if the watt is over the value, including Wire Redefined Bridge";
            }

            public class WIREHIGHWATTAGEMAXWATT
            {
                public static LocString NAME = "Wire High Wattege max watt";
                public static LocString TOOLTIP = "Max watt of wire high wattage. The wire will overload if the watt is over the value, including Wire Bridge";
            }

            public class WIREREDEFINEDHIGHWATTAGEMAXWATT
            {
                public static LocString NAME = "Wire Redefined High Wattege max watt";
                public static LocString TOOLTIP = "Max watt of wire redefined high wattage. The wire will overload if the watt is over the value, including Wire Bridge";
            }

            public class GENERATOR
            {
                public static LocString CATEGORY = "Generator Control";
            }

            public class MANUALGENERATORWATT
            {
                public static LocString NAME = "Manual Generator Watt";
                public static LocString TOOLTIP = "Output Watt of Manual Generator";
            }

            public class MANUALGENERATORCAPCITYWATT
            {
                public static LocString NAME = "Manual Generator Watt Capcity";
                public static LocString TOOLTOP = "";
            }

            public class GENERATORWATT
            {
                public static LocString NAME = "Coal Generator Watt";
                public static LocString TOOLTIP = "Output Watt of Coal Generator";
            }

            public class GENERATORCAPCITYWATT
            {
                public static LocString NAME = "Coal Generator Watt Capcity";
                public static LocString TOOLTIP = "";
            }

            public class BATTERY
            {
                public static LocString CATEGORY = "Battery Control";
            }

            public class BATTERYCAPACITY
            {
                public static LocString NAME = "Small Battery Capacity";
                public static LocString TOOLTIP = "";
            }

            public class BATTERYMEDIUMCAPACITY
            {
                public static LocString NAME = "Big Battery Capacity";
                public static LocString TOOLTIP = "";
            }

            public class BATTERYSMARTCAPACITY
            {
                public static LocString NAME = "Smart Battery Capacity";
                public static LocString TOOLTIP = "";
            }
        }
    }
    
}
