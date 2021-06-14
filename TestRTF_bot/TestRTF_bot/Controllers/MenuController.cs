using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TestRTF_bot.Controllers
{
    public class MenuController
    {
        private TelegramBotClient client;
        private Dictionary<long, UserState> users;
        public MenuController(TelegramBotClient client, Dictionary<long, UserState> users)
        {
            this.client = client;
            this.users = users;
        }

        public async void OnMessageMenu(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "Наша команда")
            {
                await client.SendPhotoAsync(
                    e.Message.Chat.Id,
                    photo: Pictures.f(),
                    caption: "Наша команда: ",
                    replyMarkup: Buttons.GetStartButton()
                    );
            }
            if (e.Message.Text == "Подобрать ПК")
            {
                users[e.Message.Chat.Id].State = State.ChoosingBudget;
                return;
            }
            await client.SendTextMessageAsync(
                e.Message.Chat.Id,
                "Меню: ",
                replyMarkup: Buttons.GetStartButton());
        }
    }
}