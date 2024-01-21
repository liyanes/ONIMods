using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static STRINGS.UI;

namespace AdjustableSweeper.STRINGS
{
    public class UI
    {
        public class UISIDESCREENS
        {
            public class SWEEPERRANGEADJUST
            {
                public static LocString NAME = "Distance";
                public static LocString TOOLTIP = $"The sweeper can reach as away as {FormatAsKeyWord("{0}-{1}")} blocks.";
            }
        }
    }
}
