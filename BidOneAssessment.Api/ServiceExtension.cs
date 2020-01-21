using BidOneAssessment.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BidOneAssessment.Api
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["WriteStore:ConnectionString"];

            services.AddDbContext<BidOneAssessmentContext>(options =>
                options.UseMySql(connectionString,
                mySqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                       maxRetryCount: 10,
                       maxRetryDelay: TimeSpan.FromSeconds(30),
                       errorNumbersToAdd: null);
                }));

            return services;
        }
    }
}
