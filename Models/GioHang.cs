namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class GioHang
	{
        public Guid UserID { get; set; }
        public string MoTa { get; set; }
        public virtual IList<GioHangChiTiet> GioHangChiTiets { get; set; }
		public virtual User NguoiDung { get; set; }
	}
}
