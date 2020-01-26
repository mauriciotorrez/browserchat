using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using BrowserChat.Controllers;
using BrowserChat.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace BrowserChatTest
{
    public class EndPointTests
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HomeView()
        {            
            HomeController controller = new HomeController(_logger);
            var result = controller.Index();
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void ChatHub()
        {
            ChatHub controller = new ChatHub();
            Assert.IsNotNull(controller);
        }

        [Test]
        public void ChatBotHub()
        {
            ChatBotHub controller = new ChatBotHub();
            Assert.IsNotNull(controller);
        }


    }
}
