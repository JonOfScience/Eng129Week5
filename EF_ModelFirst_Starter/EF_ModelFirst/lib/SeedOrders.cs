using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst.lib;

public static class SeedOrders
{
    public static List<Order> GetSeedOrders()
    {
        // TODO: Migrate to external file
        List<Order> orderList = new List<Order>();
        orderList.Add(new Order { CustomerId = "0", OrderDate = new DateTime(2022, 7, 21), ShippedDate = new DateTime(2022, 7, 22), ShipCountry = "Germany" });
        orderList.Add(new Order { CustomerId = "0", OrderDate = new DateTime(2022, 8, 15), ShippedDate = new DateTime(2022, 8, 22), ShipCountry = "UK" });
        orderList.Add(new Order { CustomerId = "1", OrderDate = new DateTime(2019, 1, 8), ShippedDate = new DateTime(2019, 2, 1), ShipCountry = "USA" });
        orderList.Add(new Order { CustomerId = "2", OrderDate = new DateTime(2019, 6, 12), ShippedDate = new DateTime(2022, 6, 17), ShipCountry = "Japan" });
        orderList.Add(new Order { CustomerId = "3", OrderDate = new DateTime(2020, 9, 21), ShippedDate = new DateTime(2022, 11, 3), ShipCountry = "Italy" });
        orderList.Add(new Order { CustomerId = "4", OrderDate = new DateTime(2021, 12, 25), ShippedDate = new DateTime(2022, 1, 5), ShipCountry = "France" });
        return orderList;
    }

    public static VerifySeedResult VerifySeedOrders()
    {
        var orderList = GetSeedOrders();
        var orderRecords = new VerifySeedResult();
        foreach (var o in orderList)
        {
            orderRecords.Checked++;
            if (!Order.DoesOrderExist(o))
            {
                Order.AddOrders(o);
                orderRecords.Added++;
            }
            if (!Order.OrderDataMatches(o))
            {
                Order.UpdateOrders(o);
                orderRecords.Restored++;
            }
        }
        return orderRecords;
    }
}
