using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testNlog.Interface
{
    public interface ILog
    {
        void Information(string message, string controller, string action, string createdBy);
        void Warning(string message, string controller, string action, string createdBy);
        void Debug(string message, string controller, string action, string createdBy);
        void Error(string message, string controller, string action, string createdBy);
    }
}