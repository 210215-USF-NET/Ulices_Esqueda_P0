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
            Console.WriteLine("[1] I am a new customer, and would like to sign up.");
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
                        Customers customer = verifyCustomer();
                        returningCustomer(customer);
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
        public void returningCustomer(Customers customer){
            bool stay = true;
            do
            {
                Console.WriteLine($"Hello {customer.getCustomerFullName()} what would you like to do.");
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
                        OrderHistory(customer);
                        break;
                    case "2":
                        LocationHistory(customer);
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

        public Customers verifyCustomer(){
            Customers customer = new Customers();
            bool stay = false;
            int count = 0;
            do
            {
                Console.WriteLine("Please enter your email: ");
                customer = _storeBL.getCustomerByEmail(Console.ReadLine());
                if (customer == null){
                    Console.WriteLine("That email does not exist.");
                    stay = true;
                    count++;
                }
                if (count > 3){
                    Console.WriteLine("You entered the wrong email too many times.");
                    Exit();
                }
            } while(stay);
            
            return customer;
        }
        //This method is used to create a new user in your database.
        public void newCustomer(){
            Console.WriteLine("Hello and welcome to (EnterShopName). Thank you for signing up.");
            Console.WriteLine("We are just going to need some basic information to get started.");
            Customers customer =_storeBL.addCustomer(GetCustomerDetails());
            returningCustomer(customer);
        }

        public Customers GetCustomerDetails(){
            Customers newCustomer = new Customers();

            Console.WriteLine("Enter your first name: ");
            newCustomer.CustomerFirstName = Console.ReadLine();

            Console.WriteLine("Enter your last name: ");
            newCustomer.CustomerLastName = Console.ReadLine();

            Console.WriteLine("Enter your email: ");
            newCustomer.Email = Console.ReadLine();

            Console.WriteLine("Enter your phone number: ");
            newCustomer.CustomerPhoneNumber = Console.ReadLine();

            return newCustomer;
        }
        //This method is used to use the Store app without saving any information
        // public void guest(){
            
        // }
        
        public void OrderHistory(Customers customer){
            _storeBL.getOrderHistory(customer);
        }

        public void LocationHistory(Customers customer){
            _storeBL.getLocationHistory(customer);
        }

        public void Exit(){
            System.Environment.Exit(0);
        }
    }
}