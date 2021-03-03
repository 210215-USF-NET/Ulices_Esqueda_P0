using System;
using SBL;
using SModels;

namespace SUI
{
    //Handles when a Customer visits the StoreApp
    public class CustomerMenu : IMenu
    {
        private Customers _customer;
        private IStoreBL _storeBL;
        public CustomerMenu(IStoreBL storeBL){
            _storeBL = storeBL;
        }

        //This Start method is the beginning of the Menu options.
        public void Start(){
            bool stay = true;
            Console.Clear();
            do
            {
                Console.WriteLine("|=====================================================|");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|   Are you a returning customer, or a new customer   |");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|-----------------------------------------------------|");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("| [0] I am a returning customer.                      |");
                Console.WriteLine("| [1] I am a new customer, and would like to sign up. |");
                //Console.WriteLine("[2] I am a guest.");
                Console.WriteLine("| [Q] Pess 'q' to exit.                               |");
                Console.WriteLine("|                                                     |");
                //Get user Input
                Console.WriteLine("|-----------------------------------------------------|");
                Console.WriteLine("| Enter a number:                                     |");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        verifyCustomer();
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
                        Console.Clear();
                        Console.WriteLine("Invalid input please choose from the given options.");
                        Console.WriteLine("");
                        break;
                }
            } while (stay);
            Console.Clear();
        }

        //This is the method we use when a returning customer comes back to your store.
        public void returningCustomer(){
            bool stay = true;
            Console.Clear();
            do
            {
                int inputvalue = 35;
                int nameLength = _customer.getCustomerFullName().Length;
                int result = inputvalue + nameLength;
                Console.WriteLine("|" + addDynamicString(result, "=") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                Console.WriteLine($"| Hello {_customer.getCustomerFullName()} what would you like to do. |");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                Console.WriteLine("|" + addDynamicString(result, "-") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                Console.WriteLine("| [0] Visit a shop." + addDynamicString(result - 18, " ") + "|");
                Console.WriteLine("| [1] View order history." + addDynamicString(result - 24, " ") + "|");
                Console.WriteLine("| [2] View location history." + addDynamicString(result - 27, " ") + "|");
                Console.WriteLine("| [Q] Pess 'q' to exit." + addDynamicString(result - 22, " ") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                //Get user Input
                Console.WriteLine("|" + addDynamicString(result, "-") + "|");
                Console.WriteLine("| Enter a number:" + addDynamicString(result - 16, " ") + "|");
                string userInput = Console.ReadLine();
                Console.WriteLine("");

                switch (userInput)
                {
                    case "0":
                        StoreMenu storeMenu = new StoreMenu(_storeBL);
                        storeMenu.Start(_customer);
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
                        Console.Clear();
                        Console.WriteLine("Invalid input please choose from the given options.");
                        Console.WriteLine("");
                        break;
                }
            } while (stay);
            Console.Clear();
        }

        public void verifyCustomer(){
            bool stay = false;
            int count = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("|=======================================|");
                //Console.WriteLine("|                                       |");
                Console.WriteLine("| Please enter your email:              |");
                //Console.WriteLine("|                                       |");
                //Console.WriteLine("|---------------------------------------|");
                _customer = _storeBL.getCustomerByEmail(Console.ReadLine());
                Console.WriteLine("");
                if (_customer == null){
                    Console.WriteLine("|---------------------------------------|");
                    Console.WriteLine("| That email does not exist.            |");
                    Console.WriteLine("|---------------------------------------|");
                    stay = true;
                    count++;
                }
                else{
                    stay = false;
                }
                if (count > 3){
                    Console.WriteLine("|---------------------------------------------|");
                    Console.WriteLine("| You entered the wrong email too many times. |");
                    Console.WriteLine("|---------------------------------------------|");
                    Console.WriteLine("");
                    Exit();
                }
            } while(stay);
            Console.Clear();
        }
        //This method is used to create a new user in your database.
        public void newCustomer(){
            Console.Clear();
            Console.WriteLine("|==================================================================|");
            Console.WriteLine("|                                                                  |");
            Console.WriteLine("| Hello and welcome to (EnterShopName). Thank you for signing up.  |");
            Console.WriteLine("| We are just going to need some basic information to get started. |");
            _storeBL.addCustomer(getCustomerDetails());
            _customer = _storeBL.getCustomerByEmail(_customer.Email);
            Console.WriteLine("|==================================================================|");
            Console.WriteLine("Please enter any key to continue");
            Console.ReadLine();
            Console.Clear();
            returningCustomer();
        }

        public Customers getCustomerDetails(){
            Customers newCustomer = new Customers();
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("| Enter your first name:  |");
            newCustomer.CustomerFirstName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("| Enter your last name:   |");
            newCustomer.CustomerLastName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("| Enter your email:       |");
            newCustomer.Email = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("|Enter your phone number: |");
            newCustomer.CustomerPhoneNumber = Console.ReadLine();
            Console.WriteLine("");

            _customer = newCustomer;
            return newCustomer;
        }
        //This method is used to use the Store app without saving any information
        // public void guest(){
            
        // }
        
        public void OrderHistory(){
            Console.Clear();
            Console.WriteLine("|=====================================================|");
            Console.WriteLine("|               --Your Order History--                |");
            Console.WriteLine("|-----------------------------------------------------|");
            Console.WriteLine("| Order Number |       Order Date       | Order Total |");
            Console.WriteLine("|-----------------------------------------------------|");
            _storeBL.getOrderHistory(_customer);
            Console.WriteLine("|=====================================================|");
            Console.WriteLine("");
            bool stay = true;
            do
            {
                Console.WriteLine("|=====================================================|");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|     Please choose an option from the following:     |");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|-----------------------------------------------------|");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("| [0] Display order history by order date descending  |");
                Console.WriteLine("| [1] Display order history by order date ascending   |");
                Console.WriteLine("| [2] Display order history by cost descending        |");
                Console.WriteLine("| [3] Display order hsitory by cost ascending         |");
                Console.WriteLine("| [Q] Press q to return                               |");
                Console.WriteLine("|-----------------------------------------------------|");
                Console.WriteLine("| Enter a number:                                     |");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine("|=====================================================|");
                        Console.WriteLine("|               --Your Order History--                |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        Console.WriteLine("| Order Number |       Order Date       | Order Total |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        _storeBL.getOrderHistory(_customer, int.Parse(userInput));
                        break;
                    case "1":
                        Console.Clear();
                        Console.WriteLine("|=====================================================|");
                        Console.WriteLine("|               --Your Order History--                |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        Console.WriteLine("| Order Number |       Order Date       | Order Total |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        _storeBL.getOrderHistory(_customer, int.Parse(userInput));
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("|=====================================================|");
                        Console.WriteLine("|               --Your Order History--                |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        Console.WriteLine("| Order Number |       Order Date       | Order Total |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        _storeBL.getOrderHistory(_customer, int.Parse(userInput));
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("|=====================================================|");
                        Console.WriteLine("|               --Your Order History--                |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        Console.WriteLine("| Order Number |       Order Date       | Order Total |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        _storeBL.getOrderHistory(_customer, int.Parse(userInput));
                        break;
                    case "q":
                    case "Q":
                        Console.Clear();
                        stay = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input please choose from the given options.");
                        Console.WriteLine("");
                        break;
                }
            } while (stay);
            Console.Clear();
        }

        public void LocationHistory(){
            Console.Clear();
            Console.WriteLine("|==========================================================|");
            Console.WriteLine("|                  --Your Location History--               |");
            Console.WriteLine("|----------------------------------------------------------|");
            Console.WriteLine("|         Store Name         |        Store Location       |");
            Console.WriteLine("|----------------------------------------------------------|");
            _storeBL.getLocationHistory(_customer);
            Console.WriteLine("|==========================================================|");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.WriteLine("");
            Console.Clear();
        }

        public void Exit(){
            System.Environment.Exit(0);
        }
        public string addDynamicString(int howMany, string theChar){
            string output = "";
            for (int i = 0; i != howMany; i++){
                output += theChar;
            }
            return output;
        }
    }
}