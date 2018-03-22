using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationService.Shared.Data;

namespace NotificationService.Repository.Context.Configurations
{
    public class NotificationProtocolConfiguration : IEntityTypeConfiguration<NotificationProtocol>
    {
        public void Configure(EntityTypeBuilder<NotificationProtocol> builder)
        {
            builder.ToTable("notification_protocol");
            builder.HasIndex(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("protocol_id")
                .IsRequired();

            builder.Property(p => p.Protocol)
                .HasColumnName("protocol");

            builder.HasMany(p => p.Notifications)
                .WithOne(c => c.Protocol)
                .IsRequired();

        }
    }
}
