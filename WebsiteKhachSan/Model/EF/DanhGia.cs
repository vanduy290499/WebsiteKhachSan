namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        [Key]
        public int MaDG { get; set; }

        public int? MaKH { get; set; }

        public int? MaPhong { get; set; }

        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDG { get; set; }

        public virtual Khachhang Khachhang { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
