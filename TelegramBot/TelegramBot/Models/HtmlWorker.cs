using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace TelegramBot.Models
{
    public class HtmlWorker
    {
        public string getHtmlPage(string url)
        {
            WebRequest reqGet = WebRequest.Create(url);
            WebResponse response = reqGet.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string htmlPage = sr.ReadToEnd();
            return htmlPage;
        }

        public IHtmlDocument getHtmlDocument(string htmlPage) => new AngleSharp.Html.Parser.HtmlParser().ParseDocument(htmlPage);

        public IEnumerable<IElement> getTable(string htmlPage, string table_className)
        {
            var document = getHtmlDocument(htmlPage);
            return document.QuerySelectorAll("table").Where(item => item.ClassName != null && item.ClassName == table_className).
                Select(item => item.QuerySelector("tbody"));
        }

        public List<Currency> getBestCurrency(IEnumerable<IElement> kurs_table)
        {
            List<Currency> bestCurrencyList = new List<Currency>();
            foreach (var table_elem in kurs_table)
                foreach (var trTagInfo in table_elem.QuerySelectorAll("tr"))
                {
                    if (trTagInfo.HasAttribute("data-href"))
                    {
                        Currency bestCurrencyNow = new Currency();
                        bestCurrencyNow.Link = getHref(trTagInfo);
                        bestCurrencyNow.Name = getName(trTagInfo);
                        IElement[] array = getMainInfoAboutCurr(trTagInfo);
                        bestCurrencyNow.Money_Buy = array[0].TextContent.Trim();
                        bestCurrencyNow.Money_Send = array[1].TextContent.Trim();
                        bestCurrencyNow.Changing = array[3].TextContent.Trim();
                        bestCurrencyList.Add(bestCurrencyNow);
                    }
                }

            return bestCurrencyList;
        }

        public string getHref(IElement element) => element.QuerySelector("a").GetAttribute("href").Trim();
        public string getName(IElement element) => element.QuerySelector("a").Text().Trim();
        public IElement[] getMainInfoAboutCurr(IElement elem) => elem.QuerySelectorAll("p").ToArray();
    }
}