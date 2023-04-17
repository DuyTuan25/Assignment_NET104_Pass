using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Assignment_NET104_TuanNDPH25862.Models;

namespace Shopping_Application.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.TenNguoiDung).HasColumnType("nchar(256)");
			builder.Property(x => x.MatKhau).HasColumnType("nchar(256)");
			builder.Property(x => x.HoTen).HasColumnType("nchar(256)");
			builder.HasOne(p => p.ChucVu).WithMany(p => p.NguoiDungs).HasForeignKey(p => p.IDCV);
		}
	}
}
