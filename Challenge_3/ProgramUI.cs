using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class ProgramUI
    {

        OutingsRepository _outingsRepo = new OutingsRepository();

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("1. See a List of Outings." +
                    "\n2. Add an outing to the list. \n3. Calculate Outings.\n4. Exit.");
                int response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        SeeOutings();
                        break;
                    case 2:
                        AddOutingToList();
                        break;
                    case 3:
                        Console.WriteLine("Enter the type you would like to calculate for: ");
                        var desiredType = Console.ReadLine();
                        _outingsRepo.AddToOutingsByType(desiredType);
                        _outingsRepo.CalculateCostByType();
                        Console.WriteLine($"Cost of that type of Outing: {_outingsRepo.CalculateCostByType()}");
                        _outingsRepo.CalculateTotalCost();
                        Console.WriteLine($"Total Cost of all Outings: {_outingsRepo.CalculateTotalCost()}");
                        break;

                    case 4:
                        isRunning = false;
                        Console.WriteLine("Good-bye.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid response.");
                        Console.ReadLine();
                        break;
                }
            }

        }
        private void SeeOutings()
        {
            Console.WriteLine("Here is a list of your outings:");
            foreach (Outing content in _outingsRepo.GetEventList())
            {
                Console.WriteLine($"Event Type: {content.EventType}\nAttendees: {content.Attendees}" +
                    $"\nDate of Event: {content.Date}\nTotal Cost Per Person: {content.CostPerPerson}\n" +
                    $"Total cost for the event: {content.CostForEvent}\n");
            }
        }
            private void AddOutingToList()
            {
                Outing newEvent = new Outing();

                Console.WriteLine("Enter event type: (Golf, Bowling, Amusement Park, Concert)");
                newEvent.EventType = Console.ReadLine();

                Console.WriteLine("Enter number of people who attended: ");
                newEvent.Attendees = int.Parse(Console.ReadLine());

                Console.WriteLine("Date of Event: ");
                newEvent.Date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Total cost per person for the event: ");
                newEvent.CostPerPerson = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Total cost for the event: ");
                newEvent.CostForEvent = decimal.Parse(Console.ReadLine());

                _outingsRepo.AddToEvent(newEvent);
            }
    }
}