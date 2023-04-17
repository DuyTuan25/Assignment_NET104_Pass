using Assignment_NET104_TuanNDPH25862.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104_TuanNDPH25862.Configurations
{
	public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
	{
		public void Configure(EntityTypeBuilder<HoaDon> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.NgayTao).HasColumnType("Datetime");
			builder.Property(x => x.DiaChi).HasColumnType("nvarchar(1000)");
			builder.Property(x => x.MaHD).HasColumnType("nvarchar(10)");
			builder.Property(x => x.SoDienThoai).HasColumnType("nvarchar(15)");
			builder.Property(x => x.TenNguoiNhan).HasColumnType("nvarchar(100)");
			builder.Property(x => x.GhiChu).HasColumnType("nvarchar(1000)");
			builder.HasOne(x => x.NguoiDung).WithMany(p => p.HoaDons).HasForeignKey(x => x.IDNguoiDung);
		}
	}
}
