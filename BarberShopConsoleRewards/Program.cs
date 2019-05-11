using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RewardsTest;

namespace BarberShopConsoleRewards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("{1}:Show list of customers");
            Console.WriteLine("{2}:Register a new customer");
            Console.WriteLine("{3}:Add a point towards a free haircut");
            string userInput = Convert.ToString(Console.ReadLine());

            if (userInput == "1")
            {
                Console.Clear();
                ShowCustomers show = new ShowCustomers();
                foreach (var person in show.ShowUsers())
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName} {person.PhoneNumber} {person.RewardCount}");
                }
                Console.ReadLine();
            }

            else if (userInput == "2")
            {
                Console.Clear();
                Register reg = new Register();
                reg.RegisterUser();
            }
            
            else if (userInput == "3")
            {
                Console.Clear();
                AddPoint add = new AddPoint();
                add.Points();
            }
        }
    }
}
