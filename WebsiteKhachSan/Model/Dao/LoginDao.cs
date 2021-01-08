using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using PagedList.Mvc;

namespace Model.Dao
{
    public class LoginDao
    {
        Model1 db = null;
        public LoginDao()
        {
            db = new Model1();
        }
        public long Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.MaTK;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.MaTK);
                user.HoTen = user.HoTen;
                user.NgaySinh = user.NgaySinh;
                user.Quyen = user.Quyen;
                user.GioiTinh = user.GioiTinh;
                user.TrangThai = user.TrangThai;
                return true;
            }
            catch
            {
                return false;
            }

        }
        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }
        public IEnumerable<Quyen> ListAllMonHoc(int page, int pagesize)
        {
            return db.Quyen.OrderBy(x => x.Maquyen).ToPagedList(page, pagesize);
        }
        public IEnumerable<User> DanhSachTaiKhoan(string searchString, int page, int pagesize)
        {
            IQueryable<User> model = db.User;
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.HoTen.Contains(searchString));
               
            }
            return db.User.OrderByDescending(x => x.MaTK).ToPagedList(page, pagesize);
        }
        public User GetById(string userName)
        {
            return db.User.SingleOrDefault(x => x.TaiKhoan == userName);
        }
        public bool Login(String Username, String Password)
        {
            var res = db.User.Count(x => x.TaiKhoan == Username && x.MatKhau == Password);
            if(res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}
