using Assignment_NET104_TuanNDPH25862.IService;
using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.Service
{
    public class ChatLieuService : IChatLieuService
    {
        ShopDbContext _context;
        public ChatLieuService()
        {
            _context = new ShopDbContext();
        }
        public bool CreateChatLieu(ChatLieu p)
        {
            try
            {
                _context.ChatLieu.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteChatLieu(Guid id)
        {
            try
            {
                var ChatLieu = _context.ChatLieu.Find(id);
                _context.ChatLieu.Remove(ChatLieu);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ChatLieu> GetAllChatLieus()
        {
            return _context.ChatLieu.ToList();
        }

        public ChatLieu GetChatLieuById(Guid id)
        {
            return _context.ChatLieu.FirstOrDefault(c => c.ID == id); // nhiều đối tượng thỏa mãn => lấy thằng đầu
            // return _context.ChatLieu.SingleOrDefault(c => c.Id == id); // nhiều đối tượng thỏa mãn => lỗi
        }

        public List<ChatLieu> GetChatLieuByName(string name)
        {
            return _context.ChatLieu.Where(c => c.TenChatLieu.Contains(name)).ToList();
            // select * from ChatLieu where name like '%name%'
        }

        public bool UpdateChatLieu(ChatLieu p)
        {
            try
            {
                var ChatLieu = _context.ChatLieu.Find(p.ID);
                ChatLieu.TenChatLieu = p.TenChatLieu;
                ChatLieu.TrangThai = p.TrangThai;
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
