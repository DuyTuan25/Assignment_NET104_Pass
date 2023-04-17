namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class HoaDon
	{
        public Guid ID { get; set; }
        public DateTime NgayTao { get; set; }
        public string DiaChi { get; set; }
        public Guid IDNguoiDung { get; set; }
        public string MaHD { get; set; }
        public string TenNguoiNhan { get; set; }
		public string SoDienThoai { get; set; }
		public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }
        public virtual IEnumerable<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual User NguoiDung { get; set; }
    }
}
