using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDB.DLL.DAO;
using ShopDB.DLL.Gateway;

namespace ShopDB.BLL
{
    class ShopBll
    {
        private ShopGateway aShopGateway;
        
        public string SaveProduct(Shop asShop)
        {
            
            if (asShop.Name==string.Empty||asShop.ProductCode==string.Empty)
            {
                return "please fill all field";
            }
            else
            {
                return ProductNameIsValid(asShop);
            }
            
        }

        private string ProductNameIsValid(Shop aaShop)
        {
            string msg10 = "please enter at least three digit for product code and 5-10 charecter for product name";
            aShopGateway = new ShopGateway();
            int length = (aaShop.ProductCode).Length;
            if (length==3)
            {
                if (length >= 5)
                {
                    if (length >= 10)
                    {
                        return aShopGateway.SaveProduct(aaShop);

                    }
                }
                
            }
            return msg10;
        }
        public List<Shop> GetAllProduct()
        {
            ShopGateway asShopGateway=new ShopGateway();
            return asShopGateway.GetAllProduct();
        }

        public int GetTotalQty()
        {
            aShopGateway=new ShopGateway();
            
            int totalQty = 0;
            
            totalQty = aShopGateway.GetTotalQty();
            
            return totalQty;
        }

    }
}
