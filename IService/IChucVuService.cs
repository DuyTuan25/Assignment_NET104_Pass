using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.IService
{
    public interface IChucVuService
    {
        public bool CreateChucVu(ChucVu p);
        public bool UpdateChucVu(ChucVu p);
        public bool DeleteChucVu(Guid id);
        public List<ChucVu> GetAllChucVus();
        public ChucVu GetChucVuById(Guid id);
        public List<ChucVu> GetChucVuByName(string name);
    }
}
