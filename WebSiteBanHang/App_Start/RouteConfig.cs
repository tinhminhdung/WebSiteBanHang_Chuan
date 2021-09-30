﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSiteBanHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Cấu hình đường dẫn trang index của controller khách hàng => khach-hang

            routes.MapRoute(
              name: "khachhang",
              url: "khach-hang",
              defaults: new { controller = "KhachHang", action = "Index", id = UrlParameter.Optional }
          );
            //Cấu hình đường dẫn trang xem chi tiết của controller sản phẩm
            routes.MapRoute(
                name: "XemChiTiet",
                url: "{tensp}-{id}",
                defaults: new { controller = "SanPham", action = "XemChiTiet", id = UrlParameter.Optional }
                       );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
          
        }
    }
}
