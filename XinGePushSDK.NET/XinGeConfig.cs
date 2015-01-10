using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET
{
    public class XinGeConfig
    {
        public const String RESTAPI_PUSHSINGLEDEVICE = "http://openapi.xg.qq.com/v2/push/single_device";
        public const String RESTAPI_PUSHSINGLEACCOUNT = "http://openapi.xg.qq.com/v2/push/single_account";
        public const String RESTAPI_PUSHACCOUNTLIST = "http://openapi.xg.qq.com/v2/push/account_list";
        public const String RESTAPI_PUSHALLDEVICE = "http://openapi.xg.qq.com/v2/push/all_device";
        public const String RESTAPI_PUSHTAGS = "http://openapi.xg.qq.com/v2/push/tags_device";
        public const String RESTAPI_QUERYPUSHSTATUS = "http://openapi.xg.qq.com/v2/push/get_msg_status";
        public const String RESTAPI_QUERYDEVICECOUNT = "http://openapi.xg.qq.com/v2/application/get_app_device_num";
        public const String RESTAPI_QUERYTAGS = "http://openapi.xg.qq.com/v2/tags/query_app_tags";
        public const String RESTAPI_CANCELTIMINGPUSH = "http://openapi.xg.qq.com/v2/push/cancel_timing_task";
        public const String RESTAPI_BATCHSETTAG = "http://openapi.xg.qq.com/v2/tags/batch_set";
        public const String RESTAPI_BATCHDELTAG = "http://openapi.xg.qq.com/v2/tags/batch_del";
        public const String RESTAPI_QUERYTOKENTAGS = "http://openapi.xg.qq.com/v2/tags/query_token_tags";
        public const String RESTAPI_QUERYTAGTOKENNUM = "http://openapi.xg.qq.com/v2/tags/query_tag_token_num";

        public const String HTTP_POST = "POST";
        public const String HTTP_GET = "GET";

        public const int DEVICE_ALL = 0;
        public const int DEVICE_BROWSER = 1;
        public const int DEVICE_PC = 2;
        public const int DEVICE_ANDROID = 3;
        public const int DEVICE_IOS = 4;
        public const int DEVICE_WINPHONE = 5;

        /// <summary>
        /// IOS生产环境
        /// </summary>
        public const int IOSENV_PROD = 1;
        /// <summary>
        /// IOS开发环境
        /// </summary>
        public const int IOSENV_DEV = 2;
    }
}
