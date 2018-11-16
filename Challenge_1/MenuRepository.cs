using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class MenuRepository
    {

        private List<Menu> _listOfMenuItems = new List<Menu>();

        public void AddItemToMenu(Menu contents)
        {
            _listOfMenuItems.Add(contents);
        }

        public void RemoveItemFromMenu(Menu contents)
        {
            _listOfMenuItems.Remove(contents);
        }

        public List<Menu> GetContentList()
        {
            return _listOfMenuItems;
        }

    }
}
