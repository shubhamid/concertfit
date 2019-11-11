using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace concertfit.Models
{
    public partial class Artist
    {
        [JsonProperty("artists", NullValueHandling = NullValueHandling.Ignore)]
        public Artists Artists { get; set; }

        [JsonProperty("ticketmasterConcert", NullValueHandling = NullValueHandling.Ignore)]
        public TicketmasterConcert TicketmasterConcert { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("founded", NullValueHandling = NullValueHandling.Ignore)]
        public long? Founded { get; set; }

        [JsonProperty("members", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Members { get; set; }
    }

    public partial class ExternalUrls
    {
        [JsonProperty("spotify")]
        public Uri Spotify { get; set; }
    }

    public partial class TicketmasterConcert
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("eventUrl")]
        public Uri EventUrl { get; set; }

        [JsonProperty("promoterId")]
        public long[] PromoterId { get; set; }

        [JsonProperty("dates")]
        public Dates Dates { get; set; }

        [JsonProperty("test")]
        public bool Test { get; set; }

        [JsonProperty("_links")]
        public TicketmasterConcertLinks Links { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public partial class DisplayOptions
    {
        [JsonProperty("range")]
        public Range Range { get; set; }
    }

    public partial class Range
    {
        [JsonProperty("localStartDate")]
        public DateTimeOffset LocalStartDate { get; set; }

        [JsonProperty("localEndDate")]
        public DateTimeOffset LocalEndDate { get; set; }
    }

    public partial class End
    {
        [JsonProperty("dateTime")]
        public string DateTime { get; set; }

        [JsonProperty("localDate")]
        public DateTimeOffset LocalDate { get; set; }

        [JsonProperty("localTime")]
        public DateTimeOffset LocalTime { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public partial class Embedded
    {
        [JsonProperty("venue")]
        public Venue[] Venue { get; set; }

        [JsonProperty("categories")]
        public Category[] Categories { get; set; }

        [JsonProperty("attractions")]
        public Attraction[] Attractions { get; set; }
    }

    public partial class Attraction
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public AttractionImage Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("_links")]
        public AttractionLinks Links { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class AttractionImage
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class AttractionLinks
    {
        [JsonProperty("self")]
        public Attractions Self { get; set; }
    }

    public partial class Attractions
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("_links")]
        public AttractionLinks Links { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Venue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("marketId")]
        public long[] MarketId { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("postalCode")]
        public long PostalCode { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("_links")]
        public AttractionLinks Links { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("line1")]
        public string Line1 { get; set; }

        [JsonProperty("line2")]
        public string Line2 { get; set; }
    }

    public partial class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Country
    {
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public partial class State
    {
        [JsonProperty("stateCode")]
        public string StateCode { get; set; }
    }

    public partial class TicketmasterConcertLinks
    {
        [JsonProperty("self")]
        public Attractions Self { get; set; }

        [JsonProperty("categories")]
        public Attractions[] Categories { get; set; }

        [JsonProperty("attractions")]
        public Attractions Attractions { get; set; }

        [JsonProperty("venue")]
        public Attractions Venue { get; set; }
    }

    public partial class Album
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artist")]
        public ArtistClass Artist { get; set; }

        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }
    }

    public partial class ArtistClass
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("founded")]
        public long Founded { get; set; }

        [JsonProperty("members")]
        public string[] Members { get; set; }
    }

    public partial class Track
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }
    }
}
