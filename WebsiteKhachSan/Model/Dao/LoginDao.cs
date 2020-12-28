using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

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
