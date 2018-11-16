using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class BadgeRepository
    {
        private List<string> _listOfDoorNames  = new List<string>();
        private Dictionary<int, List<string>> _badgePairedToDoors = new Dictionary<int, List<string>>();

        public void AddBadgeToList(Badge info)
        {
            _badgePairedToDoors.Add(info.BadgeId, info.DoorNames);
        }

        public void RemoveBadgeFromList(int number)
        {
            _badgePairedToDoors.Remove(number);
        }
        public Dictionary<int, List<string>> ShowList()
        {
            return _badgePairedToDoors;
        }
        public void UpdateBadgeInList(Badge info)
        {
            _badgePairedToDoors[info.BadgeId] = info.DoorNames;
        }

    }
}
