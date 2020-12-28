namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DatPhong> DatPhong { get; set; }
        public virtual DbSet<DichVu> DichVu { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<KhachSan> KhachSan { get; set; }
        public virtual DbSet<Phong> Phong { get; set; }
        public virtual DbSet<Quyen> Quyen { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khachhang>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.Tenquyen)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TaiKhoan1)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
