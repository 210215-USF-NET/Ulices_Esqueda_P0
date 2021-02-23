using System;

namespace SUI
{
    public class StartMenu : IMenu
    {

        //Handles the beginning and deternimes if a person is a customer or manager.
        public void Start(){

            //Menu Start
            Console.WriteLine("Welcome to NoxInc Store Application!");
            Console.WriteLine("Are you a Customer or a Manager?");
            Console.WriteLine("[0] I am a Customer");
            Console.WriteLine("[1] I am a Manager");
            Console.WriteLine("[Q] Press 'q' to exit.");

            bool stay = true;
            do
            {
                //Get user Input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        IMenu customerMenu = new CustomerMenu();
                        customerMenu.Start();
                        stay = false;
                        break;
                    case "1":
                        IMenu managerMenu = new ManagerMenu();
                        managerMenu.Start();
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
    }
}