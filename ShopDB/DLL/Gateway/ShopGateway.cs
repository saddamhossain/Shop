using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDB.DLL.DAO;

namespace ShopDB.DLL.Gateway
{
    class ShopGateway
    {
        private SqlConnection connection;
        public ShopGateway()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
        }
         public string SaveProduct(Shop aShop)
         {
             connection.Open();
             string query = string.Format("INSERT INTO t_Shop VALUES ('{0}','{1}',{2})", aShop.ProductCode,aShop.Name,aShop.Qty);
             try
             {
                 SqlCommand cmd = new SqlCommand(query, connection);
                 int affectedrow = cmd.ExecuteNonQuery();
                 connection.Close();
                 if (affectedrow > 0)
                 {
                     return "product saved";
                 }
                 return "Something went wrong";
             }
             catch (SqlException)
             {

                 return "this product already in the product list";
             }
             
         }
         public List<Shop> GetAllProduct()
         {
             connection.Open();
             string query = string.Format("SELECT * FROM t_Shop");
             SqlCommand command = new SqlCommand(query, connection);
             SqlDataReader aReader = command.ExecuteReader();
             List<Shop> aShops = new List<Shop>();
             if (aReader.HasRows)
             {
                 while (aReader.Read())
                 {
                     Shop aShop=new Shop();
                     aShop.ProductCode = aReader[0].ToString();
                     aShop.Name = aReader[1].ToString();
                     aShop.Qty =(int) aReader[2];

                     aShops.Add(aShop);
                 }
             }
             connection.Close();
             return aShops;
         }

        public int GetTotalQty()
        {
            connection.Open();
            string query = string.Format("SELECT SUM(Quantity) FROM t_Shop ");
            SqlCommand cmd=new SqlCommand(query,connection);
            int sum = (int) cmd.ExecuteScalar();
            connection.Close();
            return sum;
        }


    }
}
