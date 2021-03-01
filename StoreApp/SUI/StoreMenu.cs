using System;
using SBL;
using SModels;

namespace SUI
{
    public class StoreMenu : IMenu
    {
        private Product _product;
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
            Console.WriteLine("====================================================================================================");
            Console.WriteLine("");
            Console.WriteLine("All store locations: ");
            Console.WriteLine("");
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
                Console.WriteLine("");
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
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
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
            //Make a new order with total equal to zero and date the time it was executed.
            _storeBL.addNewOrder();
            Orders order = _storeBL.getMostRecentOrder();
            bool stillOrdering = true;
            int count = 1;
            do{
                //Make new order item and add it to the database.
                _storeBL.addOrderItem(getOrderDetails());
                OrderItem newOrderItem = _storeBL.getMostRecentOrderItem();

                //Add order to track order database table
                _storeBL.addTrackOrderItem(setTrackOrderDetails(order, newOrderItem));

                //When you have product quantity and productID Add to orderItem list.
                //Create new track order object and add customerID, orderID, orderItemID, and StoreID
                //Then add that to the database. 

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

            //Find out the order total and update the order total value.
        }

        public OrderItem getOrderDetails(){
            OrderItem newOrderItem = new OrderItem();

            bool productTruth = true;
            do {
                Console.WriteLine("Enter the item you would like to add: ");
                _product = _storeBL.getProductByName(Console.ReadLine());
                if (_product == null){
                    Console.WriteLine("This item is not available in this store.");
                    Console.WriteLine("Maybe try another store or check your spelling.");
                    productTruth = false;
                }
                else{
                    productTruth = true;
                }
            } while(!productTruth);
            newOrderItem.Product = _product;
                
             //TODO: Input Validation
            Console.WriteLine($"Enter the quantity you would like to add of { _product.ProductName }: ");
            newOrderItem.ProductQuantity = int.Parse(Console.ReadLine());

            return newOrderItem;
        }

        public TrackOrder setTrackOrderDetails(Orders order, OrderItem orderItem){
            TrackOrder trackOrderItem  = new TrackOrder();
            trackOrderItem.Customer = _customer;
            trackOrderItem.Order = order;
            trackOrderItem.OrderItem = orderItem;
            trackOrderItem.Store = _store;
            return trackOrderItem ;
        }
        public void getInventory(){
            Console.WriteLine("====================================================================================================");
            Console.WriteLine("");
            _storeBL.getStoreInventory(_store);
            Console.WriteLine("");
            Console.WriteLine("====================================================================================================");
        }
        
        public void verifyStore(){
            bool stay = false;
            int count = 0;
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            do
            {
                Console.WriteLine("What store location would you like to visit?");
                _store = _storeBL.getStoreByName(Console.ReadLine());
                Console.WriteLine("");
                if (_store == null){
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine("That store does not exist. Please enter from the list given.");
                    stay = true;
                    count++;
                }
                else {
                    stay = false;
                }
                if (count > 3){
                    Console.WriteLine("====================================================================================================");
                    Console.WriteLine("Here is the list of stores again: ");
                    _storeBL.getAllStoreNames();
                }
            } while(stay);
            Console.WriteLine("====================================================================================================");
        } 
    }
}