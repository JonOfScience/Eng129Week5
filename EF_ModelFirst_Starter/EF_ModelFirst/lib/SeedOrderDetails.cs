using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst.lib;

public static class SeedOrderDetails
{
    static List<OrderDetail> GetOrderDetails()
    {
        // TODO: Migrate to external file
        List<OrderDetail> orderDetailsList = new List<OrderDetail>();
        orderDetailsList.Add(new OrderDetail { OrderId = 2, Quantity = 5, UnitPrice = (decimal)20.00, Discount = (float)0.00 });
        orderDetailsList.Add(new OrderDetail { OrderId = 3, Quantity = 12, UnitPrice = (decimal)100.00, Discount = (float)10.00 });
        orderDetailsList.Add(new OrderDetail { OrderId = 4, Quantity = 8, UnitPrice = (decimal)30.25, Discount = (float)15.00 });
        orderDetailsList.Add(new OrderDetail { OrderId = 5, Quantity = 2, UnitPrice = (decimal)2.75, Discount = (float)0.25 });
        orderDetailsList.Add(new OrderDetail { OrderId = 6, Quantity = 6, UnitPrice = (decimal)227.00, Discount = (float)52.75 });
        orderDetailsList.Add(new OrderDetail { OrderId = 7, Quantity = 4, UnitPrice = (decimal)365.00, Discount = (float)100.20 });
        return orderDetailsList;
    }
}
