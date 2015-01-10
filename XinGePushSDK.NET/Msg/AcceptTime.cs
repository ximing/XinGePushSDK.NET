using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET
{

    public class AcceptTime
    {
        public List<TimeInterval> start { get; set; }
        public List<TimeInterval> end { get; set; }
    }
    public class TimeInterval
    {
        public int hour { get; set; }
        public int min { get; set; }
    }
}
