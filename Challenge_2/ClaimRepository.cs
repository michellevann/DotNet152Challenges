using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class ClaimRepository
    {
        private Queue<Claim> _listOfClaimItems = new Queue<Claim>();

        public void AddItemToMenu(Claim contents)
        {
            _listOfClaimItems.Enqueue(contents);
        }

        public Queue<Claim> GetContentList()
        {
            return _listOfClaimItems;
        }
    }
}
