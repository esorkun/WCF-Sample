using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFSample.Client
{
    class Program
    {
        [ServiceContract]
        public interface ImessageService
        {
            [OperationContract]
            string[] GetMessages();
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Press ant key to continue");
            Console.ReadLine();
            string uri = "net.tcp://localhost:6565/MessageService";
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            var channel = new ChannelFactory<ImessageService>(binding);
            var endpoint = new EndpointAddress(uri);
            var proxy = channel.CreateChannel(endpoint);
            var result = proxy?.GetMessages();
            if (result != null)
            {
                result.ToList().ForEach(p => {
                    Console.WriteLine(p);
                });
            }
            Console.ReadLine();
        }
    }
}
