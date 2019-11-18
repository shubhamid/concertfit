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
            String myName = "Shubham Das";
            int age = 25;
            ViewData["MyName"] = myName;
            ViewData["age"] = age;

            using (WebClient webClient = new WebClient())
            {
                // get the raw JSON data.
                string jsonDataTicketmaster = webClient.DownloadString("https://concertfitapis20191118021024.azurewebsites.net/api/ticketmaster");
                TicketMasterResponse.TopLevel topLevelTicketMaster = TicketMasterResponse.TopLevel.FromJson(jsonDataTicketmaster);

                string jsonDataSpotify = webClient.DownloadString("https://concertfitapis20191118021024.azurewebsites.net/api/spotify");
                SpotifyArtistsResponse.TopLevel[] topLevelSpotify = SpotifyArtistsResponse.TopLevel.FromJson(jsonDataSpotify);

                //Console.WriteLine(topLevel.ToString());
                // Marshall the data into a series of objects.
                /*QuickType.Welcome welcome = QuickType.Welcome.FromJson(jsonData);
                // get the list (collection) of specimens
                List<QuickType.Specimen> allSpecimens = welcome.Specimens;
                // iterate over the specimens so we can shake hands with them.
                foreach (QuickType.Specimen specimen in allSpecimens)
                {
                    // shake hands with one specimen at a time.
                    Console.WriteLine(specimen);
                }*/ 
            }
        }
    }
}