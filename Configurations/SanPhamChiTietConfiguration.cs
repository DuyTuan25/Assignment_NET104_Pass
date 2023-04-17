using Assignment_NET104_TuanNDPH25862.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104_TuanNDPH25862.Configurations
{
	public class SanPhamChiTietConfiguration : IEntityTypeConfiguration<SanPhamChiTiet>
	{
		public void Configure(EntityTypeBuilder<SanPhamChiTiet> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.TenSanPham).HasColumnType("nvarchar(100)");
			builder.Property(x => x.NhaCungCap).HasColumnType("nvarchar(100)");
			builder.Property(x => x.MoTa).HasColumnType("nvarchar(1000)");
			builder.Property(x => x.Image).HasColumnType("nvarchar(1000)");
			builder.HasOne(x => x.ChatLieu).WithMany(p => p.SanPhamChiTiets).HasForeignKey(x => x.IDChatLieu);
		}
	}
}
