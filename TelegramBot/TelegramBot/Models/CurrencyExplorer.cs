using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TelegramBot.Models
{
    public class CurrencyExplorer
    {
        List<Currency> currencyList;
        HtmlWorker worker = new HtmlWorker();
        public CurrencyExplorer()
        {
            readCurrency();
        }

        public void readCurrency()
        {
            string htmlPage = worker.getHtmlPage(AppSettings.CURRENCYURL);
            var kurs_table = worker.getTable(htmlPage, AppSettings.TABLECLASSNAME);
            currencyList = worker.getBestCurrency(kurs_table);
        }

        public string getInfoAboutCurr(string typeCurrency)
        {
            StringBuilder sb = new StringBuilder();
            int end = 0;
            if (typeCurrency.Equals("main")) end = 3;
            else end = currencyList.Count;
            for (int i = 0; i < end; i++)
            {
                sb.Append(currencyList[i].ToString() + "\n");
            }
            return sb.ToString();
        }

    }
}