using Assignment_NET104_TuanNDPH25862.IService;
using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.Service
{
    public class NguoiDungService : INguoiDungService
    {
        ShopDbContext _context;
        public NguoiDungService()
        {
            _context = new ShopDbContext();
        }
        public bool CreateNguoiDung(User p)
        {
            try
            {
                _context.NguoiDung.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteNguoiDung(Guid id)
        {
            try
            {
                var NguoiDung = _context.NguoiDung.Find(id);
                _context.NguoiDung.Remove(NguoiDung);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllNguoiDung()
        {
            return _context.NguoiDung.ToList();
        }

        public User GetNguoiDungById(Guid id)
        {
            return _context.NguoiDung.FirstOrDefault(c => c.ID == id); // nhiều đối tượng thỏa mãn => lấy thằng đầu
            // return _context.NguoiDung.SingleOrDefault(c => c.Id == id); // nhiều đối tượng thỏa mãn => lỗi
        }

        public List<User> GetNguoiDungByName(string name)
        {
            return _context.NguoiDung.Where(c => c.TenNguoiDung.Contains(name)).ToList();
            // select * from NguoiDung where name like '%name%'
        }

        public bool UpdateNguoiDung(User p)
        {

        //public string TenNguoiDung { get; set; }
        //public Guid IDCV { get; set; }
        //public string MatKhau { get; set; }
        //public string HoTen { get; set; }
        //public int TrangThai { get; set; }
            try
            {
                var NguoiDung = _context.NguoiDung.Find(p.ID);
                NguoiDung.TenNguoiDung = p.TenNguoiDung;
                NguoiDung.IDCV = p.IDCV;
                NguoiDung.TrangThai = p.TrangThai;
                NguoiDung.MatKhau = p.MatKhau;
                NguoiDung.HoTen = p.HoTen;
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
