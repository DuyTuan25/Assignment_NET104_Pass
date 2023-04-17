namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class ChatLieu
	{
		public Guid ID { get; set; }
		public string TenChatLieu { get; set; }
		public int TrangThai { get; set; }
		public virtual List<SanPhamChiTiet> SanPhamChiTiets { get; set; }
	}
}
