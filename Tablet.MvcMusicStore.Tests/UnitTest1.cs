using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tablet.MvcMusicStore.Models;

namespace Tablet.MvcMusicStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        public void GetAlbumsSongsFromWebService()
        {
            using (var context = new DashboardEntities())
            {
                var albums = context.Albums.Include(a => a.Artist).ToList();
                foreach (var album in albums)
                {

                    using (var client = new HttpClient {BaseAddress = new Uri("http://ws.audioscrobbler.com/2.0/")})
                    {
                        var query =
                            string.Format(
                                "?method=album.getinfo&api_key=7b87f5dd8355cd34847b470feb09c421&artist={0}&album={1}",
                                album.Artist.Name, album.Title);
                        var result = client.GetAsync(query).Result;

                        var content = result.Content.ReadAsStringAsync().Result;

                        var info = XDocument.Parse(content);

                        var tracks = info.Root.Descendants("tracks").Descendants("track");

                        foreach (var track in tracks)
                        {
                            var rank = 0;
                            int.TryParse(track.Attributes("rank").First().Value, out rank);

                            var name = track.Descendants("name").First().Value;
                            var duration = 0;
                            int.TryParse(track.Descendants("duration").First().Value, out duration);

                            Console.WriteLine("{0} {1} {2}", rank, name, duration);
                            var newTrack = new Track
                                               {
                                                   Album = album,
                                                   Duration = duration,
                                                   Name = name,
                                                   Rank = rank
                                               };

                            context.Tracks.Add(newTrack);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void GenerateTrackAddScript()
        {
            using (var context = new DashboardEntities())
            {
                var tracks = context.Tracks.Include(t => t.Album).ToList();

                tracks.ForEach(t =>
                               Console.WriteLine(
                                   "context.Tracks.Add(new Track{{ Name=\"{0}\" , Album=albums.Single(a => a.Title ==\"{1}\"), Duration={2}, Rank={3} }});",
                                   t.Name,
                                   t.Album.Title,
                                   t.Duration,
                                   t.Rank
                                   ));
            }

        }

    }
}