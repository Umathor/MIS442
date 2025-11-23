using System;
using System.Collections.Generic;

#nullable disable

namespace MMABooksEFClasses.Models
{
    public partial class Invoicelineitem
    {
        public int InvoiceId { get; set; }
        public string ProductCode { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product ProductCodeNavigation { get; set; }
    }
}
