namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class GioHangChiTiet
	{
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid IDSPCT { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public GioHang GioHang { get; set; }
        public virtual SanPhamChiTiet SanPhamChiTiet { get; set; }
    }
}
