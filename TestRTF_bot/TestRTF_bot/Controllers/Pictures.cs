using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRTF_bot.Controllers
{
    public static class Pictures
    {
        private static List<string> stickersURL = new List<string>()
        {
            "https://bipbap.ru/wp-content/uploads/2017/08/2-34.jpg",
            "https://bipbap.ru/wp-content/uploads/2017/08/2-51.jpg",
            "https://bipbap.ru/wp-content/uploads/2017/08/4-35.jpg",
            "https://bipbap.ru/wp-content/uploads/2017/08/kitten-cat-wallpaper-10-681x511.jpg",
            "https://bipbap.ru/wp-content/uploads/2017/08/krasivyj_kotik_kot_morda_pushistyj_93328_1024x768.jpg",
            "https://bipbap.ru/wp-content/uploads/2017/08/Koshachij-harakter-kot-hitrets.jpg"
        };

        public static string GetRandomPictureURL()
        {
            var random = new Random();
            return stickersURL[random.Next() % stickersURL.Count];
        }
        public static string f()
        {
            return "https://sun9-49.userapi.com/impg/myb_fBy2FigOtF1-1hweC35LPyaijMs52VLWOg/ACnpvEYmSSs.jpg?size=1919x959&quality=96&sign=d7045fe9c7312ad9242f03bf07be68b9&type=album";
        }
    }
}
