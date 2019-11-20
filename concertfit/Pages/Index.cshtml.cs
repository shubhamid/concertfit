using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using concertfit.Controllers;
using System.Net;
using SpotifyArtistsResponse;
using concertfit.Models;
namespace concertfit.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using (WebClient webClient = new WebClient())
            {

                string jsonDataSpotify = webClient.DownloadString("https://concertfitapis20191118021024.azurewebsites.net/api/spotify");
                var topLevel = TopLevel.FromJson(jsonDataSpotify);
                ViewData["SpotifyMaster"] = topLevel;


            }
        }
    }
}
