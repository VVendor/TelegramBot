using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Telegram.Bot;
using TelegramBot.Models;

namespace TelegramBot
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var client = new TelegramBotClient(AppSettings.BOTKEY);
        }
    }
}
