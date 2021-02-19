using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShoppingCart_DAL;
using ShoppingCart_Entity;

using System.Configuration;
namespace ShoppingCart_DAL
{
    public class AddToCartDAL
    {
        static string shoppingcartcon = ConfigurationSettings.AppSettings["ShoppingCart"].ToString();
        SqlConnection con = new SqlConnection(shoppingcartcon);
        SqlCommand cmdUniversal;
        /// <summary>
        /// Save AddToCart data
        /// </summary>
        /// <param name="objAddToCartModel"></param>
        /// <returns></returns>
        public int InsertAddToCart(AddToCartModel objAddToCartModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_InsertAddToCart", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters.AddWithValue("@ProductId", objAddToCartModel.ProductId);
                    cmdUniversal.Parameters.AddWithValue("@UserId", objAddToCartModel.UserId);
                    
                    result = cmdUniversal.ExecuteNonQuery();
                    if (result > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        /// <summary>
        /// get cart item count and Total Price
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetAddToCartCount(int productId, string userId)
        {
            SqlConnection con = new SqlConnection(shoppingcartcon);
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetAddToCartCount";
                cmdUniversal.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
                cmdUniversal.Parameters.Add("@UserId", SqlDbType.VarChar).Value = userId;
                cmdUniversal.Connection = con;
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daUniversal = new SqlDataAdapter();
                daUniversal.SelectCommand = cmdUniversal;
                result = daUniversal.Fill(dt);
                con.Close();
                return dt;
            }
        }
        /// <summary>
        /// show user Cart data
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public DataTable GetAddToCart(int productId, string user)
        {
            SqlConnection con = new SqlConnection(shoppingcartcon);
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetAddToCart";
                cmdUniversal.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
                cmdUniversal.Parameters.Add("@UserId", SqlDbType.VarChar).Value = user;
                cmdUniversal.Connection = con;
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daUniversal = new SqlDataAdapter();
                daUniversal.SelectCommand = cmdUniversal;
                result = daUniversal.Fill(dt);
                con.Close();
                return dt;
            }
        }
        /// <summary>
        /// Remove Cart Item
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public int DeleteAddToCart(string productId, string user)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_DeleteAddToCart", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters.Add("@ProductId", SqlDbType.Int).Value =productId;
                    cmdUniversal.Parameters.Add("@UserId",SqlDbType.VarChar).Value=user;
                    result = cmdUniversal.ExecuteNonQuery();
                    return result;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
        }

    }
}
