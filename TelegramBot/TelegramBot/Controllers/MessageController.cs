using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Models;
using TelegramBot.Models.Commands;

namespace TelegramBot.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = TelegaBot.GetCommands();
            var message = update.Message;
            var client = new TelegramBotClient(AppSettings.BOTKEY);
            bool isGoodCommand = false;
            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    isGoodCommand = true;
                    await command.Execute(message, client);
                    break;
                }
            }

            if (!isGoodCommand)
            {
                ErrorCommand cmd = new ErrorCommand();
                await cmd.Execute(message, client);
            }
            return Ok();
        }
    }
}
