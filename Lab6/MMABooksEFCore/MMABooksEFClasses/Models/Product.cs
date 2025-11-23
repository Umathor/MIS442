using System;
using System.Collections.Generic;

#nullable disable

namespace MMABooksEFClasses.Models
{
    public partial class Product
    {
        public Product()
        {
            Invoicelineitems = new HashSet<Invoicelineitem>();
        }

        public string ProductCode { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int OnHandQuantity { get; set; }

        public virtual ICollection<Invoicelineitem> Invoicelineitems { get; set; }
    }
}
