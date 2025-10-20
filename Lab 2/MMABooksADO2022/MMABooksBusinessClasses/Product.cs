using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string description, int onHandQuantity, string productCode, decimal unitPrice)
        {
            Description = description;
            OnHandQuantity = onHandQuantity;
            ProductCode = productCode;
            UnitPrice = unitPrice;
        }

        private string description;
        public string Description 
        {
            get 
            { 
                return description; 
            }
            set
            {
                if(value.Length <= 50)
                    description = value; 
                else
                    throw new ArgumentOutOfRangeException("The description must be 50 characters or less.");
            } 
        }

        public int OnHandQuantity { get; set; }

        private string productCode;
        public string ProductCode 
        {
            get 
            { 
                return productCode; 
            }
            set 
            { 
                if(value.Length <= 10)
                    productCode = value; 
                else
                    throw new ArgumentOutOfRangeException("The product code must be 10 characters or less.");
            }
        }

        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return Description + ", " + OnHandQuantity.ToString() + ", " + ProductCode + ", " + UnitPrice.ToString();
        }
    }

}
