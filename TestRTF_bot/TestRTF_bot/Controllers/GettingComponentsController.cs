using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using TestRTF_bot.model;
using TestRTF_bot.model.database;
using TestRTF_bot.Models;

namespace TestRTF_bot.Controllers
{
    class GettingComponentsController
    {
        public TelegramBotClient client;
        private Dictionary<long, UserState> users;
        private ComponentPicker componentPicker;

        public GettingComponentsController(TelegramBotClient client, Dictionary<long, UserState> users)
        {
            componentPicker = new ComponentPicker();
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
            { "< 40 тыс. руб.", new Budget(30000, 40000) },
            { "40 - 50 тыс. руб.", new Budget(40000, 50000) },
            { "50 - 60 тыс. руб.", new Budget(50000, 60000) },
            { "60 - 70 тыс. руб.", new Budget(60000, 70000) },
            { "70 - 80 тыс. руб.", new Budget(70000, 80000) },
            { "80 - 100 тыс. руб.", new Budget(80000, 100000) },
            { "> 100 тыс. руб.", new Budget(100000, 120000) }
        };

        public async void OnMessageGettingComponent(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message == null)
                return;
            var userID = message.Chat.Id;
            Console.WriteLine($"{userID} Пришло сообщение с текстом: {message.Text}");
            if (!users.ContainsKey(message.Chat.Id))
                users[message.Chat.Id] = new UserState(new UserInformation(), State.ChoosingMinBudget);
            if (message.Text == "Подобрать другой ПК")
                users[userID].State = State.ChoosingMinBudget;
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
            else if (currentState == State.ChoosingMinBudget)
            {
                await client.SendTextMessageAsync(
                        userID,
                        "Нам нужно знать границы вашего бюджета. \nКакую минимальную сумму вы готовы потратить? ",
                        replyMarkup: new ReplyKeyboardRemove());
                users[userID].State++;
            }
            else if (currentState == State.ChoosingMaxBudget)
            {
                users[userID].Info.Budget = new Budget();
                
                users[userID].Info.Budget.MinValue = int.Parse(message.Text);
                await client.SendTextMessageAsync(
                        userID,
                        "Хорошо! Теперь назовите максимальную сумму ",
                        replyMarkup: new ReplyKeyboardRemove());
                users[userID].State++;
            }
            else if (currentState == State.ChoosingTarget/* && possibleBudgets.ContainsKey(message.Text)*/)
            {
                users[userID].Info.Budget.MaxValue = int.Parse(message.Text);
                if (users[userID].Info.Budget.MaxValue < users[userID].Info.Budget.MinValue)
                {
                    users[userID].State = State.ChoosingMaxBudget;
                    OnMessageGettingComponent(sender, e);
                }
                await client.SendTextMessageAsync(
                        userID,
                        "Компьютеры используются для разных целей, для чего вам нужен ПК?",
                        replyMarkup: Buttons.GetTargetButtons());
                users[userID].State++;
            }
            else if (currentState == State.End && possibleTargets.ContainsKey(message.Text))
            {
                SetTarget(users[userID], message.Text);
                await client.SendPhotoAsync(
                    userID,
                    caption: String.Format("Вам подойдет следующая конфигурация: \n"
                                          + GetBestConfigurationsByPicker(users[userID].Info)),
                    photo: Pictures.GetRandomPictureURL(),
                    replyMarkup: Buttons.GetAgainBackButtons());
                users[userID].State = State.ChoosingMinBudget;
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

        private string GetBestConfigurationsByPicker(UserInformation user)
        {
            var result = componentPicker.GetConfigurations(user).FirstOrDefault();
            return result != null ? result.ToString() : "К сожалению, нужная сборка не найдена ";
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
