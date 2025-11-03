using System;

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
using System.Collections.Generic;

namespace MMABooksDB
{
    public class ProductDB : DBBase, IReadDB, IWriteDB
    {
        public ProductDB() : base() { }
        public ProductDB(DBConnection cn) : base(cn) { }

        public IBaseProps Create(IBaseProps p)
        {
            int rowsAffected = 0;
            ProductProps props = (ProductProps)p;

            DBCommand command = new DBCommand();
            command.CommandText = "usp_ProductCreate";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("prodId", 0); // output parameter
            command.Parameters["prodId"].Direction = ParameterDirection.Output;
            command.Parameters.AddWithValue("productCode_p", props.ProductCode);
            command.Parameters.AddWithValue("description_p", props.Description);
            command.Parameters.AddWithValue("unitprice_p", props.UnitPrice);
            command.Parameters.AddWithValue("onhandquantity_p", props.OnHandQuantity);
            try
            {
                rowsAffected = RunNonQueryProcedure(command);
                if (rowsAffected == 1)
                {
                    props.ProductID = Convert.ToInt32(command.Parameters["productId"].Value);
                    props.ConcurrencyID = 1;
                    return props;
                }
                else
                    throw new Exception("Unable to insert record. " + props.GetState());
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
        public bool Delete(IBaseProps p)
        {
            int rowsAffected = 0;
            ProductProps props = (ProductProps)p;
            DBCommand command = new DBCommand();
            command.CommandText = "usp_ProductDelete";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("prodId", DBDbType.Int32);
            command.Parameters.Add("conCurrId", DBDbType.Int32);
            command.Parameters["prodId"].Value = props.ProductID;
            command.Parameters["conCurrId"].Value = props.ConcurrencyID;

            try
            {
                rowsAffected = RunNonQueryProcedure(command);
                if (rowsAffected == 1)
                {
                    return true;
                }
                else
                {
                    string message = "Record cannot be deleted. It has been edited by another user.";
                    throw new Exception(message);
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
        public bool Update(IBaseProps p)
        {
            int rowsAffected = 0;
            ProductProps props = (ProductProps)p;
            DBCommand command = new DBCommand();
            command.CommandText = "usp_ProductUpdate";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("prodId", DBDbType.Int32);
            command.Parameters.Add("productCode_p", DBDbType.VarChar);
            command.Parameters.Add("description_p", DBDbType.VarChar);
            command.Parameters.Add("unitprice_p", DBDbType.Decimal);
            command.Parameters.Add("onhandquantity_p", DBDbType.Int32);
            command.Parameters.Add("conCurrId", DBDbType.Int32);
            command.Parameters["prodId"].Value = props.ProductID;
            command.Parameters["productCode_p"].Value = props.ProductCode;
            command.Parameters["description_p"].Value = props.Description;
            command.Parameters["unitprice_p"].Value = props.UnitPrice;
            command.Parameters["onhandquantity_p"].Value = props.OnHandQuantity;
            command.Parameters["conCurrId"].Value = props.ConcurrencyID;
            try
            {
                rowsAffected = RunNonQueryProcedure(command);
                if (rowsAffected == 1)
                {
                    props.ConcurrencyID++;
                    return true;
                }
                else
                {
                    string message = "Record cannot be updated. It has been edited by another user.";
                    throw new Exception(message);
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
        public IBaseProps Retrieve(object key)
        {
            DBDataReader data = null;
            ProductProps props = new ProductProps();
            //set command object
            DBCommand command = new DBCommand();
            command.CommandText = "usp_ProductSelect";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("prodId", DBDbType.Int32);
            command.Parameters["prodId"].Value = (int)key;
            try
            {
                data = RunProcedure(command);
                if (!data.IsClosed)
                {
                    if (data.Read())
                    {
                        props.SetState(data);
                    }
                    else
                    {
                        throw new Exception("Record does not exist in the database.");
                    }
                }
                return props;
            }
            catch (Exception e)
            {
                // log this error
                throw;
            }
            finally
            {
                if (data != null)
                    data.Close();
                if (mConnection.State == ConnectionState.Open)
                    mConnection.Close();
            }
        }
        public object RetrieveAll()
        {
            List<ProductProps> products = new List<ProductProps>();
            DBDataReader data = null;
            ProductProps props;
            // set command object
            DBCommand command = new DBCommand();
            command.CommandText = "usp_ProductSelectAll";
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                data = RunProcedure(command);
                if (!data.IsClosed)
                {
                    while (data.Read())
                    {
                        props = new ProductProps();
                        props.SetState(data);
                        products.Add(props);
                    }
                }
                return products;
            }
            catch (Exception e)
            {
                // log this error
                throw;
            }
            finally
            {
                if (data != null)
                    data.Close();
                if (mConnection.State == ConnectionState.Open)
                    mConnection.Close();
            }
        }
    }
}
