using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart_Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace ShoppingCart_DAL
{
    public class CategoryDAL
    {
        #region
        static string shoppingcartcon = ConfigurationSettings.AppSettings["ShoppingCart"].ToString();
        SqlConnection con = new SqlConnection(shoppingcartcon);
        SqlCommand cmdUniversal;
        #endregion
/// <summary>
/// 
/// </summary>
/// <param name="objCategoryModel"></param>
/// <returns></returns>
        public int InsertCategory(CategoryModel objCategoryModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_InsertCategory", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters.AddWithValue("@CategoryName", objCategoryModel.CategoryName);
                    cmdUniversal.Parameters.AddWithValue("@CategoryImage",objCategoryModel.CategoryImage);
                    cmdUniversal.Parameters.AddWithValue("@IsActive",objCategoryModel.IsActive);
                    cmdUniversal.Parameters.AddWithValue("@CategoryDescription", objCategoryModel.CategoryDescription); 
                    cmdUniversal.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                   result = cmdUniversal.ExecuteNonQuery();
                    if (result > 0)
                    { 
                        int id = Convert.ToInt32(cmdUniversal.Parameters["@Id"].Value);
                        return id;
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

        public DataTable CheckCategoryNameDuplication(string categoryname)
        {
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_CheckCategoryNameDuplication";
                cmdUniversal.Parameters.Add("@CategoryName", SqlDbType.VarChar).Value =categoryname;
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
        /// Update category data
        /// </summary>
        /// <param name="objCategoryModel"></param>
        /// <returns></returns>
        public int UpdateCategory(CategoryModel objCategoryModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_UpdateCategory", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters.AddWithValue("@CategoryName",objCategoryModel.CategoryName);
                    cmdUniversal.Parameters.AddWithValue("@CategoryImage",objCategoryModel.CategoryImage);
                    cmdUniversal.Parameters.AddWithValue("@IsActive",objCategoryModel.IsActive);
                    cmdUniversal.Parameters.AddWithValue("@CategoryDescription",objCategoryModel.CategoryDescription);
                    cmdUniversal.Parameters.Add("@CategoryId", SqlDbType.Int).Value = objCategoryModel.CategoryId;
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

        //Delete category data
        public int DeleteCategory(CategoryModel objCategoryModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_DeleteCategory", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters.Add("@CategoryId", SqlDbType.Int).Value = objCategoryModel.CategoryId;
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

        //retrive all Category data
        public DataTable GetAllCategory()
        {
            SqlConnection con = new SqlConnection(shoppingcartcon);
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetAllCategory";
                cmdUniversal.Connection = con;
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daUniversal = new SqlDataAdapter();
                daUniversal.SelectCommand = cmdUniversal;
                result = daUniversal.Fill(dt);
                con.Close();
                return dt;
            }
        }

        //retrive Category data related to CategoryID
        public DataTable GetCategoryById(CategoryModel objCategoryModel)
        {
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetCategoryById";
                cmdUniversal.Parameters.Add("@CategoryId", SqlDbType.Int).Value = objCategoryModel.CategoryId;
                cmdUniversal.Connection = con;
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daUniversal = new SqlDataAdapter();
                daUniversal.SelectCommand = cmdUniversal;
                result = daUniversal.Fill(dt);
                con.Close();
                return dt;
            }
        }
       
    }
}
