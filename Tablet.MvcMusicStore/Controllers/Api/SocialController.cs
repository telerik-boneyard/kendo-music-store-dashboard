using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Tablet.MvcMusicStore.Controllers.Api
{
    /// <summary>
    /// Provides Social network related information
    /// </summary>
    public class SocialController : ApiController
    {
        /// <summary>
        /// Retrieves social network information by artist
        /// </summary>
        /// <param name="artistId">An <see cref="int"/> containing the artist id.</param>
        /// <remarks>GET: /api/Social/Stats</remarks>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<dynamic> Stats(string artistId)
        {
            var random = new Random();

            var to = DateTime.Now.Date;
            var from = to.AddYears(-1);

            for (var date = from; date <= to; date = date.AddMonths(1))
            {
                yield return new
                                 {
                                     ArtistId = artistId,
                                     Likes = random.Next(20000, 40000),
                                     Tweets = random.Next(20000, 40000),
                                     Pluses = random.Next(20000, 40000),
                                     Pins = random.Next(20000, 40000),
                                     Date = date,
                                     Sales = random.Next(100000, 3000000)
                                 };
            }
        }

        /// <summary>
        /// Retrieves the social heat identifier by artist and song
        /// </summary>
        /// <remarks>GET: api/Social/Heat/</remarks>
        /// <param name="artistId">A <see cref="int"/> containing the artist Id</param>
        /// <param name="songId">A <see cref="int"/> containing the song Id.</param>
        /// <returns>A dynamic structure containing the social heat information!</returns>
        [HttpGet]
        public dynamic Heat(string artistId, string songId)
        {
            var random = new Random();
            return new
            {
                Facebook = random.Next(1, 50),
                Twitter = random.Next(1, 50),
                Google = random.Next(1, 50),
                Pinterest = random.Next(1, 50)
            };
        }

        /// <summary>
        /// Retrieves the social awareness metrics
        /// </summary>
        /// <remarks>GET: api/Social/Awareness</remarks>
        /// <param name="artistId"></param>
        /// <returns>A dynamic structure containg the social awareness info!</returns>
        [HttpGet]
        public dynamic Awareness(string artistId)
        {
            var random = new Random();
            return new
            {
                Radial = random.Next(1, 50),
                Linear = random.Next(1, 50)
            };
        }
    }
}