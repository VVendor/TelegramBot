using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramBot.Models
{
    public static class AppSettings
    {
        public static string CURRENCYURL = "https://finance.tut.by/kurs/";
        public static string TABLECLASSNAME = "tbl-lite rates-table";
        public static string BOTKEY = "Api_key";
        public static string URL = "https://telegrambotapp.azurewebsites.net:443/{0}";
    }
}
