using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Flutter.Support.HostedServer
{
    public static class LogHelper
    {
        public static ILoggerRepository Repository { get; set; }

        private static ILog _log;
        private static ILog log
        {
            get
            {
                if (_log == null)
                {
                    Configure();
                }
                return _log;
            }
        }

        public static void Configure(string repositoryName = "rollingAppender")
        {
            Repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(Repository,
               new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));
            _log = LogManager.GetLogger(repositoryName, "");
        }

        public static void Info(string msg, Exception ex = null)
        {
            log.Info(msg, ex);
        }

        public static void Warn(string msg, Exception ex = null)
        {
            log.Warn(msg, ex);
        }

        public static void Error(string msg, Exception ex = null)
        {
            log.Error(msg, ex);
        }
    }
}
