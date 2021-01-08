using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using WebsiteKhachSan.Common;


namespace WebsiteKhachSan.Areas.Manage.Controllers
{
    public class AdminController : Controller
    {
        public LoginDao dao = new LoginDao();
        public Model1 db = new Model1();
        // GET: Manage/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSachTaiKhoan(string searchString, int page = 1, int pagesize = 5)
        {
            var model = dao.DanhSachTaiKhoan(searchString, page, pagesize);
            ViewBag.ChuoiTimKiem = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Them()
        {
            List<Quyen> listquyen = db.Quyen.ToList();
            ViewBag.listquyen = new SelectList(listquyen, "MaQuyen", "TenQuyen");
            return View();
        }
       [HttpPost]
        public ActionResult Them(User tk)
        {
            if (ModelState.IsValid)
            {
                long id = dao.Insert(tk);
                if(id > 1)
                {
                    return RedirectToAction("DanhSachTaiKhoan", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tài khoản không thành công");
                }
            }

            List<Quyen> listquyen = db.Quyen.ToList();
            ViewBag.listquyen = new SelectList(listquyen, "MaQuyen", "TenQuyen");
            return View("Them");
        }
        [HttpGet]
        public ActionResult Sua(int id)
        {
            var user = new LoginDao().ViewDetail(id);
            List<Quyen> listquyen = db.Quyen.ToList();
            ViewBag.listquyen = new SelectList(listquyen, "MaQuyen", "TenQuyen");
            return View(user);
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "TrangChu");
        }
    }
}