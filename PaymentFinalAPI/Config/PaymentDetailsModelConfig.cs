using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentFinalAPI.Models;

namespace PaymentFinalAPI.Config
{
    public class PaymentDetailModelConfig : IEntityTypeConfiguration<PaymentDetailsModel>
    {
        public void Configure(EntityTypeBuilder<PaymentDetailsModel> builder)
        {
            builder.HasKey(x => x.PaymentDetailId);
            builder.Property(x => x.CardOwnerName)
                .HasColumnType("varchar(100)");
            builder.Property(x => x.CardNumber)
                .HasColumnType("varchar(16)");
            builder.Property(x => x.ExpirationDate)
                .HasColumnType("varchar(5)");
            builder.Property(x => x.SecurityCode)
                .HasColumnType("varchar(3)");
        }
    }
}
