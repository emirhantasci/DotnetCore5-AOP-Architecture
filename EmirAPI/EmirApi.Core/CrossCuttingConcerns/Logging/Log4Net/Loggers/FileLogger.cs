using System;
using System.Collections.Generic;
using System.Text;

namespace EmirApi.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("TextFileLogger")
        {
        }
    }
}
