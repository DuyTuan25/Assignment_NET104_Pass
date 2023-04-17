using Assignment_NET104_TuanNDPH25862.IService;
using Assignment_NET104_TuanNDPH25862.Models;

namespace Assignment_NET104_TuanNDPH25862.Service
{
    public class HoaDonService : IHoaDonService
	{
		ShopDbContext _context;
		public HoaDonService()
		{
			_context = new ShopDbContext();
		}
		public bool CreateHoaDon(HoaDon p)
		{
			try
			{
				_context.HoaDon.Add(p);
				_context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool DeleteHoaDon(Guid id)
		{
			try
			{
				var HoaDon = _context.HoaDon.Find(id);
				_context.HoaDon.Remove(HoaDon);
				_context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public List<HoaDon> GetAllHoaDons()
		{
			return _context.HoaDon.ToList();
		}

		public HoaDon GetHoaDonById(Guid id)
		{
			return _context.HoaDon.FirstOrDefault(c => c.ID == id); // nhiều đối tượng thỏa mãn => lấy thằng đầu
																	  // return _context.HoaDon.SingleOrDefault(c => c.Id == id); // nhiều đối tượng thỏa mãn => lỗi
		}

		public bool UpdateHoaDon(HoaDon p)
		{
			try
			{
				var HoaDon = _context.HoaDon.Find(p.ID);
				HoaDon.DiaChi = p.DiaChi;
				HoaDon.SoDienThoai = p.SoDienThoai;
				HoaDon.TenNguoiNhan = p.TenNguoiNhan;
				HoaDon.TongTien = p.TongTien;
				HoaDon.GhiChu = p.GhiChu;
				HoaDon.TrangThai = p.TrangThai;
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
