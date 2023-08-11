using EasyAutomationFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapingC_.Model;

namespace WebScrapingC_.Driver
{
    public class WebScraper : Web
    {
        public DataTable GetData(string link)
        {
            if (driver == null)
            StartBrowser();

            var itens = new List<Item>();
            
            Navigate(link);

            var elements = GetValue(TypeElement.Xpath, "/html/body/section[3]/div").element.FindElements(By.ClassName("post"));

            foreach (var element in elements) 
            { 
                var item = new Item();
                item.Title = element.FindElement(By.ClassName("title")).Text;
                item.url = element.FindElement(By.ClassName("href")).GetAttribute("href");
                itens.Add(item);
            }


            return Base.ConvertTo(itens);
        }
    }
}
