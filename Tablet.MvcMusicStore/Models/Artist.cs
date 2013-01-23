using System.Collections.Generic;

namespace Tablet.MvcMusicStore.Models {
    public class Artist {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public int Rank { get; set; }

        public List<Album> Albums { get; set; }
    }
}
