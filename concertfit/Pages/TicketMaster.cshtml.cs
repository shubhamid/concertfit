using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace concertfit.Pages
{
    public class TicketMasterModel : PageModel
    {
        public void OnGet()
        {
            using (WebClient webClient = new WebClient())
            {
                // get the raw JSON data.
                string jsonDataTicketmaster = webClient.DownloadString("https://concertfitapis20191118021024.azurewebsites.net/api/ticketmaster");
                TicketMasterResponse.TopLevel topLevelTicketMaster = TicketMasterResponse.TopLevel.FromJson(jsonDataTicketmaster);
                ViewData["TicketMaster"] = topLevelTicketMaster;

                string jsonDataSpotify = webClient.DownloadString("https://concertfitapis20191118021024.azurewebsites.net/api/spotify");
                SpotifyArtistsResponse.TopLevel[] topLevelSpotify = SpotifyArtistsResponse.TopLevel.FromJson(jsonDataSpotify);
                ViewData["SpotifyMaster"] = topLevelSpotify;


            }
        }
    }
}