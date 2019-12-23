using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
    public class CrackerCommand : Command
    {
        public override string Name => "/cracker";

        public override async void Execute(Message message, TelegramBotClient botClient)
        {
            string answer = $"Привет, Утка! Кря-Кря)\n {"https://cdn.pixabay.com/photo/2018/03/10/08/35/duck-3213533_1280.jpg"}";
            await botClient.SendTextMessageAsync(message.Chat.Id, answer, disableWebPagePreview: false);
        }
    }
}