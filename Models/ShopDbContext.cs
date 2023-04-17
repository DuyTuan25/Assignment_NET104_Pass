using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Data;

namespace Assignment_NET104_TuanNDPH25862.Models
{
	public class ShopDbContext : DbContext
	{
		public ShopDbContext() { }
		public ShopDbContext(DbContextOptions options) : base(options) { }
		//db set
		public DbSet<ChucVu> ChucVu { get; set; }
		public DbSet<GioHang> GioHang { get; set; }
		public DbSet<GioHangChiTiet> GioHangChiTiet { get; set; }
		public DbSet<User> NguoiDung { get; set; }
		public DbSet<HoaDon> HoaDon { get; set; }
		public DbSet<HoaDonChiTiet> HoaDonChiTiet { get; set; }
		public DbSet<ChatLieu> ChatLieu { get; set; }
		public DbSet<SanPhamChiTiet> SanPhamChiTiet { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-B4BDAQK\SQLEXPRESS;Initial Catalog=ASM_NET104_PH25862;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) // Hỗ trợ tạo Migration
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
