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
            Console.Clear();
            showStoreLocations();
            verifyStore();
            if (_customer != null){
                LocationVisited location = new LocationVisited();
                location.Customer = _customer;
                location.Store = _store;
                _storeBL.addVisistedStore(location);
            }
            Console.Clear();
            bool stay = true;
            int returningValue = 0;
            do
            {
                int inputValue = checkLargestString();
                int nameLength = _store.StoreName.Length;
                int result = inputValue + nameLength;
                Console.WriteLine("|" + addDynamicString(result, "=") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                if (returningValue == 1){
                    Console.WriteLine("| I see you're done ordering. What else would you like to do?" + addDynamicString(result - 60, " ") + "|");
                }
                else if (returningValue == 2){
                    Console.WriteLine("| Do you see anything you like? What now?" + addDynamicString(result - 40, " ") + "|");
                }
                else{
                    Console.WriteLine($"| Welcome to { _store.StoreName }. What would you like to do?" + addDynamicString(result - 40 - nameLength, " ") + "|");
                }
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                Console.WriteLine("|" + addDynamicString(result, "-") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                Console.WriteLine("| [0] Look at inventory." + addDynamicString(result - 23, " ") + "|");
                Console.WriteLine("| [1] Place an order." + addDynamicString(result - 20, " ") + "|");
                Console.WriteLine("| [Q] Return to main menu." + addDynamicString(result - 25, " ") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
            
                //Get user Input
                Console.WriteLine("|" + addDynamicString(result, "-") + "|");
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        getInventory();
                        returningValue = 2;
                        break;
                    case "1":
                        if (_storeBL.checkStoreInventory(_store)){
                            placeOrder();
                            returningValue = 1;
                        }
                        else{
                            Console.Clear();
                            Console.WriteLine("This inventory is empty and there is nothing to place an order for!");
                            returningValue = 0;
                        }
                        break;
                    case "q":
                    case "Q":
                        Console.WriteLine("Thank you please come again!");
                        stay = false;
                        break;
                    default:
                    Console.Clear();
                        Console.WriteLine("Invalid input please choose from the given options.");
                        break;
                }
            } while (stay);
            Console.Clear();
        }

        public void placeOrder(){
            Console.Clear();
            int total= 0;
            //Make a new order with total equal to zero and date the time it was executed.
            _storeBL.addNewOrder();
            Orders order = _storeBL.getMostRecentOrder();
            bool stillOrdering = true;
            int count = 1;
            do{
                //Make new order item and add it to the database.
                _storeBL.addOrderItem(getOrderDetails());
                OrderItem newOrderItem = _storeBL.getMostRecentOrderItem();
                total += newOrderItem.Product.Price * newOrderItem.ProductQuantity;
                //Add order to track order database table
                _storeBL.addTrackOrderItem(setTrackOrderDetails(order, newOrderItem));

                //When you have product quantity and productID Add to orderItem list.
                //Create new track order object and add customerID, orderID, orderItemID, and StoreID
                //Then add that to the database. 

                //TODO: Add the structures needed to add this functionality.
                // Orders newOrder = new Orders();
                // Product newProduct = new Product();
                Console.WriteLine("");
                Console.WriteLine("Item successfully added to list.");
                Console.WriteLine("");
                if (count > 0){
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Are you still shopping?");
                    Console.WriteLine("[Y] Yes, I am still shopping.");
                    Console.WriteLine("[N] No, I am done shopping.");
                    Console.WriteLine("-----------------------------------");
                    string userInput = Console.ReadLine();
                    Console.WriteLine("");
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
                            Console.WriteLine("Please choose from the given options.");
                            break;
                    }
                }
                count++;
            } while(stillOrdering);
            
            //Find out the order total and update the order total value.
            order.OrderTotal = total;
            _storeBL.updateOrderTotal(order);
            Console.Clear();
        }

        public OrderItem getOrderDetails(){
            Console.Clear();
            OrderItem newOrderItem = new OrderItem();
            bool productTruth = true;
            do {
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("Enter the item you would like to add: ");
                _product = _storeBL.getStoreProductByName(Console.ReadLine(), _store);
                Console.WriteLine("");
                if (_product == null){
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine("This item is not available in this store.");
                    Console.WriteLine("Maybe try another store or check your spelling.");
                    Console.WriteLine("");
                    productTruth = false;
                }
                else{
                    productTruth = true;
                }
            } while(!productTruth);
            newOrderItem.Product = _product;
                
             //TODO: Input Validation
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Enter the quantity you would like to add of { _product.ProductName }: ");
            newOrderItem.ProductQuantity = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("====================================================================================================");
            Console.WriteLine("");
            _storeBL.getStoreInventory(_store);
            Console.WriteLine("");
            Console.WriteLine("====================================================================================================");
            Console.WriteLine("Please push any button to continue: ");
            Console.ReadLine();
            Console.Clear();
        }
        public void showStoreLocations(){
            int inputInt = 27;
            Console.WriteLine("|" + addDynamicString(inputInt, "=") + "|");
            Console.WriteLine("|" + addDynamicString(inputInt, " ") + "|");
            Console.WriteLine("| All store locations:" + addDynamicString(inputInt - 21, " ") + "|");
            Console.WriteLine("|" + addDynamicString(inputInt, "-") + "|");
            _storeBL.getAllStoreNames();
            Console.WriteLine("|" + addDynamicString(inputInt, "=") + "|");
        }
        public void verifyStore(){
            bool stay = false;
            int count = 0;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("What store location would you like to visit?");
                _store = _storeBL.getStoreByName(Console.ReadLine());
                Console.WriteLine("");
                if (_store == null){
                    Console.WriteLine("That store does not exist. Please enter from the list given.");
                    stay = true;
                    count++;
                }
                else {
                    stay = false;
                }
                if (count > 3){
                    Console.Clear();
                    Console.WriteLine("Here is the list of stores again: ");
                    showStoreLocations();
                }
            } while(stay);
            Console.Clear();
        }     
        public string addDynamicString(int howMany, string theChar){
            string output = "";
            for (int i = 0; i != howMany; i++){
                output += theChar;
            }
            return output;
        }
        public int checkLargestString(){
            int first = "I see you're done ordering. What else would you like to do?".Length;
            int second = "Do you see anything you like? What now?".Length;
            int third = "Welcome to { _store.StoreName }. What would you like to do?".Length;
            return Math.Max(first, Math.Max(second, third));
        }
    }
}