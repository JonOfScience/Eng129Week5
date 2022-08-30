using EF_ModelFirst.lib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            // A Migration takes your Model and turns it into a database for use
            // PMC> Add-Migration InitialCreate
            // "InitialCreate" is just a name
            // Do not rename migration files

            // Upate-Database
            // Runs any migrations that are new/outstanding

            // Creates "Up" method (builds the database) and "Down" method (drops the database tables)
            // Make modifications in another file, because if you regenerate the migration you will lose changes

            // Update-Database runs the migrations IN DATE ORDER
            // https://docs.microsoft.com/en-us/ef/core/cli/powershell
            //using (var db = new SouthwindContext())
            //{
            //}

            VerifySeedData();
            //UpdateCountries();
        }

        public static void VerifySeedData()
        {
            var customersResults = SeedCustomers.VerifySeedCustomers();
            Console.WriteLine($"{customersResults.Checked} seed customer records checked, {customersResults.Added} added, {customersResults.Restored} data restored.");
            var ordersResults = SeedOrders.VerifySeedOrders();
            Console.WriteLine($"{ordersResults.Checked} seed order records checked, {ordersResults.Added} added, {ordersResults.Restored} data restored.");
            // Verify Seed Order Data
        }

        public static void SeedDatabase()
        {
            //AddOrders(GetSeedOrders());
            //AddOrdersDetails(GetOrderDetails);
        }

        public static void AddOrders(List<Order> orderList)
        {
            using (var db = new SouthwindContext())
            {
                foreach (var o in orderList)
                {
                    db.Orders.Add(o);
                }
                db.SaveChanges();
            }
        }

        public static void AddOrdersDetails(List<OrderDetail> orderDetailsList)
        {
            using (var db = new SouthwindContext())
            {
                foreach (var o in orderDetailsList)
                {
                    db.OrderDetails.Add(o);
                }
                db.SaveChanges();
            }
        }

        // Change to a lib method that accepts the table and field names?
        static void UpdateCountries()
        {
            using (var db = new SouthwindContext())
            {
                foreach (var c in db.Customers.ToList())
                {
                    if (c.Country is null)
                    {
                        c.Country = "UK";
                    }
                }
                db.SaveChanges();
            }
        }
    }   
}
