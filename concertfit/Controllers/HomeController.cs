using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using concertfit.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace concertfit.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            string jsonDataTicketmaster = GetJsonString("https://concertfitapis20191118021024.azurewebsites.net/api/ticketmaster");
            TicketMasterResponse.TopLevel topLevelTicketMaster = TicketMasterResponse.TopLevel.FromJson(jsonDataTicketmaster);

            string jsonDataSpotify = GetJsonString("https://concertfitapis20191118021024.azurewebsites.net/api/spotify");
            SpotifyArtistsResponse.TopLevel[] topLevelSpotify = SpotifyArtistsResponse.TopLevel.FromJson(jsonDataSpotify);

            List<ConcertfitResponse> concertfitResponseList = new List<ConcertfitResponse>();

            IDictionary<string, TicketMasterResponse.Event> events = new Dictionary<string, TicketMasterResponse.Event>();
            foreach (TicketMasterResponse.Event evnt in topLevelTicketMaster.Embedded.Events)
            {
                events.TryAdd(evnt.Name, evnt);
            }

            foreach (SpotifyArtistsResponse.TopLevel topLevel in topLevelSpotify)
            {
                ConcertfitResponse concertfitResponse = new ConcertfitResponse();
                concertfitResponse.Artist = topLevel.Artist;
                concertfitResponse.Track = topLevel.Tracks;
                concertfitResponse.EventName = events[topLevel.Artist].Name;
                concertfitResponse.EventUrl = events[topLevel.Artist].Url.ToString();
                concertfitResponse.Dates = events[topLevel.Artist].Dates;
                concertfitResponseList.Add(concertfitResponse);
            }

            return new JsonResult(concertfitResponseList);
        }

        private string GetJsonString(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.DownloadString(url);
            }
        }
    }
}
