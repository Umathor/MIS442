using System;
using System.Collections.Generic;

#nullable disable

namespace MMABooksEFClasses.Models
{
    public partial class State
    {
        public State()
        {
            Customers = new HashSet<Customer>();
        }

        public string StateCode { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
