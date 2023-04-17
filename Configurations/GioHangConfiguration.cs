using Assignment_NET104_TuanNDPH25862.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping_Application.Configurations
{
	public class GioHangConfiguration : IEntityTypeConfiguration<GioHang>
	{
		public void Configure(EntityTypeBuilder<GioHang> builder)
		{
			// Nếu ta ko dùng phương thức ToTable thì tên của bảng sẽ chính là tên class model
			builder.HasKey(p => p.UserID);
			builder.Property(p => p.MoTa).HasColumnType("nvarchar(1000)");
		}
	}
}
