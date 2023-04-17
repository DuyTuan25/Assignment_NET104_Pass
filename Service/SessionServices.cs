using Assignment_NET104_TuanNDPH25862.Models;
using Newtonsoft.Json;

namespace Assignment_NET104_TuanNDPH25862.Service
{
	public static class SessionServices
	{
		public static User GetObjFromSession_User(ISession session, string key)
		{
			// Lấy string Json từ Session
			var JsonData = session.GetString(key);
			if (JsonData == null) return new User();

			// Chuyển đổi dữ liệu vừa lấy được từ sang dạng mong muốn
			var s = JsonConvert.DeserializeObject<User>(JsonData);
			// Nếu null thì trả về 1 list rỗng
			return s;
		}
		public static void SetObjToSession_User(ISession session, string key, object values)
		{
			var JsonData = JsonConvert.SerializeObject(values);
			session.SetString(key, JsonData);
		}
		//public static bool CheckObjInList(Guid id, List<User> nguoiDung)
		//{
		//	return nguoiDung.Any(x => x.ID == id);
		//}

		public static List<SanPhamChiTiet> GetObjFromSession_ListSP(ISession session, string key)
		{
			// Lấy string Json từ Session
			var JsonData = session.GetString(key);
			if (JsonData == null) return new List<SanPhamChiTiet>();
			// Chuyển đổi dữ liệu vừa lấy được từ sang dạng mong muốn
			var SanPhamChiTiet = JsonConvert.DeserializeObject<List<SanPhamChiTiet>>(JsonData);
			// Nếu null thì trả về 1 list rỗng
			return SanPhamChiTiet;
		}
		public static void SetObjToSession_ListSP(ISession session, string key, object values)
		{
			var JsonData = JsonConvert.SerializeObject(values);
			session.SetString(key, JsonData);
		}
		public static bool CheckObjInList_ListSP(Guid id, List<SanPhamChiTiet> SanPhamChiTiet)
		{
			return SanPhamChiTiet.Any(x => x.ID == id);
		}
	}
}
