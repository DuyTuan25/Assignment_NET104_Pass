namespace Assignment_NET104_TuanNDPH25862.Models
{
    public class HoaDonChiTietView
    {
        public Guid ID { get; set; }
        public Guid IDHD { get; set; }
        public Guid IDSPCT { get; set; }
        public string MaHD { get; set; }
        public string TenSanPham { get; set; }
        public string Image { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public int TrangThai { get; set; }
    }
}
