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

        public BotController()
        {
            users = new Dictionary<long, UserState>();
        }

        public async void OnMessageEvent(object sender, MessageEventArgs e)
        {
            var userID = e.Message.Chat.Id;
            if (!users.ContainsKey(userID))
                users[userID] = new UserState(new UserInformation(), State.Start);
            var message = e.Message;
            if (message != null)
            {
                Console.WriteLine($"{userID} Пришло сообщение с текстом: {message.Text}");
                switch (users[userID].State)
                {
                    case State.Start:
                        if (message.Text != "Начать снова" && message.Text != "/start")
                            break;
                        await client.SendTextMessageAsync(
                            userID,
                            "Введите свой бюджет",
                            replyMarkup: Buttons.GetBudgetButtons());
                        users[userID].State = State.ChoosingBudget;
                        break;
                    case State.ChoosingBudget:
                        await client.SendTextMessageAsync(
                            userID,
                            "Для чего вам нужен ПК?",
                            replyMarkup: Buttons.GetTargetButtons());
                        users[userID].State = State.GettingComponents;
                        SetBudget(users[userID], message.Text);
                        break;
                    case State.GettingComponents:
                        SetTarget(users[userID], message.Text);
                        await client.SendPhotoAsync(
                            userID,
                            caption: String.Format("Вам подойдет следующая конфигурация: \n"
                                                  + GetBestConfigurationPC(users[userID].Info)),
                            photo: Pictures.GetRandomPictureURL(),
                            replyMarkup: Buttons.GetAgainButton());
                        users[userID].State = State.Start;
                        break;
                }
            }
        }

        private string GetBestConfigurationPC(UserInformation user)
        {
            var target = user.Target;
            var budget = user.Budget;
            try
            {
                Configuration result;
                using (var context = new ConfigurationContext())
                {
                    var textTarget = Enum.GetName(typeof(Target), target);
                    var textBudget = budget?.ToString();
                    result = context.Configurations.FirstOrDefault(configuration => configuration.Target == textTarget && configuration.Budget == textBudget);
                }
                return result?.ToString();
            }
            catch
            {
                return null;
            }
        }

        private void SetTarget(UserState userState, string text)
        {
            switch (text)
            {
                case "Офис":
                    userState.Info.Target = Target.Office;
                    break;
                case "Программирование":
                    userState.Info.Target = Target.Programming;
                    break;
                case "Работа с видео":
                    userState.Info.Target = Target.VideoEditing;
                    break;
                case "Гейминг":
                    userState.Info.Target = Target.Gaming;
                    break;
            }
        }

        private void SetBudget(UserState userState, string text)
        {
            switch (text)
            {
                case "< 40 тыс. руб.":
                    userState.Info.Budget = new Budget(30, 40);
                    break;
                case "40 - 50 тыс. руб.":
                    userState.Info.Budget = new Budget(40, 50);
                    break;
                case "50 - 60 тыс. руб.":
                    userState.Info.Budget = new Budget(50, 60);
                    break;
                case "60 - 70 тыс. руб.":
                    userState.Info.Budget = new Budget(60, 70);
                    break;
                case "70 - 80 тыс. руб.":
                    userState.Info.Budget = new Budget(70, 80);
                    break;
                case "80 - 100 тыс. руб.":
                    userState.Info.Budget = new Budget(80, 100);
                    break;
                case "> 100 тыс. руб.":
                    userState.Info.Budget = new Budget(100, 120);
                    break;
            }
        }
    }

    
}
