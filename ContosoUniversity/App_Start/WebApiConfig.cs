using Application.Validator;
using Common.Exceptions;
using FluentValidation.WebApi;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace ContosoUniversity
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var url = ConfigurationManager.AppSettings["origin"];

            //Support for CORS
            //var cors = new EnableCorsAttribute(url, "*", "GET,POST");
            //config.EnableCors(cors);

            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonFormatter = config.Formatters.JsonFormatter;

            //Register Exception Handler  
            config.Services.Add(typeof(IExceptionLogger), new ManagerWebApiExceptions());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            FluentValidationModelValidatorProvider.Configure(config, provider =>
            {
                provider.ValidatorFactory = new ModelValidatorFactory(config);
            });

        }
    }
}
