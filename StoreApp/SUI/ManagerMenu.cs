using SBL;
using System;
using SModels;

namespace SUI
{
    public class ManagerMenu : IMenu
    {
        private Manager _manager;
        private IStoreBL _storeBL;
        private Store _store;
        public ManagerMenu(IStoreBL storeBL){
            _storeBL = storeBL;
        }
        //Handles when a Manager enters the StoreApp
        public void Start(){
            verifyManager();
            chooseStoreLocation();
            bool stay = true;
            do
            {
                int inputvalue = 50;
                int nameLength = _manager.ManagerFirstName.Length;
                int result = inputvalue + nameLength;
                Console.WriteLine("|" + addDynamicString(result, "=") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                Console.WriteLine($"| Hello { _manager.ManagerFirstName }. What would you like to do?" + addDynamicString(result - 35 - nameLength, " ") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                Console.WriteLine("|" + addDynamicString(result, "-") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                Console.WriteLine("| [0] Replenish inventory" + addDynamicString(result - 24, " ") + "|");
                Console.WriteLine("| [1] View order history of your managed locations" + addDynamicString(result - 49, " ") + "|");
                Console.WriteLine("| [2] View customer by name" + addDynamicString(result - 26, " ") + "|");
                Console.WriteLine("| [3] View store inventory" + addDynamicString(result - 25, " ") + "|");
                Console.WriteLine("| [Q] Pess 'q' to exit." + addDynamicString(result - 22, " ") + "|");
                Console.WriteLine("|" + addDynamicString(result, " ") + "|");
                //Get user Input
                Console.WriteLine("|" + addDynamicString(result, "-") + "|");
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();
                Console.WriteLine("");

                switch (userInput)
                {
                    case "0":
                        replenishInventory();
                        break;
                    case "1":
                        viewOrderHistoryOfManagedLocations();
                        break;
                    case "2":
                        viewCustomerByName();
                        break;
                    case "3":
                        viewStoreInventory();
                        break;
                    case "q":
                    case "Q":
                        Console.WriteLine("Bye!!!!");
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
        public void verifyManager(){
            bool stay = false;
            int count = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Please enter your first name: ");
                _manager = _storeBL.getManagerByFirstName(Console.ReadLine());
                if (_manager == null){
                    Console.WriteLine("That manager does not exist.");
                    stay = true;
                    count++;
                }
                else{
                    stay = false;
                }
                if (count > 3){
                    Console.WriteLine("You entered the wrong name too many times.");
                    Exit();
                }
            } while(stay);
            Console.Clear();
        }
        public void chooseStoreLocation(){
            Console.Clear();
            //Todo: get fucntion to find the store with the longest name
            Console.WriteLine("-----------------------------");
            _storeBL.getAllStoreNames(_manager);
            Console.WriteLine("-----------------------------");
            bool stay = true;
            do {
                Console.WriteLine("Enter the name of the store you want to manage: ");
                _store = _storeBL.getStoreByName(Console.ReadLine());
                if (_store == null){
                    Console.WriteLine("");
                    Console.WriteLine("You are either not the manager of that store or you didn't enter it correctly.");
                    Console.WriteLine("Please try again");
                    Console.WriteLine("");
                }
                else{
                    stay = false;
                }
            } while(stay);
            
            Console.Clear();
        }
        public void replenishInventory(){
            Console.Clear();
            Console.WriteLine("|==================================================================|"); //66
            Console.WriteLine("|                    --List of all Products--                      |");
            Console.WriteLine("|                                                                  |");
            _storeBL.getAllProducts();
            Console.WriteLine("|==================================================================|");
            try{
                _storeBL.addProductToInventory(getProductDetails());
            } catch(Exception e){
                Console.WriteLine("_");
            }
            Console.WriteLine("Please enter any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public StoreInventory getProductDetails(){
            StoreInventory newItem2Add = new StoreInventory();
            bool loop = true;
            while(loop){
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("| Enter product name:                                |");
                string input = Console.ReadLine();
                if (_storeBL.getProductByName(input) == null){
                    addProductToDb(input);
                    loop = false;
                }
                else
                {
                    newItem2Add.Product = _storeBL.getProductByName(input);
                    break;
                }
            }

            while(loop){
                int quantity;
                Console.WriteLine("|----------------------------------------------------|");
                Console.WriteLine("| Enter the quantity of the product you want to add: |");
                string input = Console.ReadLine();
                if (int.TryParse(input, out quantity)){
                    
                    newItem2Add.InventoryQuantity = quantity;
                    loop = false;
                }
                else
                {
                    Console.WriteLine("| Invalid input please enter a valid whole number!!  |");
                }
            }
            newItem2Add.Store = _store;
            return newItem2Add;
        }
        public void addProductToDb(string input){
            bool stay = true;
            while(stay) {
                Console.WriteLine("|-------------------------------------------------------------|");
                Console.WriteLine("| That product does not exist in the product list currently.  |");
                Console.WriteLine("| Do you want to add it to the list?                          |");
                Console.WriteLine("|-------------------------------------------------------------|");
                Console.WriteLine("| [Y] Yes!                                                    |");
                Console.WriteLine("| [N] No, I do not want to add it to the product list!        |");
                Console.WriteLine("|-------------------------------------------------------------|");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "y":
                    case "Y":
                        bool loop = true;
                        int actualValue = 0;
                        while(loop){
                            Console.WriteLine("|-------------------------------------------------------------|");
                            Console.WriteLine("| Enter the value of the product as an integer:               |");
                            string valueOfProduct = Console.ReadLine();
                            if (int.TryParse(valueOfProduct, out actualValue)){
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("| Invalid input please enter a valid whole number!!           |");
                            }
                        }
                        _storeBL.addProductToDb(setProductDetails(input, actualValue));
                        stay = false;
                        break;
                    case "n":
                    case "N":
                        stay = false;
                        break;
                    default:
                        stay = true;
                        Console.WriteLine("Invalid input please choose from the given options.");
                        Console.WriteLine("");
                        break;
                }
            }
        }
        public Product setProductDetails(String nameOfProduct, int productPrice){
            Product newProduct = new Product();
            newProduct.ProductName = nameOfProduct;
            newProduct.Price = productPrice;
            return newProduct;
        }
        public void viewOrderHistoryOfManagedLocations(){
            Console.Clear();
            Console.WriteLine("|=====================================================|");
            Console.WriteLine("|            --Your Store Order History--             |");
            Console.WriteLine("|-----------------------------------------------------|");
            Console.WriteLine("| Order Number |       Order Date       | Order Total |");
            Console.WriteLine("|-----------------------------------------------------|");
            _storeBL.getOrderHistory(_store);
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
                        Console.WriteLine("|            --Your Store Order History--             |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        Console.WriteLine("| Order Number |       Order Date       | Order Total |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        _storeBL.getOrderHistory(_store, int.Parse(userInput));
                        break;
                    case "1":
                        Console.Clear();
                        Console.WriteLine("|=====================================================|");
                        Console.WriteLine("|            --Your Store Order History--             |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        Console.WriteLine("| Order Number |       Order Date       | Order Total |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        _storeBL.getOrderHistory(_store, int.Parse(userInput));
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("|=====================================================|");
                        Console.WriteLine("|            --Your Store Order History--             |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        Console.WriteLine("| Order Number |       Order Date       | Order Total |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        _storeBL.getOrderHistory(_store, int.Parse(userInput));
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("|=====================================================|");
                        Console.WriteLine("|            --Your Store Order History--             |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        Console.WriteLine("| Order Number |       Order Date       | Order Total |");
                        Console.WriteLine("|-----------------------------------------------------|");
                        _storeBL.getOrderHistory(_store, int.Parse(userInput));
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
        public void viewCustomerByName(){
            Console.Clear();
            Console.WriteLine("Enter the First name of the customer you want to search for.");
            _storeBL.getCustomerByName(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Press any button to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public void viewStoreInventory(){
            Console.Clear();
            Console.WriteLine("|" + addDynamicString(68, "=") + "|");
            Console.WriteLine("|" + addDynamicString(68, " ") + "|");
            Console.WriteLine("|" + addDynamicString(68, "-") + "|");
            Console.WriteLine("|     Product Name     |     Product Price    |   Product Quantity   |");
            Console.WriteLine("|" + addDynamicString(68, "-") + "|");
            _storeBL.getStoreInventory(_store);
            Console.WriteLine("|" + addDynamicString(68, "=") + "|");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
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