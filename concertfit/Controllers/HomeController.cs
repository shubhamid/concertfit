using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using concertfit.Models;
using Microsoft.AspNetCore.Mvc;
using SpotifyArtistsResponse;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace concertfit.Controllers
{
    
    [Route("TicketMaster")]
    [BindProperties(SupportsGet = true)]
    public class HomeController : Controller
    {
        [HttpGet]
        public List<ConcertfitResponse> Get()
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonDataTicketmaster = webClient.DownloadString("https://concertfitapis20191118021024.azurewebsites.net/api/ticketmaster");
                TicketMasterResponse.TopLevel topLevelTicketMaster = TicketMasterResponse.TopLevel.FromJson(jsonDataTicketmaster);

                string jsonDataSpotify = webClient.DownloadString("https://concertfitapis20191118021024.azurewebsites.net/api/spotify");
                SpotifyArtistsResponse.TopLevel[] topLevelSpotify = SpotifyArtistsResponse.TopLevel.FromJson(jsonDataSpotify);

                List<ConcertfitResponse> concertfitResponseList = new List<ConcertfitResponse>();

                IDictionary<string, TicketMasterResponse.Event> events = new Dictionary<string, TicketMasterResponse.Event>();
                foreach (TicketMasterResponse.Event evnt in topLevelTicketMaster.Embedded.Events)
                {
                    events.TryAdd(evnt.Name, evnt);
                }

                foreach (SpotifyArtistsResponse.TopLevel topLevel in topLevelSpotify)
                {
                    ConcertfitResponse concertfitResponse = new ConcertfitResponse
                    {
                        Artist = topLevel.Artist,
                        Track = topLevel.Tracks,
                        EventName = events[topLevel.Artist].Name,
                        EventUrl = events[topLevel.Artist].Url.ToString(),
                        Dates = events[topLevel.Artist].Dates,
                    };

                    concertfitResponseList.Add(concertfitResponse); 
                }
                return concertfitResponseList;
            }
        }
    }
}

