using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class OutingsRepository
    {
        private List<Outing> _listOfEvents = new List<Outing>();
        private List<Outing> _outingsByType = new List<Outing>();
        private decimal _totalCostByType = 0m;
        private decimal _totalCost = 0m;

        public void AddToEvent(Outing details)
        {
            _listOfEvents.Add(details);
        }
        public List<Outing> GetEventList()
        {
            return _listOfEvents;
        }
        public void AddToOutingsByType(string desiredType)
        {
            _outingsByType = new List<Outing>();
            foreach (Outing outing in _listOfEvents)
            {
                if(desiredType == outing.EventType)
                {
                    _outingsByType.Add(outing);
                }
            }
        }
        public decimal CalculateCostByType()
        {
            foreach (Outing outing in _outingsByType)
            {
                _totalCostByType = _totalCostByType + outing.CostForEvent;
            }
            return _totalCostByType;
        }
        public decimal CalculateTotalCost()
        {
            foreach (Outing outing in _listOfEvents)
            {
                _totalCost = _totalCost + outing.CostForEvent;
            }
            return _totalCost;
        }
    }
}
