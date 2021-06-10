using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using TestRTF_bot.Models;
using TestRTF_bot.model.database;
using System.Collections.Generic;

namespace TestRTF_bot.Controllers
{
    class BotController
    {
        public string Token { get => "1715034930:AAENUCxxIxZH88L-LsxUzuWLZ5rGx37e0LQ"; }
        public TelegramBotClient client;
        private Dictionary<long, UserState> users;
        public GettingComponentsController gettingComponentsController;
        public MenuController menuController;

        public BotController()
        {
            client = new TelegramBotClient(Token);
            users = new Dictionary<long, UserState>();
            gettingComponentsController = new GettingComponentsController(client, users);
            menuController = new MenuController(client, users);
        }

        public void OnMessageEvent(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null)
                return;
            var userID = message.Chat.Id;
            Console.WriteLine($"{userID} Пришло сообщение с текстом: {message.Text}");
            if (!users.ContainsKey(message.Chat.Id))
                users[message.Chat.Id] = new UserState(new UserInformation(), State.Menu);
            if (message.Text == "Назад")
                users[userID].State = State.Menu;
            if (message.Text == "/start" || users[userID].State == State.Menu)
            {
                users[userID].State = State.Menu;
                menuController.OnMessageMenu(sender, e);
            }
            if (users[userID].State != State.Menu)
                gettingComponentsController.OnMessageGettingComponent(sender, e);

        }
    }   
}
