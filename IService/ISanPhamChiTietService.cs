using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.IService
{
    public interface ISanPhamChiTietService
    {
        public bool CreateSanPhamChiTiet(SanPhamChiTiet p);
        public bool UpdateSanPhamChiTiet(SanPhamChiTiet p);
        public bool DeleteSanPhamChiTiet(Guid id);
        public List<SanPhamChiTiet> GetAllSanPhamChiTiets();
        public List<SanPhamChiTietView> GetAllSanPhamChiTietViews();
        public SanPhamChiTiet GetSanPhamChiTietById(Guid id);
        public List<SanPhamChiTiet> GetSanPhamChiTietByName(string name);
    }
}
