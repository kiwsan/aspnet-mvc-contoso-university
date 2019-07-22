using System.Web.Mvc;
using Application.Commands.Person;
using Autofac;
using Autofac.Integration.Mvc;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace ContosoUniversity
{
    public static class Bootstrapper
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<Repository<Student>>().As<IRepository<Student>>();

            // mediator itself
            builder.AddMediatR(typeof(PersonCommandHandlersAsync).Assembly);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}