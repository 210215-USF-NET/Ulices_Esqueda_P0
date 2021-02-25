using SBL;
using System;

namespace SUI
{
    public class ManagerMenu : IMenu
    {
        private IStoreBL _storeBL;
        public ManagerMenu(IStoreBL storeBL){
            _storeBL = storeBL;
        }
        //Handles when a Manager enters the StoreApp
        public void Start(){

        }
    }
}