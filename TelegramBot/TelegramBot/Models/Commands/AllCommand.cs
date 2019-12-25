using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
    public class AllCommand : Command
    {
        public override string Name => "/all";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            CurrencyExplorer explorer = new CurrencyExplorer();
            explorer.readCurrency();
            string answer = explorer.getInfoAboutCurr("all");
            await botClient.SendTextMessageAsync(message.Chat.Id, answer, disableWebPagePreview: true);
        }
    }
}
