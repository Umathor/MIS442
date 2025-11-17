using System;
using System.Collections.Generic;

#nullable disable

namespace MMABooksEFClasses.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual State StateNavigation { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
