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
    public class CountryBAL
    {
        CountryDAL objCountryDal = new CountryDAL();
        public int InsertCountry(CountryModel objCountryModel)
        {
            return objCountryDal.InsertCountry(objCountryModel);
        }
        public int UpdateCountry(CountryModel objCountryModel)
        {
            return objCountryDal.UpdateCountry(objCountryModel);
        }
        public int DeleteCountry(CountryModel objCountryModel)
        {
            return objCountryDal.DeleteCountry(objCountryModel);
        }
        public DataTable GetAllCountry()
        {
            return objCountryDal.GetAllCountry();

        }
        public DataTable GetCountryById(CountryModel objCountryModel)
        {
            return objCountryDal.GetCountryById(objCountryModel);
        }

        public DataTable GetStateByCountryId(int CountryId)
        {
            return objCountryDal.GetStateByCountryId(CountryId);
        }

        public DataTable GetCityByStateId(int stateId)
        {
            return objCountryDal.GetCityByStateId(stateId);
        }
    }
}
