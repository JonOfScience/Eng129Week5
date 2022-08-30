using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst;

public partial class Invoice
{
    [Key]
    public string InvoiceRef { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime? DatePaid { get; set; }
    public bool isPaid { get; set; }
}
