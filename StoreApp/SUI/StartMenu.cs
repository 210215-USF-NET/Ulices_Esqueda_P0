using System;

namespace SUI
{
    public class StartMenu : IMenu
    {
        private bool customer = false;

        private bool manager = false;

        //Handles the beginning and deternimes if a person is a customer or manager.
        public void Start(){

            //Menu Start
            Console.WriteLine("Welcome to NoxInc Store Application!");
            Console.WriteLine("Are you a returning Customer or a Manager?");
            Console.WriteLine("[0] I am a Customer");
            Console.WriteLine("[1] I am a Manager");

            bool stay = true;
            do
            {
                //Get user Input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        customer = true;
                        stay = false;
                        break;
                    case "1":
                        manager = true;
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input please choose from the given options.");
                        break;
                }
            } while (stay);
        }

        public bool getCustomer(){
            return customer;
        }

        public bool getManager(){
            return manager;
        }
    }
}