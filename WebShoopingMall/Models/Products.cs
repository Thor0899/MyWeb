using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebShoopingMall.Utility;

namespace WebShoopingMall.Models
{
    public class Products
    {
       
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
        public decimal OrgPrice { get; set; }
        public string Decoration { get; set; }
        public string Size { get; set; }
        public double ClickTimes { get; set; }
        public double SaleTimes { get; set; }
        public bool IsDel { get; set; }

        public static List<Products> ListAll()
        {
            List<Products> products = new List<Products>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM Products");
            foreach (DataRow dr in dt.Rows)
            {
                products.Add(dr.DtToModel<Products>());
            }
            return products;
        }
    }
}
