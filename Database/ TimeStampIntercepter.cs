using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebProject.Entities;

namespace WebProject.Database
{
    public class  TimeStampIntercepter: SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var addedEntries = eventData.Context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added);
            
            foreach (var entry in addedEntries)
            {
                if(entry.Entity is TimeStamp hasTimestamp)
                {
                    hasTimestamp.CreatedAt = new DateOnly();
                    hasTimestamp.UpdatedAt = new DateOnly();
                }
            }

            var modifiedEntries = eventData.Context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified);

                foreach (var entry in modifiedEntries)
                {
                    if (entry.Entity is TimeStamp hasTimestamp)
                    {
                        hasTimestamp.UpdatedAt = new DateOnly();
                    }
                }
            return base.SavingChanges(eventData, result);
        }
    }
}