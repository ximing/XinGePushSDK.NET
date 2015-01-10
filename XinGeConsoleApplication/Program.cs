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
            Console.WriteLine(ma.ToJson());
            var respushall = xinge.PushAllDevice(ma);
            Console.WriteLine(respushall.ret_code);
            Console.WriteLine(respushall.err_msg);
            Console.WriteLine(XinGeConfig.RESTAPI_BATCHSETTAG.Replace("http://", ""));
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_id", "123");
            parameters.Add("timestamp", "1386691200");
            parameters.Add("Param1", "Value1");
            parameters.Add("Param2", "Value2");
            Debug.WriteLine(getSignature(parameters, "abcde", "openapi.xg.qq.com/v2/push/single_device"));
            Console.WriteLine(getSignature(parameters, "abcde", "openapi.xg.qq.com/v2/push/single_device"));
        }

        public static string getSignature(IDictionary<string, string> parameters, string secret, string url)
        {
            // 先将参数以其参数名的字典序升序进行排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> iterator = sortedParams.GetEnumerator();

            // 遍历排序后的字典，将所有参数按"key=value"格式拼接在一起
            StringBuilder basestring = new StringBuilder();
            basestring.Append("POST").Append(url);
            while (iterator.MoveNext())
            {
                string key = iterator.Current.Key;
                string value = iterator.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    basestring.Append(key).Append("=").Append(value);
                }
            }
            basestring.Append(secret);

            // 使用MD5对待签名串求签
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(basestring.ToString()));

            // 将MD5输出的二进制结果转换为小写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                string hex = bytes[i].ToString("x");
                if (hex.Length == 1)
                {
                    result.Append("0");
                }
                result.Append(hex);
            }

            return result.ToString();
        }
    }
}
