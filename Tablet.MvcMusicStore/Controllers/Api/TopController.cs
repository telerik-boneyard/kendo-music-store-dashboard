using System.Linq;
using System.Web.Http;
using Tablet.MvcMusicStore.Models;

namespace Tablet.MvcMusicStore.Controllers.Api
{
    /// <summary>
    /// Handles requests related to top albumns, tracks and artists
    /// </summary>
    public class TopController : ApiController
    {
        private readonly IDashboardEntities _entities;

        /// <summary>
        /// Tracks query encapsulation
        /// </summary>
        private IQueryable<Track> TopTracks
        {
            get
            {
                return _entities.Albums
                                .SelectMany(a => a.Tracks)
                                .OrderBy(t => t.Rank).AsQueryable();
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TopController"/>
        /// </summary>
        /// <param name="entities">An <see cref="IDashboardEntities"/> dependency.</param>
        public TopController(IDashboardEntities entities)
        {
            _entities = entities;
        }

        /// <summary>
        /// Retrieves the store's top albums
        /// </summary>
        /// <remarks>GET: /Top/Albums</remarks>
        /// <returns>A dynamic structure containing album info.</returns>
        [HttpGet]
        public dynamic Albums()
        {
            return _entities.Albums
                            .OrderByDescending(t => t.ArtistId)
                            .Take(5).ToList()
                            .Select(a => new
                                             {
                                                 Name = a.Title,
                                                 a.Price,
                                                 ArtUrl = a.AlbumArtUrl
                                             });
        }

        /// <summary>
        /// Retrieves the store's top artists
        /// </summary>
        /// <remarks>GET: /Top/Artists</remarks>
        /// <returns>A dynamic structure containing artist info.</returns>
        [HttpGet]
        public dynamic Artists()
        {
            //Implement artist ranking logic here...

            return _entities.Artists
                //Only chose from those albums that have at least 5 tracks...
                            .Where(a => a.Albums.SelectMany(t => t.Tracks).Count() >= 5)
                //Order by Rank (Rank is randomly assigned in SampleData.Seed)
                            .OrderBy(a => a.Rank).Take(5).ToList()
                            .Select(a => new {Name = a.Name.TrimName(), Id = a.ArtistId});
        }

        /// <summary>
        /// Retrieves the store's top tracks
        /// </summary>
        /// <remarks>GET: /Top/Tracks</remarks>
        /// <returns>A dynamic structure containing track info.</returns>
        [HttpGet]
        public dynamic Tracks()
        {
            return TopTracks.Take(10)
                            .Select(s => new
                            {
                                SongId = s.TrackId,
                                s.Name,
                                AlbumName = s.Album.Title,
                                Price = .99,
                                ArtUrl = s.Album.AlbumArtUrl
                            });
        }

        /// <summary>
        /// Retrieve's the store's top tracks by artist
        /// </summary>
        /// <remarks>GET: /Top/Tracks/{artistId}</remarks>
        /// <param name="artistId">An <see cref="int"/> indicating the artist id</param>
        /// <returns>A dynamic structure containing track info.</returns>
        [HttpGet]
        public dynamic Tracks(int artistId)
        {
            return TopTracks.Where(a => a.Album.ArtistId == artistId).Take(5)
                            .Select(s => new
                            {
                                SongId = s.TrackId,
                                s.Name,
                                ArtistId = artistId,
                                AlbumName = s.Album.Title
                            });
        }
    }
}
