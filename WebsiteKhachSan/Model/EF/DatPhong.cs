namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatPhong")]
    public partial class DatPhong
    {
        [Key]
        public int MaDP { get; set; }

        public int? MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDi { get; set; }

        public int? MaKH { get; set; }

        public int? MaDV { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual Khachhang Khachhang { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
