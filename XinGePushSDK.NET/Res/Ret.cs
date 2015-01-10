using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinGePushSDK.NET.Res
{
    public class Ret
    {
        //         0	调用成功
        //         -1	参数错误，请对照错误提示和文档检查请求参数
        //         -2	请求时间戳不在有效期内
        //         -3	sign校验无效，检查access id和secret key（注意不是access key）
        //         2	参数错误，请对照文档检查请求参数
        //         7	别名/账号绑定的终端数满了（10个）
        //         14	收到非法token，例如ios终端没能拿到正确的token
        //         15	信鸽逻辑服务器繁忙
        //         19	操作时序错误
        //         例如进行tag操作前未获取到deviceToken 没有获取到deviceToken的原因: 1.没有注册信鸽或者苹果推送。 2.provisioning profile制作不正确。
        //         40	推送的token没有在信鸽中注册，请检查终端注册是否成功
        //         48	推送的账号没有在信鸽中注册，请检查终端注册是否成功
        //         71	APNS服务器繁忙
        //         73	消息字符数超限，请减少消息内容再试
        //         76	请求过于频繁，请稍后再试
        //         100	APNS证书错误。请重新提交正确的证书
        //         其他	内部错误
        public int ret_code { get; set; } //返回码
        public string err_msg { get; set; }	//	请求出错时的错误信息
        public dynamic result { get; set; }  //请求正确时，若有额外数据要返回，则结果封装在该字段的json中。若无额外数据，则可能无此字段

    }
}
