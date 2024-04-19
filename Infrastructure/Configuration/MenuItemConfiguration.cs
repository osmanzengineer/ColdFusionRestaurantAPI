using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(s => s.ID)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Price)
                .IsRequired();

            builder.Property(x => x.IsPermanent);

            builder.Property(x => x.IsActive);

            builder.Property(x => x.GlutenFree);

            builder.Property(x => x.IsVegan);

            builder.Property(x => x.CreateDate);

            builder.Property(s => s.CategoryID);

            builder.Property(s => s.DayOfWeek);

            builder.HasOne(x => x.Category)
                   .WithMany()
                   .HasForeignKey(x => x.CategoryID);

        }
    }
}