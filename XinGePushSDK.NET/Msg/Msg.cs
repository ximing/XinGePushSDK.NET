using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET
{
    public class Msg
    {
        public Msg(uint message_type)
        {
            this.message_type = message_type;
            
            this.send_time = "2013-12-20 18:31:00";

            accept_time = new List<AcceptTime>();

            custom_content = new Dictionary<string, object>();
        }
        public uint? expire_time { get; set; }
        public uint? loop_times { get; set; }
        public uint? loop_interval { get; set; }
        public string send_time { get; set; }
        public List<AcceptTime> accept_time { get; set; }
        public uint message_type { get; set; }
        public IDictionary<string, object> custom_content { get; set; }
        
        public virtual string ToJson()
        {
            return String.Empty;
        }
    }
}
