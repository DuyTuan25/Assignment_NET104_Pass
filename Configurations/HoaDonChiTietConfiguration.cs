using Assignment_NET104_TuanNDPH25862.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104_TuanNDPH25862.Configurations
{
	public class HoaDonChiTietConfiguration : IEntityTypeConfiguration<HoaDonChiTiet>
	{
		public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
		{
			builder.HasKey(p => p.ID);
			builder.HasOne(x => x.HoaDon).WithMany(y => y.HoaDonChiTiets).HasForeignKey(c => c.IDHD);
			builder.HasOne(x => x.SanPhamChiTiet).WithMany(y => y.HoaDonChiTiets).HasForeignKey(c => c.IDSPCT);
		}
	}
}
