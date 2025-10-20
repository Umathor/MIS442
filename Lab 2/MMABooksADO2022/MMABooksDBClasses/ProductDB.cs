using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {

        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, OnHandQuantity, UnitPrice "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    product.Description = prodReader["Description"].ToString();
                    product.OnHandQuantity = (int)prodReader["OnHandQuantity"];
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(ProductCode, Description, OnHandQuantity, UnitPrice) " +
                "VALUES (@ProductCode, @Description, @OnHandQuantity, @UnitPrice)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue(
                "@Description", product.Description);
            insertCommand.Parameters.AddWithValue(
                "@OnHandQuantity", product.OnHandQuantity);
            insertCommand.Parameters.AddWithValue(
                "@UnitPrice", product.UnitPrice);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                string productCode = Convert.ToString(selectCommand.ExecuteScalar());
                return productCode;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode" +
                "AND Description = @Description" +
                "AND OnHandQuantity = @OnHandQuantity" +
                "AND UnitPrice = @UnitPrice";
            MySqlCommand deleteCommand =
                new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            deleteCommand.Parameters.AddWithValue("@Description", product.Description);
            deleteCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            deleteCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);

            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return false;
        }

        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "ProductCode = @NewProductCode, " +
                "Description = @NewDescription, " +
                "OnHandQuantity = @NewOnHandQuantity, " +
                "UnitPrice = @NewUnitPrice " +
                "WHERE ProductCode = @OldProductCode " +
                "AND Description = @OldDescription " +
                "AND OnHandQuantity = @OldOnHandQuantity " +
                "AND UnitPrice = @OldUnitPrice";
            MySqlCommand updateCommand =
                new MySqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewProductCode", newProduct.ProductCode);
            updateCommand.Parameters.AddWithValue("@NewDescription", newProduct.Description);
            updateCommand.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue("@OldProductCode", oldProduct.ProductCode);
            updateCommand.Parameters.AddWithValue("@OldDescription", oldProduct.Description);
            updateCommand.Parameters.AddWithValue("@OldOnHandQuantity", oldProduct.OnHandQuantity);
            updateCommand.Parameters.AddWithValue("@OldUnitPrice", oldProduct.UnitPrice);
            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count == 1)
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return false;
        }
    }
}
