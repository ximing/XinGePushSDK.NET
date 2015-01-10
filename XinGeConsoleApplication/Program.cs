using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XinGePushSDK.NET;

namespace XinGeConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            XingeApp xinge = new XingeApp("2100077407", "2164895a5ff3875b3533d667e6e5bf01");
            Msg_Android ma = new Msg_Android_TouChuan("测试", XinGeConfig.message_type_touchuan)
            {
                content = "测试"
            };
            var respushall = xinge.PushAllDevice(ma);
            Console.WriteLine(respushall.ret_code);
            Console.WriteLine(respushall.err_msg);
        }

    }
}
