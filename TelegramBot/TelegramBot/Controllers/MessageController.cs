using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
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
            var commands = TelegaBot.Commands;
            var message = update.Message;
            var client = await TelegaBot.Get();
            bool isGoodCommand = false;
            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    isGoodCommand = true;
                    command.Execute(message, client);
                    break;
                }
            }

            if (!isGoodCommand)
            {
                new ErrorCommand().Execute(message, client);
            }

            return Ok();
        }
    }
}
