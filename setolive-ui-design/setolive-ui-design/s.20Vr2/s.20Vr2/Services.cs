using System;
using System.Collections.Generic;


namespace s._20Vr2
{
    public static class FallbackDataProvider
    {
        public static List<CustomerOrderInfo> GetFallbackData()
        {
            return new List<CustomerOrderInfo>
            {
                new CustomerOrderInfo
                {
                    CustomerId = "C001",
                    Orderdate = "8月2日",
                    TotalAmount = 1000,//合計金額
                    CustomerName = "佐藤 太郎",
                    Phone = "090-1234-5678",
                    Status = "新規予約",
                    Quantity = 3,
                    Address = "防府市高井",
                    PostalCode = "111",
                    payment ="電子マネー",
                    Products = new List<ProductInfo>
                    {
                        new ProductInfo { Name = "オリーブオイル", Quantity = 1 ,Amount = 600 },
                        new ProductInfo { Name = "オリーブケーキ", Quantity = 2 ,Amount = 400},

                    }
                //},
                //new CustomerOrderInfo
                //{
                //    CustomerId = "C001",
                //    Orderdate = "8月2日",
                //    TotalAmount = 1000,//合計金額
                //    CustomerName = "佐藤 太郎",
                //    Phone = "090-1234-5678",
                //    Status = "在庫不足",
                //    Quantity = 3,
                //    Address = "防府市高井",
                //    PostalCode = "111",
                //    payment ="電子マネー",
                //    Products = new List<ProductInfo>
                //    {
                //        new ProductInfo { Name = "オリーブオイル", Quantity = 1 ,Amount = 600 },
                //        new ProductInfo { Name = "オリーブケーキ", Quantity = 2 ,Amount = 400},

                //    }
                //},
                //new CustomerOrderInfo
                //{
                //    CustomerId = "C002",
                //    Orderdate = "8月2日",
                //    TotalAmount = 1000,//合計金額
                //    CustomerName = "田中 花子",
                //    Phone = "080-8765-4321",
                //    Status = "受注確定",
                //    Quantity = 5,
                //    Address = "防府市高井",
                //    PostalCode = "111",
                //    payment ="電子マネー",
                //    Products = new List<ProductInfo>
                //    {
                //        new ProductInfo { Name = "オリーブケーキ", Quantity = 5 ,Amount= 100}
                //    }
                }
            };
        }
    


    // 他に必要ならここで Services クラスを定義
        public static List<Product> GetProductMaster()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "オリーブオイル",
                    Price = 600,
                    Cost = 400,
                    Desc = "イタリア産の高品質オイル",
                    Type = "食品",
                    Supplier = "オリーブ輸入(株)",
                    OnSale = true,
                    Alert = 20
                },
            };
        }
    }
}
