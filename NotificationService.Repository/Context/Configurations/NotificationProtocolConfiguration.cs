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
            builder.HasIndex(p => p.uid_protocol);

            builder.Property(p => p.uid_protocol)
                .HasColumnName("uid_protocol")
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidPKeyGenerator>()
                .IsRequired();

            builder.Property(p => p.Id)
                .HasColumnName("protocol_id");
                

            builder.Property(p => p.Protocol)
                .HasColumnName("protocol");

            builder.HasMany(p => p.Notifications)
                .WithOne(c => c.Protocol)
                .IsRequired();

        }
    }
}
