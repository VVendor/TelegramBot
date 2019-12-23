using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramBot.Models
{
    public class Currency
    {
        public Currency() { }
        public string Name { get; set; }
        public string Money_Send { get; set; } // продажа
        public string Money_Buy { get; set; } // покупка
        public string Link { get; set; }
        public string Changing { get; set; }
        public string ToString() => $"\nВалюта: {Name} \nБанк покупает : {Money_Buy} \nБанк продает : {Money_Send} \nИзменение:{Changing} \nЛучшие банки: {Link} \n";
    }
}