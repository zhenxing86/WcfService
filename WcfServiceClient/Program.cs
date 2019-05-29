using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//using WcfServiceClient.UserService;

namespace WcfServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            
            /*
             * Console寄宿：利于开发调试，但不是生产环境中的最佳实践。
             */

            //1）在客户端添加服务引用的方式引入wcf服务。
            //UserService.UserServiceClient usc = new UserService.UserServiceClient();
            //Console.WriteLine(usc.GetAge());


            //2）在客户端编码方式引入wcf服务。
            sw.Start();

            var factory = new ChannelFactory<IUserService>(new WSHttpBinding(), new EndpointAddress("http://localhost:12451/UserService/")); //WSHttpBinding
            //var factory = new ChannelFactory<IUserService>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:111/User/"));     //NetTcpBinding
            var client = factory.CreateChannel();
            Console.WriteLine(client.GetAge());

            var factory0 = new ChannelFactory<IMyService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:12451/MyService/"));  //BasicHttpBinding
            //var factory0 = new ChannelFactory<IMyService>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:111/MyService/"));  //NetTcpBinding
            var client0 = factory0.CreateChannel();
            client0.DoWork();

            var factory1 = new ChannelFactory<IClassService>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:111/ClassService/")); //NetTcpBinding
            var client1 = factory1.CreateChannel();
            client1.DoWork();
            sw.Stop();
            Console.WriteLine(string.Format("耗时：{0}.", sw.ElapsedMilliseconds));

            /*
             * IIS寄宿：此寄宿在实战项目中得到了广泛的应用。
                        好处有：随系统启动和停止。
                        iis有大量的管理策略对其进行管理。
                        即想利用wcf的功能，还想访问asp.net的功能。 
             * */
            sw.Start();
            var factory2 = new ChannelFactory<IService1>(new WSHttpBinding(), new EndpointAddress("http://localhost:1111/Service1.svc"));  //IIS寄宿，wse binding已经实现
            //var factory2 = new ChannelFactory<IService1>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:101/Service1.svc"));  //IIS寄宿，net.tcp binding已经实现，参考：https://www.cnblogs.com/Gyoung/archive/2012/12/11/2812555.html
            var client2 = factory2.CreateChannel();
            Console.WriteLine(client2.GetData(12)); 
            sw.Stop();
            Console.WriteLine(string.Format("耗时：{0}.", sw.ElapsedMilliseconds));

            Console.ReadLine();
        }
    }
}
