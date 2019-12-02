using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using concertfit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace concertfit.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonDataTicketmaster = webClient.DownloadString("https://concertfit20191109074437.azurewebsites.net/api");
                //ConcertfitResponse 
                ConcertfitApiResponse.TopLevel[] topLevelConcertfitApiResponse = ConcertfitApiResponse.TopLevel.FromJson(jsonDataTicketmaster);
                ViewData["concertfitResponse"] = topLevelConcertfitApiResponse;
            }
        }
    }
}
