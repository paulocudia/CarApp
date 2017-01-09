using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CarApplication
{
    [HubName("chat")]
    public class MyHub : Hub
    {
        public void send(string user, string message)
        {        
            Clients.All.addMessage(
               user + " says " + message
                );
            //Clients.All.addMessage(message);
        }

        //public void SendMessageData(SendData data)
        //{
        //    Clients.All.newData(data);
        //}

        //public class SendData
        //{
        //    public int Id { get; set; }
        //    public string Data { get; set; }
        //}
    }
}