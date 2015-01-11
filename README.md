#腾讯信鸽.NET SDK

##如何安装
>* 建议使用nuget安装包，搜索“信鸽”即可
>* 可以通过clone源码编译出dll文件后引入。**注意项目使用vs2013**

##Restful api接口说明
详细说明请浏览信鸽官方wiki[传送门][1]
  [1]: http://developer.xg.qq.com/index.php/Rest_API

##使用教程

###1，初始化信鸽推送
```c#
XingeApp xinge = new XingeApp("accessId", "secretKey");
```
###2，新建消息
####2.1 IOS消息
```c#
Payload pl = new Payload("这是一个简单的alert");
Msg_IOS mios = new Msg_IOS(pl);
```
####2.2 android消息(这里使用透传消息做演示，更多内容查看源码中Msg目录下消息类)
```c#
Msg_Android mandroid = new Msg_Android_TouChuan("测试", XinGeConfig.message_type_touchuan)
{
    content = "测试"
};
```
###3，使用XingeApp推送消息。注：上方函数android，下方为ios
###3.1Push消息（包括通知和透传消息）给单个设备
```c#
xinge.PushToSingleDevice("DeviceToken", mandroid);
xinge.PushToSingleDevice("DeviceToken", mios, XinGeConfig.IOSENV_DEV);
```
###3.2Push消息（包括通知和透传消息）给单个账户或别名
```c#
xinge.PushToAccount("account", mandroid);
xinge.PushToAccount("account", mios, XinGeConfig.IOSENV_DEV);
```
###3.3Push消息（包括通知和透传消息）给多个账户或别名（批量推送）
```c#
xinge.PushAccountList(new List<string>() { "account1" ,"account2"}, mandroid);
xinge.PushAccountList(new List<string>() { "account1", "account2" }, mios, XinGeConfig.IOSENV_DEV);
```
###3.4Push消息（包括通知和透传消息）给app的所有设备
```c#
xinge.PushAllDevice(mandroid);
            xinge.PushAllDevice(mios,XinGeConfig.IOSENV_DEV);
```
###3.5Push消息（包括通知和透传消息）给tags指定的设备
```c#
xinge.pushTags(new List<string>() { "tag1", "tag1" }, "OR", mandroid);
            xinge.pushTags(new List<string>() { "tag1", "tag1" }, "OR", mios, XinGeConfig.IOSENV_DEV);
```
###3.6查询群发消息发送状态
```c#
xinge.QueryPushStatus(new List<string>() { "pushId1", "pushId1" });
```
###3.7查询应用覆盖的设备数
```c#
xinge.QueryDeviceCount(new List<string>() { "pushId1", "pushId1" });
```
###3.8查询应用的Tags
```c#
xinge.QueryTags(0, 100);
```
###3.9取消尚未触发的定时群发任务
```c#
xinge.CancelTimingPush("pushId1");
```
###3.10批量设置标签
```c#
var tags = new Dictionary<string, string>();
tags.Add("tag1", "token1");
xinge.BatchSetTag(tags);
```
###3.11批量删除标签
```c#
xinge.BatchDelTag(new List<string>() { "tag1", "tag2" });
```
###3.12查询应用某token设置的标签
```c#
xinge.QueryTokenTags("deviceToken");
```
###3.13查询应用某标签关联的设备数量
```c#
xinge.QueryTagTokenNum("tag");
```

##使用前请先查看官方Restful接口文档了解详细参数代表含义
from yeanzhi  
2015/1/11