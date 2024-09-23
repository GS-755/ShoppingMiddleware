using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingMiddleware.Models.Flutter
{
    public class FlutterServiceDTOModel
    {
        // Flutter Service: Show Detail Product Card:
        public class FlutterDetailProductDTO
        {
            public int      IDSP    { get; set; }
            public string   MoTa    { get; set; }
            public int      GiaBan  { get; set; }
            public int      GiaMua  { get; set; }
            public int      SoLuong { get; set; }
            public string   Sodo    { get; set; }
            public string   DonVi   { get; set; }

        }

        // Flutter Service: Product card
        public class FlutterProductCartItemDTO
        {
            public int      IDSP    { get; set; }
            public string   TenSP   { get; set; }
            public string   Img_Url { get; set; }
            public int      GiaBan  { get; set; }

        }

        // Flutter Service: Login user
        public class FlutterLoginUser
        {
            public string   UserName { get; set; }
            public string   Password { get; set; }
        }

        // Flutter Service: Get Cookie
        public class FlutterCookieUser
        {
            public int      UserID { get; set; }
            public string   Token { get; set; }
        }

        public class TotalTransactions
        {
            // Growth:
            public int      totalSales     { get; set; }
            public int      totalCustomers { get; set; }
            public int      totalProduct   { get; set; }
            public float    totalRevenue   { get; set; }

        }
    }
}