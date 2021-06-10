using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using TestRTF_bot.model.database;
using TestRTF_bot.Models;

namespace TestRTF_bot.Controllers
{
    class GettingComponentsController
    {
        public TelegramBotClient client;
        private Dictionary<long, UserState> users;

        public GettingComponentsController(TelegramBotClient client, Dictionary<long, UserState> users)
        {
            this.client = client;
            this.users = users;
        }

        private Dictionary<string, Target> possibleTargets = new Dictionary<string, Target>()
        {
            { "Офис", Target.Office },
            { "Программирование", Target.Programming },
            { "Работа с видео", Target.VideoEditing },
            { "Гейминг", Target.Gaming }
        };
        private Dictionary<string, Budget> possibleBudgets = new Dictionary<string, Budget>
        {
            { "< 40 тыс. руб.", new Budget(30, 40) },
            { "40 - 50 тыс. руб.", new Budget(40, 50) },
            { "50 - 60 тыс. руб.", new Budget(50, 60) },
            { "60 - 70 тыс. руб.", new Budget(60, 70) },
            { "70 - 80 тыс. руб.", new Budget(70, 80) },
            { "80 - 100 тыс. руб.", new Budget(80, 100) },
            { "> 100 тыс. руб.", new Budget(100, 120) }
        };

        public async void OnMessageGettingComponent(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null)
                return;
            var userID = message.Chat.Id;
            Console.WriteLine($"{userID} Пришло сообщение с текстом: {message.Text}");
            if (!users.ContainsKey(message.Chat.Id))
                users[message.Chat.Id] = new UserState(new UserInformation(), State.ChoosingBudget);
            if (message.Text == "Подобрать другой ПК")
                users[userID].State = State.ChoosingBudget;
            if (message.Text == "/start")
                users[userID].State = State.Menu;
            var currentState = users[userID].State;
            if (currentState == State.Menu)
            {
                await client.SendTextMessageAsync(
                        userID,
                        "Привет! Я подборщик комплектующих для твоего нового ПК. Давай скорее подберем компоненты!",
                        replyMarkup: Buttons.GetStartButton());
                users[userID].State++;
            }
            else if (currentState == State.ChoosingBudget)
            {
                await client.SendTextMessageAsync(
                        userID,
                        "Первое, что важно знать - какой вы имеете бюджет?",
                        replyMarkup: Buttons.GetBudgetButtons());
                users[userID].State++;
            }
            else if (currentState == State.ChoosingTarget && possibleBudgets.ContainsKey(message.Text))
            {
                await client.SendTextMessageAsync(
                        userID,
                        "Компьютеры используются для разных целей, чего вам нужен ПК?",
                        replyMarkup: Buttons.GetTargetButtons());
                users[userID].State++;
                SetBudget(users[userID], message.Text);
            }
            else if (currentState == State.End && possibleTargets.ContainsKey(message.Text))
            {
                SetTarget(users[userID], message.Text);
                await client.SendPhotoAsync(
                    userID,
                    caption: String.Format("Вам подойдет следующая конфигурация: \n"
                                          + GetBestConfigurationPC(users[userID].Info)),
                    photo: Pictures.GetRandomPictureURL(),
                    replyMarkup: Buttons.GetAgainBackButtons());
                users[userID].State = State.ChoosingBudget;
            }
            else
            {
                await client.SendTextMessageAsync(
                    userID,
                    text: "Нажмите на одну из предложенных кнопок",
                    replyMarkup: Buttons.GetButtonsByState(users[userID].State - 1));
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
                return "К сожалению, нужная конфигурация не найдена, попробуйте выбрать другой бюджет";
            }
        }

        private void SetTarget(UserState userState, string text)
        {
            if (possibleTargets.ContainsKey(text))
                userState.Info.Target = possibleTargets[text];
        }

        private void SetBudget(UserState userState, string text)
        {
            if (possibleBudgets.ContainsKey(text))
                userState.Info.Budget = possibleBudgets[text];
        }
    }
}
