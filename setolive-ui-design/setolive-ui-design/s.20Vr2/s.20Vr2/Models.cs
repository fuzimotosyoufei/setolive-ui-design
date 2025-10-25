using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;


namespace s._20Vr2
{
    internal class Models
    {
    }
    public class CustomerOrderInfo
    {
        public string CustomerId { get; set; }
        public string Orderdate { get; set; }
        public string CustomerName { get; set; }
        public String Phone { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public int TotalAmount {get; set;}
        public string Address { get; set; }
        public string payment { get; set; } 
  
        public String PostalCode { get; set; }

        public List<ProductInfo> Products { get; set; }
    }
    public class ProductInfo
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        // 追加項目

        public int Cost { get; set; }              // 原価
        public string Desc { get; set; }           // 商品説明
        public string Type { get; set; }           // 商品分類
        public string Supplier { get; set; }       // 発注業者名
        public bool OnSale { get; set; }           // 販売判定
        public int Alert {  get; set; }         //アラート在庫数量
    }
}
