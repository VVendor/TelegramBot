using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
    public class ErrorCommand : Command
    {
        public override string Name => "/error";

        public override async void Execute(Message message, TelegramBotClient botClient)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "нет такой команды :(", disableWebPagePreview: true);
        }
    }
}