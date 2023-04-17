namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class HoaDonChiTiet
	{
		public Guid ID { get; set; }
		public Guid IDHD { get; set; }
		public Guid IDSPCT { get; set; }
		public int SoLuong { get; set; }
		public decimal DonGia { get; set; }
		public decimal ThanhTien { get; set; }
		public int TrangThai { get; set; }
		public virtual HoaDon HoaDon { get; set; }
		public virtual SanPhamChiTiet SanPhamChiTiet { get; set; }
	}
}
