namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class User
	{
		public Guid ID { get; set; }
		public string TenNguoiDung { get; set; }
		public Guid IDCV { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public int TrangThai { get; set; }
		public virtual GioHang GioHang { get; set; }
		public virtual ChucVu ChucVu { get; set; }
		public virtual List<HoaDon> HoaDons { get; set; }
	}
}
