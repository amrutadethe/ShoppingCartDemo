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
    public class CountryDAL
    {
        #region

        static string shoppingcartcon = ConfigurationSettings.AppSettings["ShoppingCart"].ToString();
        SqlConnection con = new SqlConnection(shoppingcartcon);
        SqlCommand cmdUniversal;
        #endregion
        //Save Country
        public int InsertCountry(CountryModel objCountryModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_InsertCountry", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters["@CountryName"].Value = objCountryModel.CountryName;
                    cmdUniversal.Parameters["@IsActive"].Value = objCountryModel.IsActive;
                    cmdUniversal.Parameters["@Id"].Direction = ParameterDirection.Output;
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

       

        //Update Country
        public int UpdateCountry(CountryModel objCountryModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_UpdateCountry", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters["@CountryName"].Value = objCountryModel.CountryName;
                    cmdUniversal.Parameters["@IsActive"].Value = objCountryModel.IsActive;
                    cmdUniversal.Parameters["@CountryId"].Value = objCountryModel.CountryId;
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
        //delete Country
        public int DeleteCountry(CountryModel objCountryModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_DeleteCountry", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters["@CountryId"].Value = objCountryModel.CountryId;
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

        //Retrive All countries
        public DataTable GetAllCountry()
        {
            SqlConnection con = new SqlConnection(shoppingcartcon);
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetAllCountries";
                cmdUniversal.Connection = con;
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daUniversal = new SqlDataAdapter();
                daUniversal.SelectCommand = cmdUniversal;
                result = daUniversal.Fill(dt);
                con.Close();
                
                return dt;
            }
        }

        //Retrive Country related to Country Id
        public DataTable GetCountryById(CountryModel objCountryModel)
        {
            SqlConnection con = new SqlConnection(shoppingcartcon);
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetCountryById";
                cmdUniversal.Parameters.Add("@CountryId", SqlDbType.Int).Value = objCountryModel.CountryId;
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
        /// Get State related to Country
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public DataTable GetStateByCountryId(int countryId)
        {
            SqlConnection con = new SqlConnection(shoppingcartcon);
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetStateByCountryId";
                cmdUniversal.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;
                cmdUniversal.Connection = con;
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daUniversal = new SqlDataAdapter();
                daUniversal.SelectCommand = cmdUniversal;
                result = daUniversal.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable GetCityByStateId(int stateId)
        {
            SqlConnection con = new SqlConnection(shoppingcartcon);
           
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetCityByStateId";
                cmdUniversal.Parameters.Add("@StateId", SqlDbType.Int).Value = stateId;
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
