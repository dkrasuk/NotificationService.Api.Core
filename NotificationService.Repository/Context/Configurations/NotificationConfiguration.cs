using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationService.Shared.Data;

namespace NotificationService.Repository.Context.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("notifications");
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidPKeyGenerator>();

            builder.Property(s => s.Channel)
                .HasColumnName("chanel");

            builder.Property(s => s.Receiver)
                .HasColumnName("receiver");

            builder.Property(s => s.Type)
                .HasColumnName("type");

            builder.Property(s => s.Title)
                .HasColumnName("title");

            builder.Property(s => s.Body)
                .HasColumnName("body");

            builder.Property(s => s.IsReaded)
                .HasColumnName("isreaded");


            builder.Property(s => s.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired();

            builder.Property(s => s.ModifyDate)
                .HasColumnName("modify_date");

            builder.Property(s => s.Protocol)
                .HasColumnName("protocol")
                .IsRequired();
        }
    }
}
