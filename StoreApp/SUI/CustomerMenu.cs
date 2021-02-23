using System;

namespace SUI
{
    //Handles when a Customer visits the StoreApp
    public class CustomerMenu : IMenu
    {
        //This Start method is the beginning of the Menue options.
        public void Start(){
            Console.WriteLine("Are you a returning customer, a new customer, or a guest?");
            Console.WriteLine("[0] I am a returning customer.");
            Console.WriteLine("[1] I am a new customer.");
            Console.WriteLine("[2] I am a guest.");
            Console.WriteLine("[Q] Pess 'q' to exit.");

            bool stay = true;
            CustomerMenu customerMenu = new CustomerMenu();
            do
            {
                //Get user Input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        customerMenu.returningCustomer();
                        stay = false;
                        break;
                    case "1":
                        customerMenu.newCustomer();
                        stay = false;
                        break;
                    case "2":
                        customerMenu.guest();
                        stay = false;
                        break;
                    case "q":
                    case "Q":
                        Console.WriteLine("Thank you please come again!");
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input please choose from the given options.");
                        break;
                }
            } while (stay);
        }

        //This is the method we use when a returning customer comes back to your store.
        public void returningCustomer(){
            /*
                Work on some implementation to make sure you can track the user.
            */
            String username = "Name";
            Console.WriteLine($"Hello {username} what would you like to do.");
            Console.WriteLine("[0] Place an order.");
            Console.WriteLine("[1] View order history.");
            Console.WriteLine("[2] View location history.");
            Console.WriteLine("[Q] Pess 'q' to exit.");

            bool stay = true;
            CustomerMenu customerMenu = new CustomerMenu();
            do
            {
                //Get user Input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        //Place an order functionality.
                        break;
                    case "1":
                        //View order Functionality.
                        stay = false;
                        break;
                    case "2":
                        //View Location History.
                        stay = false;
                        break;
                    case "q":
                    case "Q":
                        Console.WriteLine("Thank you please come again!");
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input please choose from the given options.");
                        break;
                }
            } while (stay);
        }
        //This method is used to create a new user in your database.
        public void newCustomer(){
            
        }
        //This method is used to use the Store app without saving any information
        public void guest(){
            
        }
    }
}