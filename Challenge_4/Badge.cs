using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public List<string> DoorNames { get; set; }

        public Badge(int badgeId, List<string> doorNames)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;
        }

        public Badge()
        {

        }

    }
}
