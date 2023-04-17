using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.IService
{
    public interface IGioHangService
    {
        public bool CreateGioHang(GioHang p);
        public bool UpdateGioHang(GioHang p);
        public bool DeleteGioHang(Guid id);
        public List<GioHang> GetAllGioHangs();
        public GioHang GetGioHangById(Guid id);
        public List<GioHang> GetGioHangByName(string name);
    }
}
