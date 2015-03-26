using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET
{
    public class Msg_Android_TouChuan : Msg_Android
    {
        public Msg_Android_TouChuan(string title, uint message_type)
            : base(title, message_type)
        {
        }
        public override string  ToJson()
        {
            JObject jobject = new JObject();
            jobject.Add("title", this.title);
            jobject.Add("content", this.content);
            if(accept_time.Count>0)
            {
                JArray array = new JArray(this.accept_time);
                jobject.Add("accept_time", array);
            }
            if (this.custom_content.Count>0)
            {
                JArray array = new JArray(this.custom_content);
                jobject.Add("custom_content", array);
            }
            return jobject.ToString();
            
        }
    }
}
