using Domain.Common;
using ExpenseTracker.Core.Expense;
using ExpenseTracker.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        //private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;
        //ICurrentUserService currentUserService,

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,  IDateTimeService dateTimeService) : base(options)
        {
            //_currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }
        public DbSet<ExpenseInfo> ExpenseInfos { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync();
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is AuditableEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.LastModified = _dateTimeService.Now;
                            //trackable.LastModifiedBy = _currentUserService.UserId;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = _dateTimeService.Now;
                            //trackable.CreatedBy = _currentUserService.UserId;
                            trackable.LastModified = _dateTimeService.Now;
                            //trackable.LastModifiedBy = _currentUserService.UserId;
                            break;
                    }
                }
            }
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Place>()
        //        .HasKey(e => new { e.Id });
        //    builder.Seed();
        //}
    }
}
