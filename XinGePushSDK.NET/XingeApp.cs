using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinGePushSDK.NET.Res;
using XinGePushSDK.NET.Utility;

namespace XinGePushSDK.NET
{
    public class XingeApp
    {
        private string accessId;
        private string secretKey;
        public uint valid_time;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accessId">accessId</param>
        /// <param name="secretKey">secretKey</param>
        /// <param name="valid_time">配合timestamp确定请求的有效期，单位为秒，
        /// 最大值为600。若不设置此参数或参数值非法，则按默认值600秒计算有效期</param>
        public XingeApp(string accessId, string secretKey, uint valid_time=600)
        {
            if (string.IsNullOrEmpty(accessId))
            {
                throw new ArgumentNullException("accessId");
            }
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException("secretKey");
            }
            this.valid_time = valid_time;
            this.accessId = accessId;
            this.secretKey = secretKey;
        }

        private Ret CallRestful(String url, IDictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            try
            {
                parameters.Add("access_id", accessId);
                parameters.Add("timestamp", ((int)(DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(
                new System.DateTime(1970, 1, 1))).TotalSeconds).ToString());
                parameters.Add("valid_time", valid_time.ToString());
                string md5sing = SignUtility.GetSignature(parameters, this.secretKey, url);
                parameters.Add("sign", md5sing);
                var res = HttpWebResponseUtility.CreatePostHttpResponse(url, parameters, null, null, Encoding.UTF8, null);
                var resstr = res.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(resstr);
                var resstring = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<Ret>(resstring);
            }
            catch (Exception e)
            {
                return new Ret { ret_code = -1, err_msg = e.Message };
            }
        }

        /// <summary>
        /// 推送到 单个设备 IOS
        /// </summary>
        /// <param name="DeviceToken"></param>
        /// <param name="msg"></param>
        /// <param name="expire_time"></param>
        /// <param name="send_time"></param>
        /// <returns></returns>
        public Ret PushToSingleDevice(string DeviceToken, Msg_IOS msg, uint environment)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg");
            }
            if (string.IsNullOrEmpty(DeviceToken))
            {
                throw new ArgumentNullException("DeviceToken");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("device_token", DeviceToken);
            parameters.Add("send_time", msg.send_time);
            parameters.Add("environment", environment.ToString());
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("message", msg.ToJson());
            parameters.Add("message_type", msg.message_type.ToString());
            return CallRestful(XinGeConfig.RESTAPI_PUSHSINGLEDEVICE, parameters);
        }

        /// <summary>
        /// 推送到 单个设备 安卓
        /// </summary>
        /// <param name="DeviceToken"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ret PushToSingleDevice(string DeviceToken, Msg_Android msg)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg");
            }
            if (string.IsNullOrEmpty(DeviceToken))
            {
                throw new ArgumentNullException("DeviceToken");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("device_token", DeviceToken);
            parameters.Add("send_time", msg.send_time);
            parameters.Add("multi_pkg", msg.multi_pkg.ToString());
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("message", msg.ToJson());
            parameters.Add("message_type", msg.message_type.ToString());
            return CallRestful(XinGeConfig.RESTAPI_PUSHSINGLEDEVICE, parameters);
        }






        /// <summary>
        /// 推送到 单个用户 IOS
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="msg"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        public Ret PushToAccount(string Account, Msg_IOS msg, uint environment)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg");
            }
            if (string.IsNullOrEmpty(Account))
            {
                throw new ArgumentNullException("Account");
            }
            
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("account", Account);
            parameters.Add("send_time", msg.send_time);
            parameters.Add("environment", environment.ToString());
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("message", msg.ToJson());
            parameters.Add("message_type", msg.message_type.ToString());
            return CallRestful(XinGeConfig.RESTAPI_PUSHSINGLEACCOUNT, parameters);
        }

        /// <summary>
        /// 推送到 单个用户 Android
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Ret PushToAccount(string Account, Msg_Android msg)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg");
            }
            if (string.IsNullOrEmpty(Account))
            {
                throw new ArgumentNullException("Account");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("account", Account);
            parameters.Add("send_time", msg.send_time);
            parameters.Add("multi_pkg", msg.multi_pkg.ToString());
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("message", msg.ToJson());
            parameters.Add("message_type", msg.message_type.ToString());
            return CallRestful(XinGeConfig.RESTAPI_PUSHSINGLEACCOUNT, parameters);
        }


        public Ret PushAccountList(List<String> accountList, Msg_Android msg)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg");
            }
            if (accountList.Count == 0)
            {
                throw new ArgumentNullException("accountList");
            }
            if (accountList.Count > 100)
            {
                throw new ArgumentOutOfRangeException("accountList");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("account_list", JsonConvert.SerializeObject(accountList));
            parameters.Add("multi_pkg", msg.multi_pkg.ToString());
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("message", msg.ToJson());
            parameters.Add("message_type", msg.message_type.ToString());
            return CallRestful(XinGeConfig.RESTAPI_PUSHACCOUNTLIST, parameters);
        }

        public Ret PushAccountList(List<String> accountList, Msg_IOS msg, uint environment)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg");
            }
            if (accountList.Count == 0)
            {
                throw new ArgumentNullException("accountList");
            }
            if (accountList.Count > 100)
            {
                throw new ArgumentOutOfRangeException("accountList");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("account_list", JsonConvert.SerializeObject(accountList));
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("message", msg.ToJson());
            parameters.Add("environment", environment.ToString());
            parameters.Add("message_type", msg.message_type.ToString());
            return CallRestful(XinGeConfig.RESTAPI_PUSHACCOUNTLIST, parameters);
        }




        /// <summary>
        /// 推送到 所有用户 IOS
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="expire_time"></param>
        /// <param name="send_time"></param>
        /// <param name="multi_pkg"></param>
        /// <param name="loop_times"></param>
        /// <param name="loop_interval"></param>
        /// <returns></returns>
        public Ret PushAllDevice(Msg_Android msg)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("message_type", msg.message_type.ToString());
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("send_time", msg.send_time);
            parameters.Add("multi_pkg", msg.multi_pkg.ToString());
            parameters.Add("message", msg.ToJson());
            if (msg.loop_times.HasValue)
            {
                parameters.Add("loop_times", msg.loop_times.Value.ToString());
            }
            if (msg.loop_interval.HasValue)
            {
                parameters.Add("loop_interval", msg.ToJson());
            }
            return CallRestful(XinGeConfig.RESTAPI_PUSHALLDEVICE, parameters);
        }

        public Ret PushAllDevice(Msg_IOS msg, uint environment)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("message_type", msg.message_type.ToString());
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("send_time", msg.send_time);
            parameters.Add("multi_pkg", environment.ToString());
            parameters.Add("message", msg.ToJson());
            if (msg.loop_times.HasValue)
            {
                parameters.Add("loop_times", msg.loop_times.Value.ToString());
            }
            if (msg.loop_interval.HasValue)
            {
                parameters.Add("loop_interval", msg.ToJson());
            }
            return CallRestful(XinGeConfig.RESTAPI_PUSHALLDEVICE, parameters);
        }

        public Ret pushTags(List<String> tagList, String tagOp, Msg_Android msg)
        {
            if (tagList == null || tagList.Count == 0)
            {
                throw new ArgumentNullException("tagList");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("message", msg.ToJson());
            parameters.Add("message_type", msg.message_type.ToString());
            parameters.Add("tags_list", JsonConvert.SerializeObject(tagList));
            parameters.Add("tags_op", tagOp);
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("send_time", msg.send_time);

            parameters.Add("multi_pkg", msg.multi_pkg.ToString());

            if (msg.loop_times.HasValue)
            {
                parameters.Add("loop_times", msg.loop_times.Value.ToString());
            }
            if (msg.loop_interval.HasValue)
            {
                parameters.Add("loop_interval", msg.ToJson());
            }
            return CallRestful(XinGeConfig.RESTAPI_PUSHTAGS, parameters);
        }

        public Ret pushTags(List<String> tagList, String tagOp, Msg_IOS msg, uint environment)
        {
            if (tagList == null || tagList.Count == 0)
            {
                throw new ArgumentNullException("tagList");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("message", msg.ToJson());
            parameters.Add("message_type", msg.message_type.ToString());
            parameters.Add("tags_list", JsonConvert.SerializeObject(tagList));
            parameters.Add("tags_op", tagOp);
            if (msg.expire_time.HasValue)
            {
                parameters.Add("expire_time", msg.expire_time.Value.ToString());
            }
            parameters.Add("send_time", msg.send_time);

            parameters.Add("environment", environment.ToString());

            if (msg.loop_times.HasValue)
            {
                parameters.Add("loop_times", msg.loop_times.Value.ToString());
            }
            if (msg.loop_interval.HasValue)
            {
                parameters.Add("loop_interval", msg.ToJson());
            }
            return CallRestful(XinGeConfig.RESTAPI_PUSHTAGS, parameters);
        }


        public Ret QueryPushStatus(List<String> pushIdList)
        {
            JObject jObject = new JObject();
            foreach (var item in pushIdList)
            {
                jObject.Add("push_id", item);
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("push_ids", jObject.ToString());
            return CallRestful(XinGeConfig.RESTAPI_QUERYPUSHSTATUS, parameters);
        }
        public Ret QueryDeviceCount(List<String> pushIdList)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            return CallRestful(XinGeConfig.RESTAPI_QUERYDEVICECOUNT, parameters);
        }

        public Ret QueryTags(int start, int limit)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("start", start.ToString());
            parameters.Add("limt", limit.ToString());
            return CallRestful(XinGeConfig.RESTAPI_QUERYTAGS, parameters);
        }

        public Ret QueryTags()
        {
            return QueryTags(0, 100);
        }


        public Ret CancelTimingPush(String pushId)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("push_id", pushId);
            return CallRestful(XinGeConfig.RESTAPI_CANCELTIMINGPUSH, parameters);
        }

        public Ret BatchSetTag(IDictionary<string, string> tagTokenPairs)
        {

            if (tagTokenPairs == null)
            {
                throw new ArgumentNullException("tagTokenPairs");
            }
            if (tagTokenPairs.Count > 20)
            {
                throw new ArgumentOutOfRangeException("tagTokenPairs");
            }
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            JArray jarray = new JArray();
            foreach (var item in tagTokenPairs)
            {
                JArray ja = new JArray();
                ja.Add(item.Key);
                ja.Add(item.Value);
                jarray.Add(ja);
            }
            parameters.Add("tag_token_list", jarray.ToString());
            return CallRestful(XinGeConfig.RESTAPI_BATCHSETTAG, parameters);
        }

        public Ret BatchDelTag(List<string> tagTokenPairKeys)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("tag_token_list", JsonConvert.SerializeObject(tagTokenPairKeys));

            return CallRestful(XinGeConfig.RESTAPI_BATCHDELTAG, parameters);
        }
        public Ret QueryTokenTags(String deviceToken)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("device_token", deviceToken);
            return CallRestful(XinGeConfig.RESTAPI_QUERYTOKENTAGS, parameters);
        }

        public Ret QueryTagTokenNum(String tag)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("tag", tag);
            return CallRestful(XinGeConfig.RESTAPI_QUERYTAGTOKENNUM, parameters);
        }
    }
}
