using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET
{
    //通知消息
    public class Msg_Android_Info : Msg_Android
    {
        public Msg_Android_Info(string title, uint message_type)
            : base(title, message_type)
        {
            this.ring = 1;
            this.vibrate = 1;
            this.lights = 1;
            this.clearable = 1;
        }
        public int n_id { get; set; }
        public int builder_id { get; set; }
        public int ring { get; set; }
        public string ring_raw { get; set; }
        public int vibrate { get; set; }
        public int lights { get; set; }
        public int clearable { get; set; }
        public int icon_type { get; set; }
        public string icon_res { get; set; }

        public int style_id { get; set; }
        public string small_icon { get; set; }

        /// <summary>
        /// "action":{ // 动作，选填。默认为打开app
        //        "action_type  ": 1, // 动作类型，1打开activity或app本身，2打开浏览器，3打开Intent，4通过包名拉起其他应用
        //        "activity ": "xxx"
        //        "aty_attr ": // activity属性，只针对action_type=1的情况
        //            {
        //             "if":0,   // 创建通知时，intent的属性，如：intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_RESET_TASK_IF_NEEDED);
        //             "pf":0,   // PendingIntent的属性，如：PendingIntent.FLAG_UPDATE_CURRENT
        //            }   
        //        "browser": {"url": "xxxx ","confirm": 1},  // url：打开的url，confirm是否需要用户确认        
        //        “intent”: “xxx”
        //         “package_name”:
        //{"packageDownloadUrl": "xxxx ",// 要拉起的别的应用的包名
        //"confirm": 1,//是否确认
        //"packageName":"com.demo.xg"}//拉起应用的下载链接（若客户端没有找到此应用会自动去下载）
        //}
        /// </summary>
        public string action { get; set; }
        public override string ToJson()
        {
            JObject jobject = new JObject();
            jobject.Add("title", this.title);
            jobject.Add("content", this.content);
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
            jobject.Add("n_id", this.n_id);
            jobject.Add("builder_id", this.builder_id);
            jobject.Add("ring", this.ring);
            jobject.Add("ring_raw", this.ring_raw);
            jobject.Add("vibrate", this.vibrate);
            jobject.Add("lights", this.lights);
            jobject.Add("clearable", this.clearable);
            jobject.Add("icon_type", this.icon_type);
            jobject.Add("icon_res", this.icon_res);
            jobject.Add("style_id", this.style_id);
            jobject.Add("small_icon", this.small_icon);
            jobject.Add("action", this.action);
            return jobject.ToString();
        }
    }
}
