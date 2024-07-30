using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingMiddleware.Models.Flutter
{
    public class FlutterServiceDTOModel
    {
        // Flutter Service: Show Product Card:

        public class FlutterDetailProductDTO
        {
            public int IDSP { get; set; }
            public string MoTa { get; set; }
            public int GiaBan { get; set; }
            public int GiaMua { get; set; }
            public int SoLuong { get; set; }
            public string Sodo { get; set; }
            public string DonVi { get; set; }

        }

        public class FlutterProductCartItemDTO
        {
            public int IDSP { get; set; }
            public string TenSP { get; set; }
            public string Img_Url { get; set; }
            public int GiaBan { get; set; }

        }

        // Flutter Service: Login user
        public class FlutterLoginUser
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        // Flutter Service: Get Cookie
        public class FlutterCookieUser
        {
            public int UserID { get; set; }
            public string Token { get; set; }
        }
    }
}