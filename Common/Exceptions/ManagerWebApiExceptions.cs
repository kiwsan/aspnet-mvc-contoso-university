using log4net;
using System;
using System.IO;
using System.Reflection;
using System.Web.Http.ExceptionHandling;

namespace Common.Exceptions
{
    public class ManagerWebApiExceptions : ExceptionLogger
    {
        ILog _logger = null;
        public ManagerWebApiExceptions()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/log4net.config")));
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(context.Exception.ToString() + Environment.NewLine);
        }

        public void Log(string ex)
        {
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(ex);
        }

    }
}
