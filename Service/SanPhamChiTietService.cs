using Assignment_NET104_TuanNDPH25862.IService;
using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.Service
{
    public class SanPhamChiTietService : ISanPhamChiTietService
    {
        ShopDbContext _context;

        public SanPhamChiTietService()
        {
            _context = new ShopDbContext();
		}
        public bool CreateSanPhamChiTiet(SanPhamChiTiet p)
        {
            try
            {
                _context.SanPhamChiTiet.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSanPhamChiTiet(Guid id)
        {
            try
            {
                var SanPhamChiTiet = _context.SanPhamChiTiet.Find(id);
                _context.SanPhamChiTiet.Remove(SanPhamChiTiet);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SanPhamChiTiet> GetAllSanPhamChiTiets()
        {
            return _context.SanPhamChiTiet.ToList();
        }
		public List<SanPhamChiTietView> GetAllSanPhamChiTietViews()
		{
            var lstSPCTViews = (from spct in _context.SanPhamChiTiet.ToList()
                                join cl in _context.ChatLieu.ToList() on spct.IDChatLieu equals cl.ID
                                select new SanPhamChiTietView()
                                {
                                    ID = spct.ID,
                                    TenSanPham = spct.TenSanPham,
                                    TenChatLieu = cl.TenChatLieu,
                                    GiaBan = spct.GiaBan,
                                    SoLuongTon = spct.SoLuongTon,
                                    NhaCungCap = spct.NhaCungCap,
                                    MoTa = spct.MoTa,
                                    Image = spct.Image,
                                    TrangThai = spct.TrangThai,
                                }).OrderBy(c => c.TenSanPham).ToList();
            return lstSPCTViews;
		}
		public SanPhamChiTiet GetSanPhamChiTietById(Guid id)
        {
            return _context.SanPhamChiTiet.FirstOrDefault(c => c.ID == id); // nhiều đối tượng thỏa mãn => lấy thằng đầu
            // return _context.SanPhamChiTiet.SingleOrDefault(c => c.Id == id); // nhiều đối tượng thỏa mãn => lỗi
        }

        public List<SanPhamChiTiet> GetSanPhamChiTietByName(string name)
        {
            return _context.SanPhamChiTiet.Where(c => c.TenSanPham.Contains(name)).ToList();
            // select * from SanPhamChiTiet where name like '%name%'
        }

        public bool UpdateSanPhamChiTiet(SanPhamChiTiet p)
        {

        //public Guid IDSP { get; set; }
        //public string TenSanPham { get; set; }
        //public string ChatLieu { get; set; }
        //public decimal GiaBan { get; set; }
        //public int SoLuongTon { get; set; }
        //public string NhaCungCap { get; set; }
        //public string MoTa { get; set; }
        //public int TrangThai { get; set; }
            try
            {
                var SanPhamChiTiet = _context.SanPhamChiTiet.Find(p.ID);
                SanPhamChiTiet.TenSanPham = p.TenSanPham;
                SanPhamChiTiet.MoTa = p.MoTa;
                SanPhamChiTiet.TrangThai = p.TrangThai;
                SanPhamChiTiet.GiaBan = p.GiaBan;
                SanPhamChiTiet.SoLuongTon = p.SoLuongTon;
                SanPhamChiTiet.NhaCungCap = p.NhaCungCap;
                SanPhamChiTiet.IDChatLieu = p.IDChatLieu;
                SanPhamChiTiet.Image = p.Image;
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
