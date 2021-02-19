using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart_Entity;
using ShoppingCart_DAL;
using System.Data;
using System.Data.SqlClient;
namespace ShoppingCart_BAL
{
    public class CityBAL
    {
        CityDAL objCityDal = new CityDAL();
        public int InsertCity(CityModel objCityModel)
        {
            return objCityDal.InsertCity(objCityModel);
        }
        public int UpdateCity(CityModel objCityModel)
        {
            return objCityDal.UpdateCity(objCityModel);
        }
        public int DeleteCity(CityModel objCityModel)
        {
            return objCityDal.DeleteCity(objCityModel);
        }
        public DataTable GetAllCity()
        {
            return objCityDal.GetAllCity();

        }
        public DataTable GetCityById(CityModel objCityModel)
        {
            return objCityDal.GetCityById(objCityModel);
        }
    }
}
