using Assignment_NET104_TuanNDPH25862.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104_TuanNDPH25862.Configurations
{
	public class ChucVuConfiguration : IEntityTypeConfiguration<ChucVu>
	{
		public void Configure(EntityTypeBuilder<ChucVu> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.TenChucVu).HasColumnType("nvarchar(100)");
			builder.Property(x => x.MoTa).HasColumnType("nvarchar(100)");
		}
	}
}
