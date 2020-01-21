using Autofac;
using BidOneAssessment.Application.Commands;
using BidOneAssessment.Application.CommandValidators;
using BidOneAssessment.Application.EventHandlers;
using BidOneAssessment.Infrastructure.Mediator;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Reflection;

namespace BidOneAssessment.Api.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            // Register all the assemblies to search for command handlers
            builder.RegisterAssemblyTypes(typeof(CreateContact).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Register all the assemblies to search for event handlers
            builder.RegisterAssemblyTypes(typeof(ContactOnboardedHandler).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(INotificationHandler<>));

            // Register all the assemblies to search for command validators
            builder.RegisterAssemblyTypes(typeof(CreateContactValidator).GetTypeInfo().Assembly).Where(t => t.IsClosedTypeOf(typeof(IValidator<>))).AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
