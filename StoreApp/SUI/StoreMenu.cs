using System;
using SBL;
using SModels;

namespace SUI
{
    public class StoreMenu : IMenu
    {
        private Store _store;
        private Customers _customer;
        private IStoreBL _storeBL;
        public StoreMenu(IStoreBL storeBL){
            _storeBL = storeBL;
        }
        //Handles when a manager or customer comes in a store.
        public void Start(Customers customer){
            _customer = customer;
            
            Start();
        }
        public void Start(){
            Console.WriteLine("All store locations: ");
            _storeBL.getAllStoreNames();
            //TODO: Some form of input Validation, but thats for later (Stretch Goal)
            verifyStore();
            if (_customer != null){
                LocationVisited location = new LocationVisited();
                location.Customer = _customer;
                location.Store = _store;
                _storeBL.addVisistedStore(location);
            }

            bool stay = true;
            int returningValue = 0;
            do
            {
                if (returningValue == 1){
                    Console.WriteLine($"I see you're done ordering. What else would you like to do?");
                }
                else if (returningValue == 2){
                    Console.WriteLine($"Do you see anything you like? What now?");
                }
                else{
                    Console.WriteLine($"Welcome to { _store.StoreName }. What would you like to do?");
                }
                Console.WriteLine("[0] Look at inventory.");
                Console.WriteLine("[1] Place an order.");
                Console.WriteLine("[Q] Return to main menu.");

            
                //Get user Input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        getInventory();
                        returningValue = 2;
                        break;
                    case "1":
                        placeOrder();
                        returningValue = 1;
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

        public void placeOrder(){

            bool stillOrdering = true;
            int count = 1;
            do{
                Console.WriteLine("Enter the item you would like to add: ");
                string itemName = Console.ReadLine();
                //TODO: Input Validation
                Console.WriteLine($"Enter the quantity you would like to add of { itemName }: ");
                int itemQuantity = int.Parse(Console.ReadLine());

                //TODO: Add the structures needed to add this functionality.
                // Orders newOrder = new Orders();
                // Product newProduct = new Product();

                Console.WriteLine("Item successfully added to list.");
                
                if (count > 0){
                    Console.WriteLine("Are you still shopping?");
                    Console.WriteLine("[Y] Yes, I am still shopping.");
                    Console.WriteLine("[N] No, I am done shopping.");
                    string userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "y":
                        case "Y":
                            stillOrdering = true;
                            break;
                        case "n":
                        case "N":
                            stillOrdering = false;
                            break;
                        default:
                            break;
                    }
                }
                count++;
            } while(stillOrdering);
        }

        public void getInventory(){

            //TODO: Get list of products from database from this specific location.
        }
        
        public void verifyStore(){
            bool stay = false;
            int count = 0;
            do
            {
                Console.WriteLine("What store location would you like to visit?");
                _store = _storeBL.getStoreByName(Console.ReadLine());
                if (_store == null){
                    Console.WriteLine("That store does not exist. Please enter from the list given.");
                    stay = true;
                    count++;
                }
                else {
                    stay = false;
                }
                if (count > 3){
                    Console.WriteLine("Here is the list of stores again: ");
                    _storeBL.getAllStoreNames();
                }
            } while(stay);
        } 
    }
}