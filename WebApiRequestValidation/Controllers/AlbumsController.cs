namespace WebApiRequestValidation.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    using Newtonsoft.Json.Linq;

    using WebApiRequestValidation.Filters;
    using WebApiRequestValidation.Models;

    public class AlbumsController : ApiController
    {
        [QueryStringParametersValidation]
        public IEnumerable<Album> Get(DateTime? releasedFrom = null, DateTime? releasedUntil = null, string albumName = null, string artistName = null)
        {
            return new [] 
            { 
                new Album()
                {
                    Id = 1,
                    ArtistName = "Pearl Jam",
                    Name = "Ten",
                    ReleaseDate = new DateTime(1991, 8, 27)
                }, 
                new Album()
                {
                    Id = 2,
                    ArtistName = "Soundgarden",
                    Name = "Superunknown",
                    ReleaseDate = new DateTime(1994, 3, 8)
                }
            };
        }

        [BodyPropertiesValidation(typeof(Album), "album")]
        public void Patch(int id, [FromBody]JObject album)
        {
            var a = album.ToObject<Album>();
        }
    }
}