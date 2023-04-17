using Assignment_NET104_TuanNDPH25862.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_NET104_TuanNDPH25862.Configurations
{
	public class ChatLieuConfiguration : IEntityTypeConfiguration<ChatLieu>
	{
		public void Configure(EntityTypeBuilder<ChatLieu> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.TenChatLieu).HasColumnType("nvarchar(100)");
		}
	}
}
