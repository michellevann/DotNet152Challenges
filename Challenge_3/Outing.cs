using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class Outing
    {
        public string EventType { get; set; }
        public int Attendees { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostForEvent { get; set; }

        public Outing (string eventType, int attendees, DateTime date, decimal costPerPerson,
            decimal costForEvent)
        {
            EventType = eventType;
            Attendees = attendees;
            Date = date;
            CostPerPerson = costPerPerson;
            CostForEvent = costForEvent;
        }
        public Outing()
        {

        }
    }
}
