using System.Web.Mvc;

namespace WebsiteKhachSan.Areas.Manage
{
    public class ManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Manage_default",
                "Manage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
               name: "DanhSach",
               url: "danh-sach",
               defaults: new { controller = "Admin", action = "DanhSachTaiKhoan", id = UrlParameter.Optional }
           );
            context.MapRoute(
               name: "Them",
               url: "them-tk",
               defaults: new { controller = "Admin", action = "Them", id = UrlParameter.Optional }
           );
        }
    }
}