using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst;

public partial class Order
{
    public static Order[] FindOrder(Order order)
    {
        using (var db = new SouthwindContext())
        {
            var this_order = db.Orders.Where(x => (
                x.CustomerId == order.CustomerId &&
                x.InvoiceRef == order.InvoiceRef &&
                x.OrderDate == order.OrderDate &&
                x.ShipCountry == order.ShipCountry &&
                x.ShippedDate == order.ShippedDate
                ));
            return this_order.ToArray();
        }
    }

    public static bool DoesOrderExist(Order order)
    {
        using (var db = new SouthwindContext())
        {
            /*if (db.Orders.Find(order.OrderId) is null)
                return false;*/
            var this_order = FindOrder(order);
            if (this_order is not null)
                return true;
            return false;
        }
    }

    public static bool OrderDataMatches(Order order)
    {
        using (var db = new SouthwindContext())
        {
            var found_order = Order.FindOrder(order)[0];
            if (found_order.CustomerId != order.CustomerId) return false;
            if (found_order.InvoiceRef != order.InvoiceRef) return false;
            if (found_order.OrderDate != order.OrderDate) return false;
            if (found_order.ShipCountry != order.ShipCountry) return false;
            if (found_order.ShippedDate != order.ShippedDate) return false;
        }
        return true;
    }

    public static void AddOrders(Order order)
    {
        using (var db = new SouthwindContext())
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }

    public static void UpdateOrders(Order order)
    {
        using (var db = new SouthwindContext())
        {
            db.Orders.Update(order);
            db.SaveChanges();
        }
    }

}
