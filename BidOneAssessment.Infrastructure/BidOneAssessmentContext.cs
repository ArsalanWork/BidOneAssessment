using BidOneAssessment.Core;
using BidOneAssessment.Domain;
using BidOneAssessment.Infrastructure.Configs;
using BidOneAssessment.Infrastructure.Mediator;
using BidOneAssessment.Infrastructure.Repositories.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BidOneAssessment.Infrastructure
{
    public class BidOneAssessmentContext : DbContext, IUnitOfWork
    {

        private readonly IMediator _mediator; 
        public const string DEFAULT_SCHEMA = null;
        public BidOneAssessmentContext(DbContextOptions<BidOneAssessmentContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContactEfConfiguration());
        }

        public int SaveChanges(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = base.SaveChanges();

            return result;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed throught the DbContext will be commited
            var result = await base.SaveChangesAsync();

            return true;
        }
    }

    public class BidOneAssessmentContextDesignFactory : IDesignTimeDbContextFactory<BidOneAssessmentContext>
    {
        public BidOneAssessmentContext CreateDbContext(string[] args)
        {
            var databaseSettings = new WriteStoreSettings
            {
                ConnectionString = @"Server=localhost;userid=root;password=BidOneDeveloper;port=33063;database=bidone.assessment;sslmode=none;"
            };
            var optionsBuilder = new DbContextOptionsBuilder<BidOneAssessmentContext>()
                .UseMySql(databaseSettings.ConnectionString,
                mySqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                       maxRetryCount: 10,
                       maxRetryDelay: TimeSpan.FromSeconds(30),
                       errorNumbersToAdd: null);
                });

            return new BidOneAssessmentContext(optionsBuilder.Options);
        }
    }
}
