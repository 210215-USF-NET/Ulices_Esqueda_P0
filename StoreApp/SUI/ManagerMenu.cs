using SBL;
using System;
using SModels;

namespace SUI
{
    public class ManagerMenu : IMenu
    {
        private Manager _manager;
        private IStoreBL _storeBL;
        public ManagerMenu(IStoreBL storeBL){
            _storeBL = storeBL;
        }
        //Handles when a Manager enters the StoreApp
        public void Start(){
            verifyManager();
            Console.WriteLine("Are you a returning customer, a new customer, or a guest?");
            Console.WriteLine("[0] I am a returning customer.");
            Console.WriteLine("[1] I am a new customer, and would like to sign up.");
            //Console.WriteLine("[2] I am a guest.");
            Console.WriteLine("[Q] Pess 'q' to exit.");
        }

        public void verifyManager(){
            bool stay = false;
            int count = 0;
            do
            {
                Console.WriteLine("Please enter your first name: ");
                _manager = _storeBL.getManagerByFirstName(Console.ReadLine());
                if (_manager == null){
                    Console.WriteLine("That manager does not exist.");
                    stay = true;
                    count++;
                }
                if (count > 3){
                    Console.WriteLine("You entered the wrong name too many times.");
                    Exit();
                }
            } while(stay);
        }

        public void Exit(){
            System.Environment.Exit(0);
        }
    }
}