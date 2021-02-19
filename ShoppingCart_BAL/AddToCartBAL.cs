using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ShoppingCart_DAL;
using ShoppingCart_Entity;
namespace ShoppingCart_BAL
{
    public class AddToCartBAL
    {
        AddToCartDAL objAddToCartDAL = new AddToCartDAL();
        AddToCartModel objAddToCartModel = new AddToCartModel();
        public int InsertAddToCart(AddToCartModel objAddToCartModel)
        {
            return objAddToCartDAL.InsertAddToCart(objAddToCartModel);
        }

        public DataTable GetAddToCart(int productId, string user)
        {
            return objAddToCartDAL.GetAddToCart(productId,user);
        }

        public int DeleteAddToCart(string ProductId, string User)
        {
            return objAddToCartDAL.DeleteAddToCart(ProductId,User);
        }

        public DataTable GetAddToCartCount(int ProductId, string UserId)
        {
            return objAddToCartDAL.GetAddToCartCount(ProductId,UserId);
        }
    }
}
