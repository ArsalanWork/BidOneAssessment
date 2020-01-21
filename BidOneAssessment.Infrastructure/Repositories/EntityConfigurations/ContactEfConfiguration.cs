using BidOneAssessment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BidOneAssessment.Infrastructure.Repositories.EntityConfigurations
{
    public class ContactEfConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            // Table name setup
            builder.ToTable("contacts", BidOneAssessmentContext.DEFAULT_SCHEMA);

            // Primary key setup
            builder.HasKey(e => e.Id);

            // Properties setup
            builder.Property<Guid>("Id").IsRequired();
            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();
            builder.Property(e => e.Email).IsRequired();

            // Properties to ignore
            builder.Ignore(e => e.DomainEvents);
        }
    }
}
