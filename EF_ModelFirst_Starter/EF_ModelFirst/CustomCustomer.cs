using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst;

public partial class Customer
{

    public static bool DoesCustomerExist(Customer customer)
    {
        using (var db = new SouthwindContext())
        {
            if (db.Customers.Find(customer.CustomerId) is null)
                return false;
            return true;
        }
    }

    public static bool CustomerDataMatches(Customer customer)
    {
        using (var db = new SouthwindContext())
        {
            var foundCustomer = db.Customers.Find(customer.CustomerId);
            // TODO: Reimplement object comparators
            if (foundCustomer.ContactName != customer.ContactName)
                return false;
            if (foundCustomer.City != customer.City)
                return false;
            if (foundCustomer.PostalCode != customer.PostalCode)
                return false;
        }
        return true;
    }

    public static Customer[] ReadCustomers(string[] customerIds = null)
    {
        Customer[] customers;
        using (var db = new SouthwindContext())
        {
            if (customerIds is not null)
            {
                customers = new Customer[customerIds.Length];
                for (int idx = 0; idx < customerIds.Length; idx++)
                {
                    customers[idx] = db.Customers.Find(customerIds[idx]);
                }
            }
            else
            {
                customers = db.Customers.ToArray();
            }
        }
        return customers;
    }

    public static void AddCustomers(Customer customer)
    {
        using (var db = new SouthwindContext())
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
    }

    public static void AddCustomers(Customer[] custList)
    {
        using (var db = new SouthwindContext())
        {
            db.Customers.AddRange(custList);
            db.SaveChanges();
        }
    }


    public static void UpdateCustomers(Customer customer)
    {
        using (var db = new SouthwindContext())
        {
            db.Customers.Update(customer);
            db.SaveChanges();
        }
    }

    public static void UpdateCustomers(Customer[] custList)
    {
        using (var db = new SouthwindContext())
        {
            db.Customers.UpdateRange(custList);
            db.SaveChanges();
        }
    }

    public static void DeleteCustomers(Customer customer)
    {
        using (var db = new SouthwindContext())
        {
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
    }

    public static void DeleteCustomers(Customer[] custList)
    {
        using (var db = new SouthwindContext())
        {
            db.Customers.RemoveRange(custList);
            db.SaveChanges();
        }
    }
}
