using System;
using System.Collections.Generic;
using System.Text;

namespace EmirApi.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }

    }


}
