using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace concertfit.Pages
{
    public class GroupAPIIntegrationModel : PageModel
    {
        public void OnGet()
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonData = webClient.DownloadString("https://nobellaureatedetails20191109073523.azurewebsites.net/laureatesByCountry?country=US");
                NobelLaureatesResponse.TopLevel topLevel = NobelLaureatesResponse.TopLevel.FromJson(jsonData);
                ViewData["groupApiResponse"] = topLevel.Laureates;
            }
        }
    }
}