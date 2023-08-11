using EasyAutomationFramework;
using EasyAutomationFramework.Model;
using System.Data;
using WebScrapingC_.Driver;

var web = new WebScraper();
var site = web.GetData("https://www.globo.com/");

var dados = new ParamsDataTable("Dados extraidos", @"C:\Temp", new List<DataTables>()
{
    new DataTables("Noticias", site)
});

Base.GenerateExcel(dados);