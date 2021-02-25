using System;
using SBL;
using SModels;

namespace SUI
{
    //Handles when a Customer visits the StoreApp
    public class CustomerMenu : IMenu
    {
        private IStoreBL _storeBL;
        public CustomerMenu(IStoreBL storeBL){
            _storeBL = storeBL;
        }

        //This Start method is the beginning of the Menu options.
        public void Start(){
            Console.WriteLine("Are you a returning customer, a new customer, or a guest?");
            Console.WriteLine("[0] I am a returning customer.");
            Console.WriteLine("[1] I am a new customer.");
            //Console.WriteLine("[2] I am a guest.");
            Console.WriteLine("[Q] Pess 'q' to exit.");

            bool stay = true;
            do
            {
                //Get user Input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        returningCustomer();
                        stay = false;
                        break;
                    case "1":
                        newCustomer();
                        stay = false;
                        break;
                    // case "2":
                    //     guest();
                    //     stay = false;
                    //     break;
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
            bool stay = true;
            do
            {
                String username = "Name";
                Console.WriteLine($"Hello {username} what would you like to do.");
                Console.WriteLine("[0] Visit a shop.");
                Console.WriteLine("[1] View order history.");
                Console.WriteLine("[2] View location history.");
                Console.WriteLine("[Q] Pess 'q' to exit.");

                //Get user Input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        IMenu storeMenu = new StoreMenu(_storeBL);
                        storeMenu.Start();
                        break;
                    case "1":
                        OrderHistory();
                        break;
                    case "2":
                        LocationHistory();
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
        // public void guest(){
            
        // }
        
        public void OrderHistory(){

        }

        public void LocationHistory(){

        }
    }
}