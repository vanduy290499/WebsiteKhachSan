using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;


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
        public ActionResult DanhSachTaiKhoan(string search, int page = 1, int pagesize = 5)
        {
            var model = dao.DanhSachTaiKhoan(search, page, pagesize);
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
        public ActionResult Them(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoginDao();
                long id = dao.Insert(tk);
                if (id > 0)
                {
                    return RedirectToAction("DanhSachTaiKhoan","Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công!!!!!");
                }

            }
            List<Quyen> listquyen = db.Quyen.ToList();
            ViewBag.listquyen = new SelectList(listquyen, "MaQuyen", "TenQuyen");

            return View("Them");
        }
    }
}