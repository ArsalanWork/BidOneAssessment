using Autofac;
using BidOneAssessment.Domain;
using BidOneAssessment.Infrastructure.Repositories;
using BidOneAssessment.QuerySide;

namespace BidOneAssessment.Api.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Repositories
            builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerLifetimeScope();

            // Queries
            builder.RegisterType<ContactQueries>().As<IContactQueries>().InstancePerLifetimeScope();

            // Infrastructure Services
            //builder.RegisterType<InMemoryCache>().As<ICache>().InstancePerLifetimeScope();

            // External Services
        }
    }
}
