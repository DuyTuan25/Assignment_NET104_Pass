using Assignment_NET104_TuanNDPH25862.IService;
using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.Service
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        ShopDbContext _context;
        public HoaDonChiTietService()
        {
            _context = new ShopDbContext();
        }
        public bool CreateHoaDonChiTiet(HoaDonChiTiet p)
        {
            try
            {
                _context.HoaDonChiTiet.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteHoaDonChiTiet(Guid id)
        {
            try
            {
                var HoaDonChiTiet = _context.HoaDonChiTiet.Find(id);
                _context.HoaDonChiTiet.Remove(HoaDonChiTiet);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<HoaDonChiTiet> GetAllHoaDonChiTiets()
        {
            return _context.HoaDonChiTiet.ToList();
        }
        public List<HoaDonChiTietView> GetAllHoaDonChiTietViews()
        {
            var lsthdctView = (from hdct in _context.HoaDonChiTiet.ToList()
                                join hd in _context.HoaDon.ToList() on hdct.IDHD equals hd.ID
                                join spct in _context.SanPhamChiTiet.ToList() on hdct.IDSPCT equals spct.ID
                                select new HoaDonChiTietView()
                                {
                                    ID = hdct.ID,
                                    IDHD = hd.ID,
                                    IDSPCT = spct.ID,
                                    MaHD = hd.MaHD,
                                    TenSanPham = spct.TenSanPham,
                                    SoLuong = hdct.SoLuong,
                                    DonGia = hdct.DonGia,
                                    ThanhTien = hdct.ThanhTien,
                                    TrangThai = hdct.TrangThai,
                                    Image = spct.Image,
                                }).ToList();
            return lsthdctView;
        }
        public HoaDonChiTiet GetHoaDonChiTietById(Guid id)
        {
            return _context.HoaDonChiTiet.FirstOrDefault(c => c.ID == id); // nhiều đối tượng thỏa mãn => lấy thằng đầu
            // return _context.HoaDonChiTiet.SingleOrDefault(c => c.Id == id); // nhiều đối tượng thỏa mãn => lỗi
        }

        public bool UpdateHoaDonChiTiet(HoaDonChiTiet p)
        {

        //public Guid IDHD { get; set; }
        //public Guid IDSPCT { get; set; }
        //public int SoLuong { get; set; }
        //public decimal DonGia { get; set; }
        //public decimal ThanhTien { get; set; }
        //public int TrangThai { get; set; }
            try
            {
                var HoaDonChiTiet = _context.HoaDonChiTiet.Find(p.ID);
                HoaDonChiTiet.IDHD = p.IDHD;
                HoaDonChiTiet.IDSPCT = p.IDSPCT;
                HoaDonChiTiet.SoLuong = p.SoLuong;
                HoaDonChiTiet.DonGia = p.DonGia;
                HoaDonChiTiet.ThanhTien = p.ThanhTien;
                HoaDonChiTiet.TrangThai = p.TrangThai;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
