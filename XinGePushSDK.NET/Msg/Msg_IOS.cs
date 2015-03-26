using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET
{

    public class Msg_IOS : Msg
    {
        private string aps { get; set; }
        public Msg_IOS(Payload playload)
            : base(0)
        {
            aps = playload.ToJson();
        }

        public Msg_IOS(Payload playload,IDictionary<string, string> msg):base(0)
        {
            aps = playload.ToJson();
        }

        public override string ToJson()
        {
            JObject jobject = new JObject();
            jobject.Add("aps", aps);
            if (accept_time.Count > 0)
            {
                JArray array = new JArray(this.accept_time);
                jobject.Add("accept_time", array);
            }
            if (this.custom_content.Count > 0)
            {
                JArray array = new JArray(this.custom_content);
                jobject.Add("custom_content", array);
            }
            return jobject.ToString();
        }
    }
}
