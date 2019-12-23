using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using TelegramBot.Models.Commands;

namespace TelegramBot.Models
{
    public static class TelegaBot
    {
        private static Telegram.Bot.TelegramBotClient botClient;
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get { return commandsList.AsReadOnly();} }

        public static async Task<TelegramBotClient> Get()
        {
            if(botClient != null)
            {
                return botClient;
            }

            //TODO: add more commands

            commandsList = new List<Command>();
            commandsList.Add(new MainCommand());
            commandsList.Add(new AllCommand());
            commandsList.Add(new CrackerCommand());


            botClient = new TelegramBotClient(AppSettings.BOTKEY);
            var hook = string.Format(AppSettings.URL, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }

    }
}