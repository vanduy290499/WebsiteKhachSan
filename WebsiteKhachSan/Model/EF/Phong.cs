namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            DanhGia = new HashSet<DanhGia>();
            DatPhong = new HashSet<DatPhong>();
        }

        [Key]
        public int MaPhong { get; set; }

        public string TenPhong { get; set; }

        public string HinhAnh { get; set; }

        public int? Gia { get; set; }

        public string MoTa { get; set; }

        public string TrangThai { get; set; }

        public int? MaKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatPhong> DatPhong { get; set; }

        public virtual KhachSan KhachSan { get; set; }
    }
}
