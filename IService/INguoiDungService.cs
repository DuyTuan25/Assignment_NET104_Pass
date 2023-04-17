using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.IService
{
    public interface INguoiDungService
    {
        public bool CreateNguoiDung(User p);
        public bool UpdateNguoiDung(User p);
        public bool DeleteNguoiDung(Guid id);
        public List<User> GetAllNguoiDung();
        public User GetNguoiDungById(Guid id);
        public List<User> GetNguoiDungByName(string name);
    }
}
