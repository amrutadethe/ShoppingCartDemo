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
    public class CityDAL
    {
        static string shoppingcartcon = ConfigurationSettings.AppSettings["ShoppingCart"].ToString();
        SqlConnection con = new SqlConnection(shoppingcartcon);
        SqlCommand cmdUniversal;
        //Save City
        public int InsertCity(CityModel objCityModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_InsertCity", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters["@CityName"].Value = objCityModel.CityName;
                    cmdUniversal.Parameters["@StateId"].Value = objCityModel.StateId;
                    cmdUniversal.Parameters["@IsActive"].Value = objCityModel.IsActive;
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
        //Update city 
        public int UpdateCity(CityModel objCityModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_UpdateCity", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters["@CityName"].Value = objCityModel.CityName;
                    cmdUniversal.Parameters["@IsActive"].Value = objCityModel.IsActive;
                    cmdUniversal.Parameters["@StateId"].Value = objCityModel.StateId;
                    cmdUniversal.Parameters["@CityId"].Value = objCityModel.CityId;
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
        //Delete City
        public int DeleteCity(CityModel objCityModel)
        {
            int result;
            using (con)
            {
                try
                {
                    con.Open();
                    cmdUniversal = new SqlCommand("STP_DeleteCity", con);
                    cmdUniversal.CommandType = CommandType.StoredProcedure;
                    cmdUniversal.Parameters["@CityId"].Value = objCityModel.CityId;
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
        //Retrive All Cities
        public DataTable GetAllCity()
        {
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetAllCity";
                cmdUniversal.Connection = con;
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daUniversal = new SqlDataAdapter();
                daUniversal.SelectCommand = cmdUniversal;
                con.Open();
                result = daUniversal.Fill(dt);
                con.Close();
                return dt;
            }
        }

        //Retrive City related to city id
        public DataTable GetCityById(CityModel objCityModel)
        {
            con.Open();
            DataTable dt = new DataTable();
            int result;
            using (con)
            {
                cmdUniversal = new SqlCommand();
                cmdUniversal.CommandText = "STP_GetCityById";
                cmdUniversal.Parameters.Add("@CityId", SqlDbType.Int).Value = objCityModel.CityId;
                cmdUniversal.Connection = con;
                cmdUniversal.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter daUniversal = new SqlDataAdapter();
                daUniversal.SelectCommand = cmdUniversal;
                con.Open();
                result = daUniversal.Fill(dt);
                con.Close();
                return dt;
            }
        }
    }
}
