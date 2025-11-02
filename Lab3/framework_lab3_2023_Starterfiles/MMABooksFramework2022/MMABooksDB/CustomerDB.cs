using System;
using System.Collections.Generic;
using System.Text;

using MMABooksTools;
using MMABooksProps;

using System.Data;

// *** I use an "alias" for the ado.net classes throughout my code
// When I switch to an oracle database, I ONLY have to change the actual classes here
using DBBase = MMABooksTools.BaseSQLDB;
using DBConnection = MySql.Data.MySqlClient.MySqlConnection;
using DBCommand = MySql.Data.MySqlClient.MySqlCommand;
using DBParameter = MySql.Data.MySqlClient.MySqlParameter;
using DBDataReader = MySql.Data.MySqlClient.MySqlDataReader;
using DBDataAdapter = MySql.Data.MySqlClient.MySqlDataAdapter;
using DBDbType = MySql.Data.MySqlClient.MySqlDbType;
using System.Security.Cryptography;

namespace MMABooksDB
{
    public class CustomerDB : DBBase, IReadDB, IWriteDB
    {
        public CustomerDB() : base() { }
        public CustomerDB(DBConnection cn) : base(cn) { }

        public IBaseProps Create(IBaseProps p)
        {
            int rowsAffected = 0;
            CustomerProps props = (CustomerProps)p;
            //set command object
            DBCommand command = new DBCommand();
            command.CommandText = "usp_CustomerCreate";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("customerID", 0); // output parameter
            command.Parameters["customerID"].Direction = ParameterDirection.Output;
            command.Parameters.AddWithValue("name", props.Name);
            command.Parameters.AddWithValue("address", props.Address);
            command.Parameters.AddWithValue("city", props.City);
            command.Parameters.AddWithValue("stateCode", props.StateCode);
            command.Parameters.AddWithValue("zipCode", props.ZipCode);

            //try to run command
            try
            {
                rowsAffected = RunNonQueryProcedure(command);
                if (rowsAffected == 1)
                {
                    props.CustomerID = Convert.ToInt32(command.Parameters["customerID"].Value);
                    props.ConcurrencyID = 1;
                    return props;
                }
                else
                {
                    throw new Exception("Unable to insert record. " + props.GetState());
                }
            }
            catch (Exception e)
            {
                // log this error
                throw;
            }
            finally
            {
                if (mConnection.State == ConnectionState.Open)
                    mConnection.Close();
            }
        }
    }
    
}
