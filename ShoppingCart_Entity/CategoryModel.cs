using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart_Entity
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Boolean IsActive { get; set; }
        public string CategoryImage { get; set; }
        public string CategoryDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
