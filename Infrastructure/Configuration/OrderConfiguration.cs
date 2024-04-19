using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(x => x.ID);
            builder.Property(s => s.ID)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.Count)
                .IsRequired();

            builder.Property(s => s.OrderDate)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.OrderNote);

            builder.Property(x => x.IsChecked);

            builder.Property(s => s.MenuItemID);

            builder.HasOne(x => x.MenuItem)
                    .WithMany()
                    .HasForeignKey(x => x.MenuItemID);

            builder.Property(s => s.CustomerID);

            builder.HasOne(x => x.Customer)
                    .WithMany()
                    .HasForeignKey(x => x.CustomerID);

        }
    }
}