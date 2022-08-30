using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLWithCSharp;

public class Customer
{
    #region Properties that match the column names
    // We don't have to do everything
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string City { get; set; }
    #endregion

    public string GetFullName()
    {
        return $"{ContactTitle} - {ContactName}";
    }
}
