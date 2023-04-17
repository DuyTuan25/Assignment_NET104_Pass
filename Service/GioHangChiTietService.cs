using Assignment_NET104_TuanNDPH25862.IService;
using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.Service
{
    public class GioHangChiTietService : IGioHangChiTietService
    {
        ShopDbContext _context;
        public GioHangChiTietService()
        {
            _context = new ShopDbContext();
        }
        public bool CreateGioHangChiTiet(GioHangChiTiet p)
        {
            try
            {
                _context.GioHangChiTiet.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteGioHangChiTiet(Guid id)
        {
            try
            {
                var GioHangChiTiet = _context.GioHangChiTiet.Find(id);
                _context.GioHangChiTiet.Remove(GioHangChiTiet);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GioHangChiTiet> GetAllGioHangChiTiets()
        {
            return _context.GioHangChiTiet.ToList();
        }
		public List<GioHangChiTietView> GetAllGioHangChiTietViews()
		{
			var lstGHCTViews = (from spct in _context.SanPhamChiTiet.ToList()
								join ghct in _context.GioHangChiTiet.ToList() on spct.ID equals ghct.IDSPCT
								select new GioHangChiTietView()
								{
									ID = ghct.ID,
									UserID = ghct.UserID,
									IDSPCT = spct.ID,
                                    Image = spct.Image,
									TenSanPham = spct.TenSanPham,
									SoLuong = ghct.SoLuong,
                                    DonGia = spct.GiaBan,
                                    GiaThanh = ghct.SoLuong * spct.GiaBan,
								}).ToList();
			return lstGHCTViews;
		}
		public GioHangChiTiet GetGioHangChiTietById(Guid id)
        {
            return _context.GioHangChiTiet.FirstOrDefault(c => c.ID == id); // nhiều đối tượng thỏa mãn => lấy thằng đầu
            // return _context.GioHangChiTiet.SingleOrDefault(c => c.Id == id); // nhiều đối tượng thỏa mãn => lỗi
        }

        public bool UpdateGioHangChiTiet(GioHangChiTiet p)
        {
        //public Guid ID { get; set; }
        //public Guid UserID { get; set; }
        //public Guid IDSPCT { get; set; }
        //public int SoLuong { get; set; }
            try
            {
                var GioHangChiTiet = _context.GioHangChiTiet.Find(p.ID);
                GioHangChiTiet.UserID = p.UserID;
                GioHangChiTiet.IDSPCT = p.IDSPCT;
                GioHangChiTiet.SoLuong = p.SoLuong;
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
