using BidOneAssessment.Domain;
using BidOneAssessment.Infrastructure;
using BidOneAssessment.Infrastructure.Configs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BidOneAssessment.Api.SeedData
{
    public static class BidOneAssessmentContextSeed
    {
        public static async Task InitializeAsync(this BidOneAssessmentContext context, IWebHostEnvironment env, IServiceProvider serviceLocator)
        {
            var contentRootPath = env.ContentRootPath;
            var connectionString = serviceLocator.GetService<IOptions<WriteStoreSettings>>().Value.ConnectionString;

            if (!context.Contacts.Any())
            {
                SeedContactsFromJson(context, contentRootPath, connectionString);
            }
        }

        private static void SeedContactsFromJson(BidOneAssessmentContext context, string contentRootPath, string connectionString)
        {
            if (!context.Contacts.Any())
            {
                //var contactTemplate = new List<object>().Select(t => new
                //{
                //    Id = default(Guid),
                //    FirstName = default(string),
                //    LastName = default(string),
                //    Email = default(string),
                //    Status = default(string),
                //    InterestedInCommunications = default(bool)
                //}).ToList();


                var contactsJsonPath = Path.Combine(contentRootPath, "SeedData", "contacts.json");
                //var contactsToSeed = JsonConvert.DeserializeAnonymousType(File.ReadAllText(contactsJsonPath), contactTemplate);
                var contactsToSeed = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(contactsJsonPath));
                context.Contacts.AddRange(contactsToSeed);

                context.SaveChanges();
            }
        }
    }
}
