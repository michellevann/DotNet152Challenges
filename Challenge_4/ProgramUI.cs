using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class ProgramUI
    {
        BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            
            Badge One = new Badge
            {
                BadgeId = 1,
                DoorNames = 
                new List<string>()
                {
                    "a1", "a5", "d4"
                }
                    
            };
            Badge Two = new Badge
            {
                BadgeId = 2,
                DoorNames =
                new List<string>()
                {
                   "a1", "a4", "b1", "b2"
                }
            };
            Badge Three = new Badge
            {
                BadgeId = 3,
                DoorNames = 
                new List<string>()
                {
                    "a4", "a5"
                }
            };
            _badgeRepo.AddBadgeToList(One);
            _badgeRepo.AddBadgeToList(Two);
            _badgeRepo.AddBadgeToList(Three);
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("What would you like to do?\n\t1. Create a new badge.\n\t2. " +
                    "Update doors on an existing badge.\n\t3. Delete a badge.\n\t4. Show a list" +
                    " with badge numbers and door access.\n\t5. Exit.");
                int reply = int.Parse(Console.ReadLine());
                switch (reply)
                {
                    case 1:
                        CreateNewBadge();
                        break;
                    case 2:
                        UpdateDoors();
                        break;
                    case 3:
                        DeleteBadge();
                        break;
                    case 4:
                        PrintList();
                        break;
                    case 5:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }
        public void CreateNewBadge()
        {
            List<string> doors = new List<string>();

            Console.WriteLine("Enter Badge ID#: ");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the door that this badge can access: ");
            var door = Console.ReadLine();
            doors.Add(door);
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Do you want to add another door? y/n");
                var reply = Console.ReadLine();
                if (reply == "y")
                {
                    isRunning = true;
                    Console.WriteLine("Enter another door that this badge can access:");
                    var doorTwo = Console.ReadLine();
                    doors.Add(doorTwo);
                }
                else
	            {
                    isRunning = false;
                    break;
                }
            }
            Badge newBadge = new Badge(id, doors);

            _badgeRepo.AddBadgeToList(newBadge);
        }
        public void UpdateDoors()
        {
            Console.WriteLine("Which badge # do you want to update?");
            var id = int.Parse(Console.ReadLine());
            Dictionary<int, List<string>> badges = _badgeRepo.ShowList();

            List<string> doors = badges[id];
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Do you want to remove a door from this badge? y/n");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.WriteLine("Enter the door that this badge can no longer access: ");
                    var door = Console.ReadLine();
                    doors.Remove(door);
                }
                else
                {
                    break;
                }
                Console.WriteLine("Do you want to remove another door? y/n");
                var reply = Console.ReadLine();
                if (reply == "y")
                {
                    isRunning = true;
                    Console.WriteLine("Enter another door that this badge can no longer access:");
                    var doorTwo = Console.ReadLine();
                    doors.Remove(doorTwo);
                }
                else
                {
                    isRunning = false;
                    break;
                }
            }
            bool isRunningTwo = true;
            while (isRunningTwo)
            {
                Console.WriteLine("Do you want to add a door to this badge? y/n");
                 var replyTwo = Console.ReadLine();
                if (replyTwo == "y")
                {
                    Console.WriteLine("Enter the door that this badge can access: ");
                    var doorThree = Console.ReadLine();
                    doors.Add(doorThree);
                }
                else
                {
                    isRunningTwo = false;
                    break;
                }
                Console.WriteLine("Do you want to add another door? y/n");
                var replyThree = Console.ReadLine();
                if (replyThree == "y")
                {
                    isRunningTwo = true;
                    Console.WriteLine("Enter another door that this badge can access:");
                    var doorTwo = Console.ReadLine();
                    doors.Add(doorTwo);
                }
                else
                {
                    isRunningTwo = false;
                    break;
                }
            }
            Badge newBadge = new Badge(id, doors);

            _badgeRepo.UpdateBadgeInList(newBadge);

        }
        public void DeleteBadge()
        {
            Console.WriteLine("Which badge # would you like to remove?");
            int input = int.Parse(Console.ReadLine());
            _badgeRepo.RemoveBadgeFromList(input);
        }
        public void PrintList()
        {
            Dictionary<int, List<string>> badges = _badgeRepo.ShowList();
            foreach(KeyValuePair<int, List<string>> badge in badges)
            {
                Console.WriteLine("Badge = {0}, Doors = ", badge.Key);
                foreach (string content in badge.Value)
                {
                    Console.WriteLine(content+" ");
                }
            }
            
        }
    }
}
