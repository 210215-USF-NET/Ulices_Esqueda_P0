using System;
using SBL;
using SDL;
using SDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace SUI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Here we will implement a list of menu's.
            The First menu will ask if you are a customer or manager.
            From there it will continue to the Second menu accordingly.
            The Second a Menu as a customer you can:
                Decide what store you want to go to place an order.
                    Third Menu: Each Store will have their own menu to work through.
                        Place an order or look at inventory
                        Might want to give an option to order the inventory.
                        Exit the store.
                View your order history.
                    Should be able to sort by price or date
                View your location history.
                Exit the interface.
            The Second menu as a Manager you can:
                Have the ability to restock inventory.
                (Look at customers that have gone to this store.)
                (Look at orders made from this store.)
                Exit the interface.

            Might want to add a store model. To hold name of store, owner/manager, and inventory.
            At the end of the transaction you can go back to the main menu. 
            */

            //Get the config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //Setting up DB connection
            string connectionString = configuration.GetConnectionString("StoreDB");
            DbContextOptions<p0dbContext> options = new DbContextOptionsBuilder<p0dbContext>()
            .UseSqlServer(connectionString)
            .Options;

            using var context = new p0dbContext(options);

            IMenu startMenu = new StartMenu(new StoreBL(new StoreRepoDB(context, new StoreMapper())));
            startMenu.Start();
        }
    }
}
