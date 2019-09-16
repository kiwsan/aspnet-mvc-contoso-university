using Application.Commands.Person;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Data;
using FluentValidation;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;

namespace ContosoUniversity
{
    public static class Bootstrapper
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<AppDbContext>().AsSelf().InstancePerDependency();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // mediator itself
            builder.AddMediatR(typeof(PersonCommandHandlersAsync).Assembly);

            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();
            builder.RegisterAssemblyTypes(assemblies).InstancePerLifetimeScope();

            AssemblyScanner.FindValidatorsInAssemblies(assemblies)
                            .ForEach(x => builder.RegisterType(x.ValidatorType).AsImplementedInterfaces().InstancePerLifetimeScope());

            var container = builder.Build();

            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}