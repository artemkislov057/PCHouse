using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace TestRTF_bot.Controllers
{
    public class Buttons
    {
        public static IReplyMarkup GetButtonsByState(State state)
        {
            switch (state)
            {
                case State.Menu:
                    return GetStartButton();
                case State.ChoosingTarget:
                    return GetTargetButtons();
                //case State.ChoosingBudget:
                //    return GetBudgetButtons();
                case State.End:
                    return GetAgainBackButtons();        
            }
            return new ReplyKeyboardMarkup();
        }
        public static IReplyMarkup GetStartButton()
        {
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                {
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "Подобрать ПК"} },
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "Наша команда"} }
                }
            };
        }

        public static IReplyMarkup GetBudgetButtons()
        {
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                {
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "< 40 тыс. руб." },
                                                 new KeyboardButton() { Text = "40 - 50 тыс. руб." },
                                                 new KeyboardButton() { Text = "50 - 60 тыс. руб." }},
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "60 - 70 тыс. руб." },
                                                 new KeyboardButton() { Text = "70 - 80 тыс. руб." },
                                                 new KeyboardButton() { Text = "80 - 100 тыс. руб." }},
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "> 100 тыс. руб." } }
                }
            };
        }

        public static IReplyMarkup GetTargetButtons()
        {
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                {
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "Гейминг" },
                                                 new KeyboardButton() { Text = "Офис" } },
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "Работа с видео" },
                                                 new KeyboardButton() { Text = "Программирование" } },
                }
            };
        }

        public static IReplyMarkup GetAgainBackButtons()
        {
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                {
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "Подобрать другой ПК" } },
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "Назад" } }
                }
            };
        }
    }
}
