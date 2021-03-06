using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public virtual async Task Execute(Message message, TelegramBotClient botClient) { }
        public bool Contains(string command)
        {
            return command.Contains(this.Name); //&& command.Contains(AppSettings.BOTNAME);
        }
    }
}
