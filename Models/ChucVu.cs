namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class ChucVu
	{
        public Guid ID { get; set; }
        public string TenChucVu { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
		public virtual List<User> NguoiDungs { get; set; }
	}
}
