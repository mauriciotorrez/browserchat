using BrowserChat.CSVHelpers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserChat.Hubs
{
    public class ChatBotHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {

            //try
            //{
            //    //CSVParser.PraseCSV().Where()
            //}
            
            await Clients.All.SendAsync("ReceiveMessage", "BOT", message);
        }

    }
}
