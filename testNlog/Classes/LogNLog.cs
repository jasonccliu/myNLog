using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testNlog.Interface;

namespace testNlog.Classes
{
    public class LogNLog : ILog
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        private static void AddLogProperty(string controllerName, string actionName, string createdBy, LogEventInfo logEvenInfo)
        {
            logEvenInfo.Properties["ControllerName"] = controllerName;
            logEvenInfo.Properties["ActionName"] = actionName;
            logEvenInfo.Properties["CreatedBy"] = createdBy;
        }

        public LogNLog()
        {
            var config = LogManager.Configuration;
            var dbTarget = (DatabaseTarget)config.FindTargetByName("database");
            //Get the connection from UserInfo 
            dbTarget.ConnectionString = "server=localhost;Database=SystemBuild;Trusted_Connection=True;";
            LogManager.ReconfigExistingLoggers();
        }

        public void Debug(string message, string controllerName, string actionName, string createdBy)
        {
            var logEvenInfo = new LogEventInfo()
            {
                Level = LogLevel.Debug,
                Message = message 
            };

            AddLogProperty(controllerName, actionName, createdBy, logEvenInfo);

            logger.Log(logEvenInfo);
        }

        public void Error(string message, string controllerName, string actionName, string createdBy)
        {
            var logEvenInfo = new LogEventInfo()
            {
                Level = LogLevel.Error,
                Message = message
            };

            AddLogProperty(controllerName, actionName, createdBy, logEvenInfo);

            logger.Log(logEvenInfo);
        }

        public void Information(string message, string controllerName, string actionName, string createdBy)
        {
            var logEvenInfo = new LogEventInfo()
            {
                Level = LogLevel.Info,
                Message = message
            };

            AddLogProperty(controllerName, actionName, createdBy, logEvenInfo);

            logger.Log(logEvenInfo);
        }

        public void Warning(string message, string controllerName, string actionName, string createdBy)
        {
            var logEvenInfo = new LogEventInfo()
            {
                Level = LogLevel.Warn,
                Message = message
            };

            AddLogProperty(controllerName, actionName, createdBy, logEvenInfo);

            logger.Log(logEvenInfo);
        }
    }
}