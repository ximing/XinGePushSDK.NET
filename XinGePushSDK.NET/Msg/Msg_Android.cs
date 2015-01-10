using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET
{
    public class Msg_Android : Msg
    {
        public Msg_Android(string title, uint message_type)
            : base(message_type)
        {
            this.title = title;
            this.content = "";
            this.multi_pkg = 0;

            
        }
        public string title { get; set; }
        public string content { get; set; }

        
        public uint multi_pkg{get;set;}
        

        
    }
}
