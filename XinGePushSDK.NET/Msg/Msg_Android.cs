using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET
{
    public class Msg_Android : Msg
    {
        protected Msg_Android(string title, uint message_type)
            : base(message_type)
        {
            this.title = title;
            this.content = "";
            this.multi_pkg = 0;
        }
        public string title { get; set; }
        public string content { get; set; }

        /// <summary>
        /// 0表示按注册时提供的包名分发消息；
        /// 1表示按access id分发消息，所有以该access id成功注册推送的app均可收到消息。
        /// 默认为0
        /// 本字段对iOS平台无效
        /// </summary>
        public uint multi_pkg{get;set;}
        

        
    }
}
