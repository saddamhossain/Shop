using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB.DLL.DAO
{
    class Shop
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }

        public Shop (string productCode,string name,int qty):this()
        {
            ProductCode = productCode;
            Name = name;
            Qty = qty;
        }

        public Shop()
        {
        }



    }
}
