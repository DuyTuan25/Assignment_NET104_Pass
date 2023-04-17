namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class SanPhamChiTiet
	{
		public Guid ID { get; set; }
		public Guid IDChatLieu { get; set; }
        public string TenSanPham { get; set; }
		public int GiaBan { get; set; }
		public int SoLuongTon { get; set; }
		public string NhaCungCap { get; set; }
		public string MoTa { get; set; }
		public string Image { get; set; }
		public int TrangThai { get; set; }
		public virtual ChatLieu ChatLieu { get; set; }
		public virtual List<HoaDonChiTiet> HoaDonChiTiets { get; set; }
		public virtual List<GioHangChiTiet> GioHangChiTiets { get; set; }
	}
}
