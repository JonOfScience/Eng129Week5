using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst.lib;

public static class SeedCustomers
{
    public static List<Customer> GetSeedCustomers()
    {
        // TODO: Migrate to external file
        List<Customer> custList = new List<Customer>();
        custList.Add(new Customer { CustomerId = "0", ContactName = "Sherrie Gottschalk", City = "New York", PostalCode = "10560" });
        custList.Add(new Customer { CustomerId = "1", ContactName = "Florentin Wyman", City = "Hamburg", PostalCode = "20146" });
        custList.Add(new Customer { CustomerId = "2", ContactName = "Julie Cingolani", City = "Venice", PostalCode = "30100" });
        custList.Add(new Customer { CustomerId = "3", ContactName = "Camille Bradley", City = "London", PostalCode = "W1AA 1AA" });
        custList.Add(new Customer { CustomerId = "4", ContactName = "Jacky Regenbogen", City = "San Francisco", PostalCode = "94107" });
        return custList;
    }

    public static VerifySeedResult VerifySeedCustomers()
    {
        var custList = GetSeedCustomers();
        var customerRecords = new VerifySeedResult();
        foreach (var c in custList)
        {
            customerRecords.Checked++;
            if (!Customer.DoesCustomerExist(c))
            {
                Customer.AddCustomers(c);
                customerRecords.Added++;
            }
            if (!Customer.CustomerDataMatches(c))
            {
                Customer.UpdateCustomers(c);
                customerRecords.Restored++;
            }
        }
        return customerRecords;
    }
}
