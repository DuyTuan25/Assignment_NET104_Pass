using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.IService
{
    public interface IGioHangChiTietService
    {
        public bool CreateGioHangChiTiet(GioHangChiTiet p);
        public bool UpdateGioHangChiTiet(GioHangChiTiet p);
        public bool DeleteGioHangChiTiet(Guid id);
        public List<GioHangChiTiet> GetAllGioHangChiTiets();
        public List<GioHangChiTietView> GetAllGioHangChiTietViews();
        public GioHangChiTiet GetGioHangChiTietById(Guid id);
    }
}
