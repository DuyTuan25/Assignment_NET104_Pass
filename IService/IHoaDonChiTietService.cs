using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.IService
{
    public interface IHoaDonChiTietService
    {
        public bool CreateHoaDonChiTiet(HoaDonChiTiet p);
        public bool UpdateHoaDonChiTiet(HoaDonChiTiet p);
        public bool DeleteHoaDonChiTiet(Guid id);
        public List<HoaDonChiTiet> GetAllHoaDonChiTiets();
        public List<HoaDonChiTietView> GetAllHoaDonChiTietViews();
        public HoaDonChiTiet GetHoaDonChiTietById(Guid id);
    }
}
