using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfServiceHost
{
    class Program
    {
        //可以将Wcf服务做成dll，然后使用Console控制台作为宿主。 也可以直接把Wcf服务集成在Console控制台，如：在WcfService项目做成Console控制台程序。
        static void Main(string[] args)
        {
            ServiceHost host0 = new ServiceHost(typeof(WcfService.MyService));
            host0.Open();
            Console.WriteLine(string.Format("Wcf服务{0}启动成功！", typeof(WcfService.MyService)));

            ServiceHost host1 = new ServiceHost(typeof(WcfService.ClassService));
            host1.Open();
            Console.WriteLine(string.Format("Wcf服务{0}启动成功！", typeof(WcfService.ClassService)));

            using (ServiceHost host = new ServiceHost(typeof(WcfService.UserService)))
            {
                host.Open();
                Console.WriteLine(string.Format("Wcf服务{0}启动成功！", typeof(WcfService.UserService)));
                Console.ReadLine();
            }
            if (host0.State != CommunicationState.Closed)
            {
                host0.Close();
            }
            if (host1.State != CommunicationState.Closed)
            {
                host1.Close();
            }
        }
    }
}
