using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using System.Linq;

namespace NorthwindTests
{
    public class CustomerTests
    {
        CustomerManager _customerManager;
        [SetUp]
        public void Setup()
        {
            _customerManager = new CustomerManager();
            // remove test entry in DB if present
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheNumberOfCustomersIncreasesBy1()
        {
            using (var db = new NorthwindContext())
            {
                var numberOfCustomersBefore = db.Customers.Count();
                _customerManager.Create("MANDA", "Nish Mandal", "Sparta Global");
                var numberOfCustomersAfter = db.Customers.Count();
                Assert.That(numberOfCustomersBefore, Is.EqualTo(numberOfCustomersAfter - 1));
            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheirDetailsAreCorrect()
        {
            using (var db = new NorthwindContext())
            {
                db.Customers.Add(new Customer() { CustomerId = "MANDA", ContactName = "Nish Mandal", CompanyName = "Sparta Global" });
                db.SaveChanges();
                var selectedCustomer = db.Customers.Find("MANDA");
                Assert.That(selectedCustomer.ContactName, Is.EqualTo("Nish Mandal"));
                Assert.That(selectedCustomer.CompanyName, Is.EqualTo("Sparta Global"));
            }
        }

        [Test]
        public void WhenACustomersDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new NorthwindContext())
            {
                db.Customers.Add(new Customer() { CustomerId = "MANDA", ContactName = "Nish Mandal", CompanyName = "Sparta Global" });
                db.SaveChanges();
                var status = _customerManager.Update("MANDA", "Nish Mandal", "UK", "Birmingham", "B7 4BB");
                Assert.That(status);
                var customerAfter = db.Customers.Find("MANDA");
                Assert.That(customerAfter.Country, Is.EqualTo("UK"));
                Assert.That(customerAfter.City, Is.EqualTo("Birmingham"));
                Assert.That(customerAfter.PostalCode, Is.EqualTo("B7 4BB"));
            }
        }

        [Test]
        public void WhenACustomerIsUpdated_SelectedCustomerIsUpdated()
        {
            using (var db = new NorthwindContext())
            {
                db.Customers.Add(new Customer() { CustomerId = "MANDA", ContactName = "Nish Mandal", CompanyName = "Sparta Global"});
                db.SaveChanges();
                // _customerManager.Create("MANDA", "Nish Mandal", "Sparta Global");
                var status = _customerManager.Update("MANDA", "Nish Mandal", "UK", "Birmingham", "B7 4BB");
                Assert.That(_customerManager.SelectedCustomer.CustomerId, Is.EqualTo("MANDA"));
            }
        }

        [Test]
        public void WhenACustomerIsNotInTheDatabase_Update_ReturnsFalse()
        {
            using (var db = new NorthwindContext())
            {
                var status = _customerManager.Update("MANDA", "Nish Mandal", "UK", "Birmingham", "B7 4BB");
                Assert.That(!status);
            }
        }

        [Test]
        public void WhenACustomerIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {
            using (var db = new NorthwindContext())
            {
                db.Customers.Add(new Customer() { CustomerId = "MANDA", ContactName = "Nish Mandal", CompanyName = "Sparta Global" });
                db.SaveChanges();
                var numberOfCustomersBefore = db.Customers.Count();
                _customerManager.Delete("MANDA");
                var numberOfCustomersAfter = db.Customers.Count();
                Assert.That(numberOfCustomersBefore, Is.EqualTo(numberOfCustomersAfter + 1));
            }
        }

        [Test]
        public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            using (var db = new NorthwindContext())
            {
                db.Customers.Add(new Customer() { CustomerId = "MANDA", ContactName = "Nish Mandal", CompanyName = "Sparta Global" });
                db.SaveChanges();
                _customerManager.Delete("MANDA");
                Assert.That(db.Customers.Find("MANDA"), Is.Null);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }
    }
}