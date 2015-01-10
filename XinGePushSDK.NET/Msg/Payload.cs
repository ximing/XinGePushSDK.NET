using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET
{
    public class Payload
    {
        public Payload(string alertStr)
        {
            this.alertStr = alertStr;
            alertJson = null ;
        }
        public Payload(JObject alertJson)
        {
            this.alertJson = alertJson;
            alertStr = string.Empty;
        }
        public int badge {get;set;}
        public string sound { get; set; }
        public string category { get; set; }
        public string raw { get; set; }
        public string alertStr { get; set; }

        public JObject alertJson { get; set; }
        public string ToJson()
        {
            JObject jobject = new JObject();
            if (string.IsNullOrEmpty(alertStr))
            {
                jobject.Add("alert", alertStr);
            }
            else
            {
                jobject.Add("alert", alertJson);
            }
            if (badge!=null&&badge>0)
            {
                jobject.Add("badge", badge);
            }
            if (string.IsNullOrEmpty(sound))
            {
                jobject.Add("sound", sound);
            }
            if (string.IsNullOrEmpty(category))
            {
                jobject.Add("category", category);
            }
            if (string.IsNullOrEmpty(raw))
            {
                jobject.Add("raw", raw);
            }

            return jobject.ToString();
        }
    }
}
