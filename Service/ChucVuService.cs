using Assignment_NET104_TuanNDPH25862.IService;
using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.Service
{
    public class ChucVuService : IChucVuService
    {
        ShopDbContext _context;
        public ChucVuService()
        {
            _context = new ShopDbContext();
        }
        public bool CreateChucVu(ChucVu p)
        {
            try
            {
                _context.ChucVu.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteChucVu(Guid id)
        {
            try
            {
                var ChucVu = _context.ChucVu.Find(id);
                _context.ChucVu.Remove(ChucVu);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ChucVu> GetAllChucVus()
        {
            return _context.ChucVu.ToList();
        }

        public ChucVu GetChucVuById(Guid id)
        {
            return _context.ChucVu.FirstOrDefault(c => c.ID == id); // nhiều đối tượng thỏa mãn => lấy thằng đầu
            // return _context.ChucVu.SingleOrDefault(c => c.Id == id); // nhiều đối tượng thỏa mãn => lỗi
        }

        public List<ChucVu> GetChucVuByName(string name)
        {
            return _context.ChucVu.Where(c => c.TenChucVu.Contains(name)).ToList();
            // select * from ChucVu where name like '%name%'
        }

        public bool UpdateChucVu(ChucVu p)
        {
            try
            {
                var ChucVu = _context.ChucVu.Find(p.ID);
                ChucVu.TenChucVu = p.TenChucVu;
                ChucVu.MoTa = p.MoTa;
                ChucVu.TrangThai = p.TrangThai;
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
