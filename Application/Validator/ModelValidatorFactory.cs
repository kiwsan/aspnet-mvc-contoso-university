using FluentValidation;
using System;
using System.Web.Http;

namespace Application.Validator
{
    public class ModelValidatorFactory : IValidatorFactory
    {
        private HttpConfiguration _config;

        public ModelValidatorFactory(HttpConfiguration config)
        {
            _config = config;
        }

        public IValidator GetValidator(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            // WebAPI
            return _config.DependencyResolver.GetService(typeof(IValidator<>).MakeGenericType(type)) as IValidator;
        }

        public IValidator<T> GetValidator<T>()
        {
            return _config.DependencyResolver.GetService(typeof(IValidator<T>)) as IValidator<T>;
        }

    }
}
