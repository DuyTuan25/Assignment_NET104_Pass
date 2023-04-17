using Assignment_NET104_TuanNDPH25862.IService;
using Assignment_NET104_TuanNDPH25862.Models;
using Assignment_NET104_TuanNDPH25862.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Assignment_NET104_TuanNDPH25862.Controllers
{
	public class HomeController : Controller
	{
		private readonly ISanPhamChiTietService _sanPhamChiTietService;
		private readonly ILogger<HomeController> _logger;
		private readonly IChatLieuService _chatLieuService;
		private readonly IGioHangChiTietService _igioHangChiTietService;
		private readonly IHoaDonService _iHoaDonService;
		private readonly IHoaDonChiTietService _iHoaDonChiTietService;
		private readonly INguoiDungService _iNguoiDungService;
		private readonly IChucVuService _iChucVuService;
		private List<string> _lstcl;
		private List<User> _lstNguoiDung;
		private List<SanPhamChiTiet> _lstspct;
		private int TongTien = 0;
		Regex regex = new Regex("^[a-zA-Z0-9]+$");
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			_sanPhamChiTietService = new SanPhamChiTietService();
			_chatLieuService = new ChatLieuService();
			_igioHangChiTietService = new GioHangChiTietService();
			_iHoaDonService = new HoaDonService();
			_iHoaDonChiTietService = new HoaDonChiTietService();
			_iNguoiDungService = new NguoiDungService();
			_iChucVuService = new ChucVuService();
			_lstNguoiDung = new List<User>();
			// list chất liệu
			_lstcl = new List<string>();
			foreach (var chatLieu in _chatLieuService.GetAllChatLieus())
			{
				_lstcl.Add(chatLieu.TenChatLieu.ToString());
			}


		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult DangXuat()
		{
			return RedirectToAction("DangNhap");
		}
		public ActionResult DangNhap(string user, string password)
		{
			//if (user == null || password == null || user.Length < 6 || password.Length < 6)
			//{
			//	ViewBag.ThongBao = "Tên đăng nhập và mật khẩu phải lớn hơn 6";
			//	return View();
			//}
			//if (!regex.IsMatch(user) || !regex.IsMatch(password))
			//{
			//	ViewBag.ThongBao = "Tên đăng nhập và mật khẩu không được chứa kí tự đặc biệt";
			//	return View();
			//}
			if (user == null || password == null)
			{
				return View();
			}
			else
			{
				User nguoiDung = _iNguoiDungService.GetAllNguoiDung().FirstOrDefault(x => x.TenNguoiDung.Trim() == user.Trim() && x.MatKhau.Trim() == password.Trim());
				if (nguoiDung != null)
				{
					User s = SessionServices.GetObjFromSession_User(HttpContext.Session, "loadTen");
					s = nguoiDung;
					SessionServices.SetObjToSession_User(HttpContext.Session, "loadTen", s);
					return RedirectToAction("Index");
				}
				else return View();
			}
		}
		//[HttpPost]
		//public IActionResult DangNhapNew(string ten, string mk)
		//{
		//	if (ten == null || mk == null|| ten.Length < 6 || mk.Length < 6)
		//	{
		//		ViewBag.ThongBao = "Tên đăng nhập và mật khẩu phải lớn hơn 6 kí tự";
		//		return View();
		//	}
		//	if(!regex.IsMatch(ten) || !regex.IsMatch(mk)) {
		//		ViewBag.ThongBao = "Tên đăng nhập và mật khẩu không được chứa kí tự đặc biệt";
		//		return View();
		//	}
		//	else
		//	{
		//		User nguoiDung = _iNguoiDungService.GetAllNguoiDung().FirstOrDefault(x => x.TenNguoiDung.Trim() == ten.Trim() && x.MatKhau.Trim() == mk.Trim());
		//		if (nguoiDung != null)
		//		{
		//			User s = SessionServices.GetObjFromSession_User(HttpContext.Session, "loadTen");
		//			s = nguoiDung;
		//			SessionServices.SetObjToSession_User(HttpContext.Session, "loadTen", s);
		//			return RedirectToAction("Index");
		//		}
		//		else return View();
		//	}
		//}
		//public IActionResult DangNhapNew()
		//{
		//	 return View();
		//}
		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult ShowSP()
		{
			return View(_sanPhamChiTietService.GetAllSanPhamChiTietViews());
		}
		[HttpPost]
		public IActionResult SanPham(int giamin, int giamax)
		{
			if (giamin != null && giamax != null)
			{
				return View(_sanPhamChiTietService.GetAllSanPhamChiTietViews().Where(c => c.GiaBan < giamax && c.GiaBan > giamin));
			}
			else return View();
		}
		public IActionResult SanPham()
		{
			return View(_sanPhamChiTietService.GetAllSanPhamChiTietViews());
		}
		public IActionResult HoaDon()
		{
			return View(_iHoaDonService.GetAllHoaDons().OrderByDescending(c => c.MaHD));
		}
		public IActionResult HoaDonChiTiet(Guid ID)
		{
			var x = _iHoaDonChiTietService.GetAllHoaDonChiTietViews().Where(c => c.IDHD == ID).ToList();
			ViewBag.MaHD = _iHoaDonService.GetAllHoaDons().FirstOrDefault(c => c.ID == ID).MaHD;
			ViewBag.TongTienHDCT = _iHoaDonService.GetHoaDonById(ID).TongTien;
			return View(x);
		}
		public IActionResult GioHangChiTiet()
		{
			string JsonData = HttpContext.Session.GetString("loadTen"); // Lấy data từ Session
			var NguoiDung = JsonConvert.DeserializeObject<User>(JsonData);
			foreach (var tien in _igioHangChiTietService.GetAllGioHangChiTietViews().Where(c => c.UserID == NguoiDung.ID))
			{
				TongTien = TongTien + tien.GiaThanh;
			}
			ViewBag.TongTien = TongTien;
			HoaDon x = new HoaDon();
			return View(_igioHangChiTietService.GetAllGioHangChiTietViews().Where(c => c.UserID == NguoiDung.ID));
		}
		[HttpPost]
		public IActionResult AddToGioHang(GioHangChiTiet ghct, Guid IDSPCT, int SoLuong)
		{
			string JsonData = HttpContext.Session.GetString("loadTen"); // Lấy data từ Session
			var NguoiDung = JsonConvert.DeserializeObject<User>(JsonData);
			if (_igioHangChiTietService.GetAllGioHangChiTiets().Where(c => c.UserID == NguoiDung.ID).Any(c => c.IDSPCT == IDSPCT))
			{
				var SPupdate = _igioHangChiTietService.GetAllGioHangChiTiets().FirstOrDefault(c => c.IDSPCT == IDSPCT);
				SPupdate.SoLuong = SPupdate.SoLuong + SoLuong;
				_igioHangChiTietService.UpdateGioHangChiTiet(SPupdate);
				RedirectToAction("GioHangChiTiet");
			}
			else if (!_igioHangChiTietService.GetAllGioHangChiTiets().Where(c => c.UserID == NguoiDung.ID).Any(c => c.ID == IDSPCT))
			{
				ghct.ID = Guid.NewGuid();
				ghct.UserID = NguoiDung.ID;
				ghct.IDSPCT = IDSPCT;
				ghct.SoLuong = SoLuong;
				ghct.DonGia = _sanPhamChiTietService.GetAllSanPhamChiTiets().FirstOrDefault(c => c.ID == IDSPCT).GiaBan;
				if (_igioHangChiTietService.CreateGioHangChiTiet(ghct)) return RedirectToAction("GioHangChiTiet");
				else return BadRequest();
			}
			return RedirectToAction("GioHangChiTiet");
		}
		public IActionResult Details(Guid id)
		{
			ShopDbContext db = new ShopDbContext();
			var x = db.SanPhamChiTiet.Find(id);
			return View(x);
		}
		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			// Láy Product từ db dựa theo ID truyền vào từ route
			ViewBag.TenChatLieu = _lstcl;
			SanPhamChiTiet p = _sanPhamChiTietService.GetSanPhamChiTietById(id);
			return View(p);
		}
		public IActionResult Edit(SanPhamChiTiet p, [Bind] IFormFile imageFile)
		{
			SanPhamChiTiet spct = _sanPhamChiTietService.GetAllSanPhamChiTiets().FirstOrDefault(c => c.TenSanPham.Trim().ToLower() == p.TenSanPham.Trim().ToLower() && c.ID != p.ID);
			//var x = spct.TenSanPham;
			if (spct != null)
			{
				ViewBag.TenChatLieu = _lstcl;
				ViewBag.TrungTen = "Tên đã tồn tại";
				return View(spct);
			}
			// Dòng này dùng để Debug
			if (imageFile != null && imageFile.Length > 0)
			{
				// Trỏ tới thư mục wwwroot để lát nữa thực hiện việc copy sang
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
				using (var stream = new FileStream(path, FileMode.Create))
				{
					// Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
					imageFile.CopyTo(stream);
				}
				// Gán lại giá trị cho Image của đối tượng bằng tên file ảnh đã được sao chép
				p.Image = imageFile.FileName;
			}
			else
			{
				p.Image = _sanPhamChiTietService.GetSanPhamChiTietById(p.ID).Image;
			}
			//var y = _sanPhamChiTietService.GetSanPhamChiTietById(p.ID);
			//if (y.GiaBan < p.GiaBan) return Content("Giá mới phải thấp hơn giá cũ");
			if (p.SoLuongTon > 0) p.TrangThai = 0;
			else if (p.SoLuongTon == 0) p.TrangThai = 1;
			if (_sanPhamChiTietService.UpdateSanPhamChiTiet(p)) return RedirectToAction("ShowSP");
			else return BadRequest();
		}

		[HttpPost]
		public IActionResult Create(SanPhamChiTiet p, [Bind] IFormFile imageFile)
		{
			//p.IDChatLieu = _chatLieuService.GetAllChatLieus().FirstOrDefault(c=>c.TenChatLieu == p.te).ID;
			//var x = imageFile.FileName; // Dòng này dùng để Debug
			SanPhamChiTiet spct = _sanPhamChiTietService.GetAllSanPhamChiTiets().FirstOrDefault(c => c.TenSanPham.Trim().ToLower() == p.TenSanPham.Trim().ToLower());
			//var x = spct.TenSanPham;
			if (spct != null)
			{
				ViewBag.TenChatLieu = _lstcl;
				ViewBag.TrungTen = "Tên đã tồn tại";
				return View();
			}
			if (imageFile != null && imageFile.Length > 0)
			{
				// Trỏ tới thư mục wwwroot để lát nữa thực hiện việc copy sang
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
				using (var stream = new FileStream(path, FileMode.Create))
				{
					// Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
					imageFile.CopyTo(stream);
				}
				// Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã đưuọc sao chép
				p.Image = imageFile.FileName;
			}
			else if (imageFile == null)
			{
				p.Image = string.Empty;
			}
			if (p.SoLuongTon > 0) p.TrangThai = 0;
			else if (p.SoLuongTon == 0) p.TrangThai = 1;
			if (_sanPhamChiTietService.CreateSanPhamChiTiet(p)) return RedirectToAction("ShowSP");
			else return BadRequest();
		}
		public IActionResult Create()
		{
			ViewBag.TenChatLieu = _lstcl;
			return View();
		}
		public IActionResult Delete(Guid id)
		{
			//var x = _sanPhamChiTietService.GetSanPhamChiTietById(id);
			//x.TrangThai = 2;
			//if (_sanPhamChiTietService.UpdateSanPhamChiTiet(x))
			//{
			//	return RedirectToAction("ShowSP");
			//}
			//else return View("Index");
			SanPhamChiTiet p = _sanPhamChiTietService.GetSanPhamChiTietById(id);
			_lstspct = SessionServices.GetObjFromSession_ListSP(HttpContext.Session, "oldData");
			if (SessionServices.CheckObjInList_ListSP(id, _lstspct))
			{
				_lstspct.Remove(_lstspct.FirstOrDefault(c => c.ID == id));
				_lstspct.Add(p);
				SessionServices.SetObjToSession_ListSP(HttpContext.Session, "oldData", _lstspct);
			}
			else
			{
				_lstspct.Add(p); // Nếu ko có sp nào thì add nó vào
								 // Sau đó gán lại giá trị vào trong Session
				SessionServices.SetObjToSession_ListSP(HttpContext.Session, "oldData", _lstspct);
			}
			if (_sanPhamChiTietService.DeleteSanPhamChiTiet(id))
			{
				return RedirectToAction("ShowSP");
			}
			else return View("Index");
		}
		public IActionResult DataDelete()
		{
			string JsonData = HttpContext.Session.GetString("oldData"); // Lấy data từ Session
			if (JsonData == null)
			{
				return Content("Session đã bị xóa");
			}
			var SanPhamChiTiet = JsonConvert.DeserializeObject<List<SanPhamChiTiet>>(JsonData);
			return View(SanPhamChiTiet);
		}
		public IActionResult RollBack(Guid id)
		{
			string JsonData = HttpContext.Session.GetString("oldData");
			var products = JsonConvert.DeserializeObject<List<SanPhamChiTiet>>(JsonData);
			_sanPhamChiTietService.CreateSanPhamChiTiet(products.FirstOrDefault(c => c.ID == id));
			// Xoa doi tuong vua rollback khoi session
			_lstspct = SessionServices.GetObjFromSession_ListSP(HttpContext.Session, "oldData");
			_lstspct.Remove(_lstspct.FirstOrDefault(c => c.ID == id));
			SessionServices.SetObjToSession_ListSP(HttpContext.Session, "oldData", _lstspct);
			return RedirectToAction("ShowSP");
		}
		public IActionResult DeleteFromCart(Guid id)
		{
			if (_igioHangChiTietService.DeleteGioHangChiTiet(id)) return RedirectToAction("GioHangChiTiet");
			else return View("Index");
		}
		public IActionResult AddHoaDon_ThanhToan(string TenNguoiNhan, string SoDienThoai, string Tinh_TP, string Quan_Huyen_TX, string Xa_Phuong_TT, string SoNha, string GhiChu)
		{
			string JsonData = HttpContext.Session.GetString("loadTen"); // Lấy data từ Session
			var NguoiDung = JsonConvert.DeserializeObject<User>(JsonData);
			HoaDon hd = new HoaDon();
			HoaDonChiTiet hdct = new HoaDonChiTiet();
			SanPhamChiTiet spct = new SanPhamChiTiet();
			var idHD = Guid.NewGuid();
			hd.ID = idHD;
			hd.NgayTao = DateTime.Now;
			hd.IDNguoiDung = NguoiDung.ID;
			if (_iHoaDonService.GetAllHoaDons().Any())
			{
				hd.MaHD = "HD" + _iHoaDonService.GetAllHoaDons().Max(c => Convert.ToInt32(c.MaHD.Substring(2)) + 1).ToString();
			}
			else
			{
				hd.MaHD = "HD1";
			}
			hd.TenNguoiNhan = TenNguoiNhan;
			hd.SoDienThoai = SoDienThoai;
			foreach (var tien in _igioHangChiTietService.GetAllGioHangChiTietViews().Where(c => c.UserID == NguoiDung.ID))
			{
				hd.TongTien = hd.TongTien + tien.GiaThanh;
			}
			hd.GhiChu = GhiChu + "";
			hd.DiaChi = SoNha + ", " + Xa_Phuong_TT + ", " + Quan_Huyen_TX + ", " + Tinh_TP;
			hd.TrangThai = 1;
			_iHoaDonService.CreateHoaDon(hd);
			foreach (var x in _igioHangChiTietService.GetAllGioHangChiTietViews().Where(c => c.UserID == NguoiDung.ID))
			{
				hdct.ID = Guid.NewGuid();
				hdct.IDHD = idHD;
				hdct.IDSPCT = x.IDSPCT;
				hdct.SoLuong = x.SoLuong;
				hdct.DonGia = x.DonGia;
				hdct.ThanhTien = x.GiaThanh;
				hdct.TrangThai = 1;
				_iHoaDonChiTietService.CreateHoaDonChiTiet(hdct);
				_igioHangChiTietService.DeleteGioHangChiTiet(x.ID);
				spct = _sanPhamChiTietService.GetSanPhamChiTietById(x.IDSPCT);
				spct.SoLuongTon = spct.SoLuongTon - x.SoLuong;
				if (spct.SoLuongTon == 0) spct.TrangThai = 0;
				_sanPhamChiTietService.UpdateSanPhamChiTiet(spct);
			}
			return RedirectToAction("ShowSP");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}