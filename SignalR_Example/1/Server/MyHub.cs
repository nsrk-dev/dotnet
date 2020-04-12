using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TransmitData
{
    public class MyHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void BroadcastServerTime()
        {
            Clients.All.MessageReceiver(DateTime.Now.ToString());
        }
    }
}