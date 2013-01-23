using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tablet.MvcMusicStore.Models
{
    public class Track
    {
        [ScaffoldColumn(false)]
        public int TrackId { get; set; }

        public Album Album { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public int Rank { get; set; }
    }
}