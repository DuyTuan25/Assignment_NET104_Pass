using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.IService
{
    public interface IChatLieuService
    {
        public bool CreateChatLieu(ChatLieu p);
        public bool UpdateChatLieu(ChatLieu p);
        public bool DeleteChatLieu(Guid id);
        public List<ChatLieu> GetAllChatLieus();
        public ChatLieu GetChatLieuById(Guid id);
        public List<ChatLieu> GetChatLieuByName(string name);
    }
}
