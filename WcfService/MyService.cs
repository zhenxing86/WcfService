using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“MyService”。
    public class MyService : IMyService
    {
        public void DoWork()
        {
            Console.WriteLine(string.Format("{0} is running...", typeof(MyService)));
        }
    }
}
