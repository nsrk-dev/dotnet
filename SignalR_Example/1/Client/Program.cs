using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace TransmitData_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:57459/signalr/hubs";
            HubConnection connection = new HubConnection(url);

            try
            {
                var proxy = connection.CreateHubProxy("myHub");
                proxy.On<string>("MessageReceiver", s => {
                    Console.WriteLine(s);
                });

                connection.Start().Wait();
                proxy.Invoke("broadcastServerTime").Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Connected)
                    connection.Stop();
            }


        }
    }
}
