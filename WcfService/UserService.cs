using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        int GetAge();
    }

    public class UserService : IUserService
    {
        public int GetAge()
        {
            return 10;
        }
    }
}
