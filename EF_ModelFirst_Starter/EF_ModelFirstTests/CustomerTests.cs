
using EF_ModelFirst;

namespace EF_ModelFirstTests;

public class CustomerTests
{
    [SetUp]
    public void Setup()
    {
        // remove test entry in DB if present
        using (var db = new SouthwindContext())
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
    public void GivenANonExistantCustomer_DoesCustomerExist_ReturnsFalse()
    {
        Customer customer = new Customer() { CustomerId = "MANDA" };
        Assert.That(!Customer.DoesCustomerExist(customer));
    }

    [TearDown]
    public void TearDown()
    {
        using (var db = new SouthwindContext())
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