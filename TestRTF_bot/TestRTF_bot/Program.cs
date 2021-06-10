using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using TestRTF_bot.Controllers;

namespace TestRTF_bot
{
    class Program
    {
        private static BotController botController;
        static void Main(string[] args)
        {
            botController = new BotController();
            botController.client.StartReceiving();
            botController.client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            botController.client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            botController.OnMessageEvent(sender, e);
        }    
    }
}
