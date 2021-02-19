using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart_Entity
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public Boolean IsActive { get; set; }
    }
}
