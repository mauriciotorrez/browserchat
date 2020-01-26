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
            string resultMessage = message;
     
            int firstStringPosition = message.IndexOf("/stock=") + 7;
            resultMessage = message.Substring(firstStringPosition, message.Length- firstStringPosition);

            if (!String.IsNullOrEmpty(resultMessage))
            {
                resultMessage = CSVParser.GetMessage(resultMessage);
            }
            else
            {
                resultMessage = "Sorry I cannot process your stock_code command";
            }

            await Clients.All.SendAsync("ReceiveMessage", "BOT", resultMessage);
        }

    }
}
