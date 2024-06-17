using InnovationAdmin.Application.Contracts;
using InnovationAdmin.Domain.Common;
using InnovationAdmin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InnovationAdmin.Persistence
{
    
    public class ApplicationDbContext:DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<SysPrefCompany> SysPrefCompanies { get; set; }
        public DbSet<AccountManager> AccountManagers { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin_User> Admin_Users { get; set; }
        public DbSet<SysPref_GeneralBehaviours> SysPref_GeneralBehaviour { get; set; }

        public DbSet<PharmacyGroup> PharmacyGroups { get; set; }

        public DbSet<Quotes> Quotes { get; set; }

        public DbSet<RemittanceType> RemittanceTypes { get; set; }



        public DbSet<SysPrefSecurityEmail> SysPrefSecurityEmails { get; set; }
        public DbSet<Admin_Role> AdminRoles { get; set; }

        public DbSet<SysPrefFinancial> SysPrefFinancials { get; set; }
        public DbSet<DataSource> DataSources { get; set; }

        public DbSet<BillingMethodType> BillingMethodTypes { get; set; }

        public DbSet<APAccountType> APAccountTypes { get; set; }

        public DbSet<ReceiptBatchSource> ReceiptBatchSources { get; set; }

        public DbSet<Templates> Templates { get; set; }

        public DbSet<CorrespondenceNotes> CorrespondenceNotes { get; set; }


        public DbSet<DoNotTakeGroup> doNotTakeGroups { get; set; }

        public DbSet<ClaimStatus> claimStatuses { get; set; }   

        private IDbContextTransaction _transaction;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //seed data, added through migrations
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

         
            modelBuilder.Entity<Message>()
                .Property(s => s.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = Guid.Parse("{253C75D5-32AF-4DBF-AB63-1AF449BDE7BD}"),
                Code = "1",
                MessageContent = "{PropertyName} is required.",
                Language = "en",
                Type = Message.MessageType.Error
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = Guid.Parse("{ED0CC6B6-11F4-4512-A441-625941917502}"),
                Code = "2",
                MessageContent = "{PropertyName} must not exceed {MaxLength} characters.",
                Language = "en",
                Type = Message.MessageType.Error
            });

            modelBuilder.Entity<Message>().HasData(new Message
            {
                MessageId = Guid.Parse("{FAFE649A-3E2A-4153-8FD8-9DCD0B87E6D8}"),
                Code = "3",
                MessageContent = "An event with the same name and date already exists.",
                Language = "en",
                Type = Message.MessageType.Error
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChangesAsync();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
