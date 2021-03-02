using System;
using SBL;

namespace SUI
{
    public class StartMenu : IMenu
    {
        private IStoreBL _storeBL;
        public StartMenu(IStoreBL storeBL){
            _storeBL = storeBL;
        }

        //Handles the beginning and deternimes if a person is a customer or manager.
        public void Start(){

            //Menu Start
            Console.Clear();
            bool stay = true;
            do
            {
                Console.WriteLine("|======================================|");
                Console.WriteLine("|                                      |");
                Console.WriteLine("| Welcome to NoxInc Store Application! |");
                Console.WriteLine("| Are you a Customer or a Manager?     |");
                Console.WriteLine("|                                      |");
                Console.WriteLine("|--------------------------------------|");
                Console.WriteLine("|                                      |");
                Console.WriteLine("| [0] I am a Customer                  |");
                Console.WriteLine("| [1] I am a Manager                   |");
                Console.WriteLine("| [Q] Press 'q' to exit.               |");
                Console.WriteLine("|                                      |");
                //Get user Input
                Console.WriteLine("|--------------------------------------|");
                Console.WriteLine("| Enter a number:                      |");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        IMenu customerMenu = new CustomerMenu(_storeBL);
                        customerMenu.Start();
                        stay = false;
                        break;
                    case "1":
                        IMenu managerMenu = new ManagerMenu(_storeBL);
                        managerMenu.Start();
                        stay = false;
                        break;
                    case "q":
                    case "Q":
                        Console.WriteLine("Thank you please come again!");
                        stay = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("!!!!Invalid input please choose from the given options.!!!!");
                        Console.WriteLine("");
                        break;
                }
            } while (stay);
        }
    }
}