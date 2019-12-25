using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "start";
        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            await botClient.SendVideoAsync(message.Chat.Id, video:"https://frm-wows-ru.wgcdn.co/wows_forum_ru/monthly_2019_04/gif_1553969701.gif.369c1015d0645b002394455d63bde757.gif");
        }
    }
}