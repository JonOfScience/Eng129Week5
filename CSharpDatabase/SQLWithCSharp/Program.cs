using System.Data;
using System.Data.SqlClient;

namespace SQLWithCSharp;

internal class Program
{
    static void Main(string[] args)
    {
        var customers = new List<Customer>();

        // Database "Connection String"
        using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
        {
            // Open our connection
            connection.Open();
            #region READ (cRud)
            // Console.WriteLine(connection.State);
            // Load data into objects (need classes)

            // Create another scope to execute a particular command
            //using (var command = new SqlCommand("SELECT * FROM Customers", connection))
            //{
            //    SqlDataReader sqlReader = command.ExecuteReader();

            //    while (sqlReader.Read())
            //    {
            //        // create variables for customer
            //        var customerID = sqlReader["CustomerID"].ToString();
            //        var contactName = sqlReader["ContactName"].ToString();
            //        var companyName = sqlReader["CompanyName"].ToString();
            //        var city = sqlReader["City"].ToString();
            //        var contactTitle = sqlReader["ContactTitle"].ToString();

            //        Customer customer = new Customer() {
            //            CustomerID=customerID,
            //            ContactName=contactName,
            //            CompanyName=companyName,
            //            City=city,
            //            ContactTitle=contactTitle
            //        };

            //        customers.Add(customer);
            //    }
            //    sqlReader.Close();
            //}

            // READ THE DATA (cRud)
            //foreach (Customer c in customers)
            //{
            //    Console.WriteLine($"Customer {c.GetFullName()} has ID {c.CustomerID} and lives in {c.City}");
            //}
            #endregion

            #region CREATE (Crud)
            //// CREATE 
            //var newCustomer = new Customer()
            //{
            //    CustomerID = "CROFT",
            //    ContactName = "Jonathan Crofts",
            //    City = "London",
            //    CompanyName = "SpartaGlobal"
            //};
            //string sqlString = $"INSERT INTO CUSTOMERS(CustomerID, ContactName, CompanyName, City) VALUES ('{newCustomer.CustomerID}', '{newCustomer.ContactName}', '{newCustomer.CompanyName}', '{newCustomer.City}')";

            //// Return value (number of rows affected)
            //int affected1 = 0;

            //using (var createCommand = new SqlCommand(sqlString, connection))
            //{
            //    affected1 = createCommand.ExecuteNonQuery();
            //}
            #endregion

            #region UPDATE (crUd)
            //string sqlString = "UPDATE CUSTOMERS SET ContactTitle = 'Dr' WHERE CustomerID = 'CROFT'";
            //int affectedUpdate = 0;
            //using (var updateCommand = new SqlCommand(sqlString, connection))
            //{
            //    affectedUpdate = updateCommand.ExecuteNonQuery();
            //}
            #endregion 

            #region DELETE (cruD)
            //string idOfCustomerToDelete = "CROFT";
            //string sqlString = $"DELETE FROM CUSTOMERS WHERE CustomerID = '{idOfCustomerToDelete}'";
            //int affectedDelete = 0;
            //using (var deleteCommand = new SqlCommand(sqlString, connection))
            //{
            //    affectedDelete = deleteCommand.ExecuteNonQuery();
            //}
            #endregion

        }
        // Automatically destroy connection, => connection.Close();

        // Object Relational Map (ORM)
        // Instead of having to make a class manually...
        // ...add data fields that we may not be aware of until runtime...
        // ...an ORM will do this for us (EntityFramework)

        // There is a lot of Legacy Code and it may well look like this
    }
}