using System;
using SBL;
using SModels;

namespace SUI
{
    public class StoreMenu : IMenu
    {
        private IStoreBL _storeBL;
        public StoreMenu(IStoreBL storeBL){
            _storeBL = storeBL;
        }
        //Handles when a manager or customer comes in a store.
        public void Start(){
            Console.WriteLine("What store location would you like to visit?");
            //TODO: Need to show all Locations in Database
            //TODO: Some form of input Validation, but thats for later (Stretch Goal)
            string storeName = Console.ReadLine();
            bool stay = true;
            int count = 0;
            do
            {
                if (count > 0){
                    Console.WriteLine($"Hello! Welcome back to { storeName }. What would you like to do?");
                }
                else{
                    Console.WriteLine($"Welcome to { storeName }. What would you like to do?");
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
                        break;
                    case "1":
                        placeOrder();
                        count++;
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
    }
}