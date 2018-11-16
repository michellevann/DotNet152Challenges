using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();
        
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Choose an action:\n1. Create Menu Item." +
                    "\n2. Remove Menu Item. \n3. See Menu Items.\n4. Exit.");
                int response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        CreateMenu();
                        break;
                    case 2:
                        RemoveMenuItem();
                        break;
                    case 3:
                        SeeList();
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
        private void CreateMenu()
        {
            Menu newContent = new Menu();
            Console.WriteLine("Enter Item Number: ");
            newContent.MenuNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Item Name: ");
            newContent.MenuName = Console.ReadLine();

            Console.WriteLine("Enter Item Description: ");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Enter Item Ingredients: ");
            newContent.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter Item Price: ");
            newContent.Price = decimal.Parse(Console.ReadLine());

            _menuRepo.AddItemToMenu(newContent);
        }
        private void RemoveMenuItem()
        {
            Console.WriteLine("What Meal Number do you want to remove?");
           
            int number = int.Parse(Console.ReadLine()); 

            foreach (Menu contents in _menuRepo.GetContentList()) 
            {
                if (number == contents.MenuNumber)
                {
                    _menuRepo.RemoveItemFromMenu(contents);
                    break;
                }
            }
        }
        private void SeeList()
        {
            Console.WriteLine("Here is a list of your items:");
            foreach (Menu content in _menuRepo.GetContentList())
            {
                Console.WriteLine($"Meal Number: {content.MenuNumber}\nItem: {content.MenuName}" +
                    $"\nDescription: {content.Description}\nIngredients: {content.Ingredients}\n" +
                    $"Price: {content.Price}\n");    
            }
        }
    }
}
