namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            DatPhong = new HashSet<DatPhong>();
        }

        [Key]
        public int MaDV { get; set; }

        public string TenDV { get; set; }

        public int? MaKS { get; set; }

        public int? GiaDV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatPhong> DatPhong { get; set; }

        public virtual KhachSan KhachSan { get; set; }
    }
}
