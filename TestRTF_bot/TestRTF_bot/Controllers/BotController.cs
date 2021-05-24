using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using TestRTF_bot.Models;
using TestRTF_bot.model.database;

namespace TestRTF_bot.Controllers
{
    class BotController
    {
        public string Token { get => "1715034930:AAENUCxxIxZH88L-LsxUzuWLZ5rGx37e0LQ"; }
        public TelegramBotClient client;
        public Budget Budget;
        public Target target;
        private State state;

        public BotController()
        {
            state = State.Start;
        }

        public async void OnMessageEvent(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом: {message.Text}");
                switch (state)
                {
                    case State.Start:
                        await client.SendTextMessageAsync(
                            message.Chat.Id,
                            "Введите свой бюджет",
                            replyMarkup: Buttons.GetBudgetButtons());
                        state = State.ChoosingBudget;
                        break;
                    case State.ChoosingBudget:
                        await client.SendTextMessageAsync(
                            message.Chat.Id,
                            "Для чего вам нужен ПК?",
                            replyMarkup: Buttons.GetTargetButtons());
                        state = State.GettingComponents;
                        
                        SetBudget(message.Text);
                        break;
                    case State.GettingComponents:
                        SetTarget(message.Text);
                        await client.SendTextMessageAsync(
                            message.Chat.Id,
                            String.Format("Вам подойдет следующая конфигурация: " + GetBestConfigurationPC(target, Budget)),
                            replyMarkup: Buttons.GetAgainButton());
                        state = State.Start;
                        break;
                }
            }
        }

        private string GetBestConfigurationPC(Target target, Budget budget)
        {
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

        private void SetTarget(string text)
        {
            switch (text)
            {
                case "Офис":
                    target = Target.Office;
                    break;
                case "Программирование":
                    target = Target.Programming;
                    break;
                case "Работа с видео":
                    target = Target.VideoEditing;
                    break;
                case "Гейминг":
                    target = Target.Gaming;
                    break;
            }
        }

        private void SetBudget(string text)
        { 
            switch (text)
            {
                case "< 40 тыс. руб.":
                    Budget = new Budget(30, 40);
                    break;
                case "40 - 50 тыс. руб.":
                    Budget = new Budget(40, 50);
                    break;
                case "50 - 60 тыс. руб.":
                    Budget = new Budget(50, 60);
                    break;
                case "60 - 70 тыс. руб.":
                    Budget = new Budget(60, 70);
                    break;
                case "70 - 80 тыс. руб.":
                    Budget = new Budget(70, 80);
                    break;
            }
        }
    }
}
