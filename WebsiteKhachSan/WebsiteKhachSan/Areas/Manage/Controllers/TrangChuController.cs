using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using WebsiteKhachSan.Common;
using WebsiteKhachSan.Areas.Manage.Models;
using Model.EF;

namespace WebsiteKhachSan.Areas.Manage.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: Manage/TrangChu
        public LoginDao dao = new LoginDao();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var res = dao.Login(model.UserName, model.PassWord);
                {
                    if (res)
                    {
                        var user = dao.GetById(model.UserName);
                        var userSession = new UserLogin();
                        userSession.UserName = user.TaiKhoan1;
                        userSession.UserID = user.MaTK;
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập không đúng");
                    }
                }
            }
            return View("Index");
        }
        
    }
}