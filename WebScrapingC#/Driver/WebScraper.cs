using EasyAutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapingC_.Model;
using HtmlAgilityPack;



namespace WebScrapingC_.Driver
{
    public class WebScraper : Web
    {
        public DataTable GetData(string link)
        {
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(link).Result;

            // Carregar o HTML no documento do HTMLAgilityPack
            var document = new HtmlDocument();
            document.LoadHtml(html);

            if (driver == null)
            StartBrowser();

            var itens = new List<Item>();
            
            Navigate(link);

            var noticias = document.DocumentNode.SelectNodes("//a");
            var Titulo = document.DocumentNode.SelectSingleNode("//h2[@class='post__title']");
            var URL = document.DocumentNode.SelectSingleNode("//a[@class='post__link']");


            if (noticias != null)
            {
                
                  foreach (var element in noticias)
                  {
                     var item = new Item();
                     item.Title = element.InnerText;
                     item.url = element.GetAttributeValue("href", "");
                     itens.Add(item);
                  }
            }
            
            if (driver != null)
            {
                driver.Quit();
            }

            return Base.ConvertTo(itens);
        }
    }
}
