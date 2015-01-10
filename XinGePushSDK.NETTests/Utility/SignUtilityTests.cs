using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinGePushSDK.NET.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace XinGePushSDK.NET.Utility.Tests
{
    [TestClass()]
    public class SignUtilityTests
    {
        [TestMethod()]
        public void GetSignatureTest()
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("access_id", "123");
            parameters.Add("timestamp", "1386691200");
            parameters.Add("Param1", "Value1");
            parameters.Add("Param2", "Value2");
            Assert.AreEqual(SignUtility.GetSignature(parameters, "abcde", "openapi.xg.qq.com/v2/push/single_device"), "6b90c7f4a137c7d0b756d48f748c93b2");
        }
    }
}
