using CarApplication.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;

namespace CarApplication.Hubs
{
    [HubName("myChatHub")]
    public class SendHub : Hub
    {
        public void send(string message)
        {
            Clients.All.addMessage(message);
        }
    }
}