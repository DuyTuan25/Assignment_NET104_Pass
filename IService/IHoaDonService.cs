using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.IService
{
    public interface IHoaDonService
    {
        public bool CreateHoaDon(HoaDon p);
        public bool UpdateHoaDon(HoaDon p);
        public bool DeleteHoaDon(Guid id);
        public List<HoaDon> GetAllHoaDons();
        public HoaDon GetHoaDonById(Guid id);
    }
}
