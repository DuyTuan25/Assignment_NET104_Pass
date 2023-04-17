namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class GioHangChiTietView
	{
		public Guid ID { get; set; }
		public Guid UserID { get; set; }
		public string TenNguoiDung { get; set; }
		public Guid IDSPCT { get; set; }
		public string TenSanPham { get; set; }
		public string Image { get; set; }
		public int SoLuong { get; set; }
		public int DonGia { get; set; }
        public int GiaThanh { get; set; }
    }
}
