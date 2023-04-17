using Assignment_NET104_TuanNDPH25862.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104_TuanNDPH25862.Configurations
{
	public class GioHangChiTietConfiguration : IEntityTypeConfiguration<GioHangChiTiet>
	{
		public void Configure(EntityTypeBuilder<GioHangChiTiet> builder)
		{
			builder.HasKey(x => x.ID);
			builder.HasOne(x=>x.GioHang).WithMany(c=>c.GioHangChiTiets).HasForeignKey(x=>x.UserID);
			builder.HasOne(x => x.SanPhamChiTiet).WithMany(p => p.GioHangChiTiets).HasForeignKey(x => x.IDSPCT);
		}
	}
}
