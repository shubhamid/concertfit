using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace concertfit.Controllers
{
    [Route("getartist")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index([FromQuery(Name = "q")] string q)
        {
            ConcertfitApiResponse.TopLevel topLevel = new ConcertfitApiResponse.TopLevel();
            using (WebClient webClient = new WebClient())
            {
                string jsonDataTicketmaster = webClient.DownloadString("https://concertfit20191109074437.azurewebsites.net/api");
                //ConcertfitResponse 
                ConcertfitApiResponse.TopLevel[] topLevelConcertfitApiResponse = ConcertfitApiResponse.TopLevel.FromJson(jsonDataTicketmaster);
                foreach (ConcertfitApiResponse.TopLevel artist in topLevelConcertfitApiResponse){
                    if(artist.Artist == q)
                    {
                        topLevel = artist;
                    }
                }
            }

            string songs = "";
            foreach(ConcertfitApiResponse.Track track in topLevel.Track)
            {
                songs +=
                "                        <tr>" +
                "                            <td>Track Name:</td>" +
                "                            <td>"+track.Name+"</td>" +
                "                        </tr>" +
                "                        <tr>" +
                "                            <td>Preview: </td>" +
                "                            <td>" +
                "                                <video controls name=\"media\" width=\"100 % \" height=\"30 % \">" +
                "                                    <source src="+track.PreviewUrl.ToString()+" type=\"audio/mpeg\" />" +
                "                                </video>" +
                "                            </td>" +
                "                        </tr>" +
                "                        <tr>" +
                "                            <td>Complete Track </td>" +
                "                            <td><a target=\"_blank\" href=" + track.ExternalUrls.Spotify.ToString()+">on Spotify</a></td>" +
                "                        </tr>";
            }

            string content =
                "<table>" +
                "    <tr>" +
                "        <td>" +
                "            <em>"+topLevel.Artist+"</em>" +
                "            <br />" +
                "            <img alt="+ topLevel.Artist+ " src="+ topLevel.Track[0].Album.Images[1].Url.ToString()+" />" +
                "            <table class=\"table - responsive\">" +
                "                <tr>" +
                "                    <td class=\"font-weight-bold\">Date & Time :</td>" +
                "                    <td>"+topLevel.Dates.Start.DateTime.UtcDateTime.ToString()+"</td>" +
                "                </tr>" +
                "                <tr>" +
                "                    <td class=\"font-weight-bold\">TicketMaster URL :</td>" +
                "                    <td><a href="+topLevel.EventUrl.ToString()+">Event URL</a></td>" +
                "                </tr>" +
                "            </table>" +
                "        </td>" +
                "   </tr>"+
                "   <tr>"+
                "        <td>" +
                "            <div style=\"height: 500px; width: 500px; overflow: auto; \">" +
                "                <div class=\"font-weight-bold\">" +
                "                    Top Songs" +
                "                    <br />" +
                "                </div>" +
                "                <table class=\"table-striped\">" + songs +
                "            </table>" +
                "        </div>" +
                "    </td>" +
                "   </tr>"+
                "</table>";

            return base.Content(content, "text/html");
        }
    }
}