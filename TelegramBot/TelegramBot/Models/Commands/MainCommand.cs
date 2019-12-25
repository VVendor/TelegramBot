using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
    public class MainCommand : Command
    {
        public override string Name => "/main";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            CurrencyExplorer explorer = new CurrencyExplorer();
            explorer.readCurrency();
            string answer = explorer.getInfoAboutCurr("main");
            await botClient.SendTextMessageAsync(message.Chat.Id, answer, disableWebPagePreview: true);
        }
    }
}
