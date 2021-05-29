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
        public static IReplyMarkup GetStartButtons()
        {
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                {
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "Собрать ПК", } }
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
                                                 new KeyboardButton() { Text = "40 - 50 тыс. руб." } },
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "50 - 60 тыс. руб." },
                                                 new KeyboardButton() { Text = "60 - 70 тыс. руб." } },
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "70 - 80 тыс. руб." } }
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

        public static IReplyMarkup GetAgainButton()
        {
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>()
                {
                    new List<KeyboardButton>() { new KeyboardButton() { Text = "Начать снова" } }
                }
            };
        }
    }
}
