using System.Collections.Generic;
using TelegramBot.Models.Commands;

namespace TelegramBot.Models
{
    public static class TelegaBot
    {
        public static List<Command> GetCommands()
        {
            List<Command> commandsList = new List<Command>();
            commandsList.Add(new MainCommand());
            commandsList.Add(new AllCommand());
            commandsList.Add(new CrackerCommand());
            commandsList.Add(new StartCommand());
            return commandsList;
        }

    }
}
