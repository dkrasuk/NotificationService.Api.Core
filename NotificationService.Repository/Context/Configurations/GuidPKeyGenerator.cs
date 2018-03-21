using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace NotificationService.Repository.Context.Configurations
{

    public class GuidPKeyGenerator : ValueGenerator<Guid>
    {
        public override bool GeneratesTemporaryValues => false;


        public override Guid Next(EntityEntry entry)
        {
            return Guid.NewGuid();
        }
    }

    public class DateGenerator : ValueGenerator<DateTime>
    {
        public override bool GeneratesTemporaryValues => false;


        public override DateTime Next(EntityEntry entry)
        {
            return DateTime.UtcNow;
        }
    }
}
