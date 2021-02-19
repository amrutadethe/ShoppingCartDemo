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
    public class CategoryBAL
    {
        CategoryDAL objCategoryDal = new CategoryDAL();
        public int InsertCategory(CategoryModel objCategoryModel)
        {
            return objCategoryDal.InsertCategory(objCategoryModel);
        }
        public int UpdateCategory(CategoryModel objCategoryModel)
        {
            return objCategoryDal.UpdateCategory(objCategoryModel);
        }
        public int DeleteCategory(CategoryModel objCategoryModel)
        {
            return objCategoryDal.DeleteCategory(objCategoryModel);
        }
        public DataTable GetAllCategory()
        {
            return objCategoryDal.GetAllCategory();

        }
        public DataTable GetCategoryById(CategoryModel objCategoryModel)
        {
            return objCategoryDal.GetCategoryById(objCategoryModel);
        }

        public DataTable CheckCategoryNameDuplication(string categoryname)
        {
            return objCategoryDal.CheckCategoryNameDuplication(categoryname);
        }
    }
}
