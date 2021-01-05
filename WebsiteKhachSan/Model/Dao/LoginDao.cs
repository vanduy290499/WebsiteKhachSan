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
        public long Insert(TaiKhoan entity)
        {
            db.TaiKhoan.Add(entity);
            db.SaveChanges();
            return entity.MaTK;
        }
        public IEnumerable<Quyen> ListAllMonHoc(int page, int pagesize)
        {
            return db.Quyen.OrderBy(x => x.Maquyen).ToPagedList(page, pagesize);
        }
        public IEnumerable<TaiKhoan> DanhSachTaiKhoan(string search,int page, int pagesize)
        {
            IQueryable<TaiKhoan> model = db.TaiKhoan;
            if (!String.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.TaiKhoan1.Contains(search) || x.HoTen.Contains(search));
               
            }
            return db.TaiKhoan.OrderBy(x => x.HoTen).ToPagedList(page, pagesize);
        }
        public TaiKhoan GetById(string userName)
        {
            return db.TaiKhoan.SingleOrDefault(x => x.TaiKhoan1 == userName);
        }
        public bool Login(String Username, String Password)
        {
            var res = db.TaiKhoan.Count(x => x.TaiKhoan1 == Username && x.MatKhau == Password);
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
