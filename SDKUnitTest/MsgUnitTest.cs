using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XinGePushSDK.NET;
using System.Diagnostics;

namespace SDKUnitTest
{
    [TestClass]
    public class MsgUnitTest
    {
        [TestMethod]
        public void AndroidTestMethod()
        {
            Msg_Android_TouChuan mat = new Msg_Android_TouChuan("标题测试",XinGeConfig.message_type_touchuan) 
            {
                content = "唯一的内容"
            };

            Debug.WriteLine(mat.ToJson());
        }
    }
}
