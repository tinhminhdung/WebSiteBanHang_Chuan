//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSiteBanHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhachHang
    {
        public KhachHang()
        {
            this.DonDatHangs = new HashSet<DonDatHang>();
        }
    
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public Nullable<int> MaThanhVien { get; set; }
    
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        public virtual ThanhVien ThanhVien { get; set; }
    }
}
