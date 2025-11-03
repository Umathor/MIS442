using MMABooksTools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MMABooksProps
{
    [Serializable()]
    public class CustomerProps : IBaseProps
    {
        public int CustomerID { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string StateCode { get; set; } = "";
        public string ZipCode { get; set; } = "";

        public int ConcurrencyID { get; set; } = 0;

        public object Clone()
        {
            CustomerProps p = new CustomerProps();
            p.CustomerID = this.CustomerID;
            p.Name = this.Name;
            p.Address = this.Address;
            p.City = this.City;
            p.StateCode = this.StateCode;
            p.ZipCode = this.ZipCode;
            p.ConcurrencyID = this.ConcurrencyID;
            return p;
        }

        public string GetState()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }

        public void SetState(string jsonString)
        {
            CustomerProps p = JsonSerializer.Deserialize<CustomerProps>(jsonString);
            this.CustomerID = p.CustomerID;
            this.Name = p.Name;
            this.Address = p.Address;
            this.City = p.City;
            this.StateCode = p.StateCode;
            this.ZipCode = p.ZipCode;
            this.ConcurrencyID = p.ConcurrencyID;
        }

        public void SetState(MySqlDataReader dr)
        {
            this.CustomerID = (int)dr["CustomerID"];
            this.Name = (string)dr["Name"];
            this.Address = (string)dr["Address"];
            this.City = (string)dr["City"];
            this.StateCode = (string)dr["State"];
            this.ZipCode = (string)dr["ZipCode"];
            this.ConcurrencyID = (int)dr["ConcurrencyID"];
        }
    }
}
