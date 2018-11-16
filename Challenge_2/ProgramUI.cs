using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ProgramUI
    {
        ClaimRepository _claimRepo = new ClaimRepository();
        Queue<Claim> claims;
        public void Run()
        {
            claims = _claimRepo.GetContentList();
            Claim One = new Claim
            {
                ClaimId = 1,
                ClaimType = "Car",
                Description = "Car accident on 465",
                ClaimAmount = 400.00m,
                DateOfIncident = "4/25/18",
                DateOfClaim = "4/27/18",
            };
            Claim Two = new Claim
            {
                ClaimId = 2,
                ClaimType = "House",
                Description = "House fire in kitchen",
                ClaimAmount = 4000.00m,
                DateOfIncident = "4/26/18",
                DateOfClaim = "4/28/18",
            };
            Claim Three = new Claim
            {
                ClaimId = 3,
                ClaimType = "Theft",
                Description = "Stolen pancakes",
                ClaimAmount = 4.00m,
                DateOfIncident = "4/27/18",
                DateOfClaim = "6/01/18",
            };

            _claimRepo.AddItemToMenu(One);
            _claimRepo.AddItemToMenu(Two);
            _claimRepo.AddItemToMenu(Three);

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Choose a menu item:\n1. See all claims.\n2. Take care of next claim." +
                    "\n3. Enter a new claim.\n4. Exit.");
                int response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        SeeClaims();
                        break;
                    case 2:
                        AddressNextClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }
        private void SeeClaims()   
        {
            Console.WriteLine("Pending Claims: ");
            foreach (Claim claim in _claimRepo.GetContentList())
            {
                Console.WriteLine($"{claim.ClaimId, -2}{claim.ClaimType, -5}" +
                    $"{claim.Description, -24}{claim.ClaimAmount, 10}{claim.DateOfIncident, 10}" +
                    $"{claim.DateOfClaim, 10}{claim.IsValid, -7}");
            }
        }
        private void AddressNextClaim()
        {
            Console.WriteLine("Here are the details for the next claim to be handled: \n");
            Claim claim = claims.Peek();
            Console.WriteLine($"Enter the Claim ID: {claim.ClaimId}");
            Console.WriteLine($"Enter the Claim Type: {claim.ClaimType}");
            Console.WriteLine($"Enter the Claim Description: {claim.Description}");
            Console.WriteLine($"Amount of Damage: {claim.ClaimAmount}");
            Console.WriteLine($"Date of Accident: {claim.DateOfIncident}");
            Console.WriteLine($"Date of Claim: {claim.DateOfClaim}");
            Console.WriteLine($"Is Valid: {claim.IsValid}\b");
            
            Console.WriteLine("Do you want to deal with this claim now? y/n");
            string reply = Console.ReadLine();
            bool isReady = true;
            switch (reply)
            {
                case "y":
                    isReady = true;
                    _claimRepo.GetContentList().Dequeue();
                    break;
                case "n":
                    isReady = false;
                    break;
            }
        }
        private void EnterNewClaim()
        {
            Claim newContent = new Claim();

            Console.WriteLine("Enter the Claim ID: ");
            newContent.ClaimId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Claim Type: ");
            newContent.ClaimType = Console.ReadLine();
            Console.WriteLine("Enter the Claim Description: ");
            newContent.Description = Console.ReadLine();
            Console.WriteLine("Amount of Damage: ");
            newContent.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Date of Accident: ");
            newContent.DateOfIncident = Console.ReadLine();
            Console.WriteLine("Date of Claim: ");
            newContent.DateOfClaim = Console.ReadLine();
            Console.WriteLine("Is this claim less than a month old? y/n");
            string answer = Console.ReadLine();
            bool lessThanAMonth = true;
            switch (answer)
            {
                case "y":
                    lessThanAMonth = true;
                    Console.WriteLine("Is Valid: True");
                    break;
                case "n":
                    lessThanAMonth = false;
                    Console.WriteLine("Is Valid: False");
                    break;
            }
            _claimRepo.AddItemToMenu(newContent);
        }
    }
}
