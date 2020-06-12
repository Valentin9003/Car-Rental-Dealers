﻿using Domain.Models.CarAds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Models.ModelConstants.Common;
using static Domain.Models.ModelConstants.CarAd;

namespace Infrastructure.Persistence.Configurations
{
    internal class CarAdConfiguration : IEntityTypeConfiguration<CarAd>
    {
        public void Configure(EntityTypeBuilder<CarAd> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(MaxModelLength);

            builder
                .Property(c => c.ImageUrl)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);

            builder
                .Property(c => c.PricePerDay)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(c => c.IsAvailable)
                .IsRequired();

            builder
                .HasOne(c => c.Manufacturer)
                .WithMany()
                .HasForeignKey("ManufacturerId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(c => c.Options, o =>
                {
                    o.WithOwner();

                    o.Property(op => op.NumberOfSeats);
                    o.Property(op => op.HasClimateControl);

                    o.OwnsOne(
                        op => op.TransmissionType,
                        t =>
                        {
                            t.WithOwner();

                            t.Property(tr => tr.Value);
                        });
                });
        }
    }
}
