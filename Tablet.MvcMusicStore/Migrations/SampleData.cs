using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Tablet.MvcMusicStore.Models;

namespace Tablet.MvcMusicStore.Migrations
{
    internal class SampleData
    {
        private static readonly Random Random = new Random();

        private static string AlbumImg()
        {
            return string.Format("/img/AlbumArt/CD{0}.png", Random.Next(1, 20));
        }

        private static decimal Price()
        {
            return Random.Next(6, 12) + 0.99M;
        }

        public void Seed(DashboardEntities context)
        {
            if (context.Albums.Any())
                return;

            var genres = AddGenres(context);
            var artists = AddArtists(context);
            AddAlbums(context, genres, artists);
            context.SaveChanges();
            AddTracks(context);

            // Handle the historic orders load on a seperate thread, so the user can start using the app while this backfills historic orders.
            //ThreadPool.QueueUserWorkItem(x => AddOrders(context));
            //AddOrders(context);
        }

        private static void AddAlbums(DashboardEntities context, List<Genre> genres, List<Artist> artists)
        {
            context.Albums.AddOrUpdate(new Album { Title = "...And Justice For All", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Metallica"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "10,000 Days", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Tool"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "11i", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Supreme Beings of Leisure"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "1960", Genre = genres.Single(g => g.Name == "Indie"), Price = Price(), Artist = artists.Single(a => a.Name == "Soul-Junk"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "4x4=12 ", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "deadmau5"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "A Lively Mind", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Paul Oakenfold"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "A Rush of Blood to the Head", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Coldplay"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "A Winter Symphony", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Abbey Road", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Beatles"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Achtung Baby", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "U2"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Adrenaline", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Deftones"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Ænima", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Tool"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "After the Goldrush", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Neil Young"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Airdrawn Dagger", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Sasha"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Album Title Goes Here", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "deadmau5"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Alive 2007", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Daft Punk"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "All I Ask of You", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Amen (So Be It)", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Paddy Casey"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Animal Vehicle", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "The Axis of Awesome"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Apocalyptic Love", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Slash"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Automatic for the People", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "R.E.M."), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Babel", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Mumford & Sons"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Bad Motorfinger", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Soundgarden"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Banadeek Ta'ala", Genre = genres.Single(g => g.Name == "World"), Price = Price(), Artist = artists.Single(a => a.Name == "Amr Diab"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Barbie Girl", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "Aqua"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Be Here Now", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Oasis"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Bedrock 11 Compiled & Mixed", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "John Digweed"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Big Bad Wolf ", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Armand Van Helden"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Black", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Metallica"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Blackwater Park", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Opeth"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Blood", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "In This Moment"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Blue", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Weezer"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Boys & Girls", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Alabama Shakes"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Bunkka", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Paul Oakenfold"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Chocolate Starfish And The Hot Dog Flavored Water", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Limp Bizkit"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Ciao, Baby", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "TheStart"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Classic Munkle: Turbo Edition", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Munkle"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Classics: The Best of Sarah Brightman", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Come Away With Me", Genre = genres.Single(g => g.Name == "Jazz"), Price = Price(), Artist = artists.Single(a => a.Name == "Norah Jones"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Comfort Eagle", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Cake"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Common Reaction", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Uh Huh Her "), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Core", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Stone Temple Pilots"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Cornerstone", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Styx"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Cosmicolor", Genre = genres.Single(g => g.Name == "Rap"), Price = Price(), Artist = artists.Single(a => a.Name == "M-Flo"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Cross", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Justice"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Culture of Fear", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Thievery Corporation"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Dakshina", Genre = genres.Single(g => g.Name == "World"), Price = Price(), Artist = artists.Single(a => a.Name == "Deva Premal"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Dark Side of the Moon", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Pink Floyd"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Death Magnetic", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Metallica"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Deep End of Down", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Above the Fold"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Deja Vu", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Crosby, Stills, Nash, and Young"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Di Korpu Ku Alma", Genre = genres.Single(g => g.Name == "World"), Price = Price(), Artist = artists.Single(a => a.Name == "Lura"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Diary of a Madman", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Ozzy Osbourne"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Dirt", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Alice in Chains"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Drum'n'bass for Papa", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Plug"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Duluth", Genre = genres.Single(g => g.Name == "Country"), Price = Price(), Artist = artists.Single(a => a.Name == "Trampled By Turtles"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Dummy", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Portishead"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Earl Scruggs and Friends", Genre = genres.Single(g => g.Name == "Country"), Price = Price(), Artist = artists.Single(a => a.Name == "Earl Scruggs"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Eden", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "El Camino", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Black Keys"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Elegant Gypsy", Genre = genres.Single(g => g.Name == "Jazz"), Price = Price(), Artist = artists.Single(a => a.Name == "Al di Meola"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Elements Of Life", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Tiësto"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Emotion", Genre = genres.Single(g => g.Name == "World"), Price = Price(), Artist = artists.Single(a => a.Name == "Papa Wemba"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Facelift", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Alice in Chains"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Fair Warning", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Van Halen"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Fear of a Black Planet", Genre = genres.Single(g => g.Name == "Rap"), Price = Price(), Artist = artists.Single(a => a.Name == "Public Enemy"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Feels Like Home", Genre = genres.Single(g => g.Name == "Jazz"), Price = Price(), Artist = artists.Single(a => a.Name == "Norah Jones"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Fly", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Four", Genre = genres.Single(g => g.Name == "Blues"), Price = Price(), Artist = artists.Single(a => a.Name == "Blues Traveler"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Further Down the Spiral", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Nine Inch Nails"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Garbage", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Garbage"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Good News For People Who Love Bad News", Genre = genres.Single(g => g.Name == "Indie"), Price = Price(), Artist = artists.Single(a => a.Name == "Modest Mouse"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Gordon", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Barenaked Ladies"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Greatest Hits", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Duck Sauce"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Group Therapy", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Above & Beyond"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Greetings from Michigan", Genre = genres.Single(g => g.Name == "Indie"), Price = Price(), Artist = artists.Single(a => a.Name == "Sufjan Stevens"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Heart On", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Eagles of Death Metal"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Holy Diver", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Dio"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Homework", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Daft Punk"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Houses Of The Holy", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Led Zeppelin"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Human", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Projected"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Hunky Dory", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "David Bowie"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Hymns", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Projected"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Hysteria", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Def Leppard"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "In Absentia", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Porcupine Tree"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "In Between", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "Paul Van Dyk"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "In Rainbows", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Radiohead"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "In the court of the Crimson King", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "King Crimson"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Indestructible", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Rancid"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Infinity", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Journey"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Introspective", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "Pet Shop Boys"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "ISAM", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Amon Tobin"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Jagged Little Pill", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Alanis Morissette"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Kick", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "INXS"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Kill 'Em All", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Metallica"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Kind of Blue", Genre = genres.Single(g => g.Name == "Jazz"), Price = Price(), Artist = artists.Single(a => a.Name == "Miles Davis"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Kiss", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "Carly Rae Jepsen"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Last Call", Genre = genres.Single(g => g.Name == "Country"), Price = Price(), Artist = artists.Single(a => a.Name == "Cayouche"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Le Tigre", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Le Tigre"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Led Zeppelin II", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Led Zeppelin"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Little Earthquakes", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Tori Amos"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Live on Earth", Genre = genres.Single(g => g.Name == "Jazz"), Price = Price(), Artist = artists.Single(a => a.Name == "The Cat Empire"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Living", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Paddy Casey"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Love Changes Everything", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Magical Mystery Tour", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "The Beatles"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Marasim", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Jagjit Singh"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Master of Puppets", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Metallica"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Mechanics & Mathematics", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "Venus Hum"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Mental Jewelry", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Live"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Metallics", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Metallica"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "meteora", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Linkin Park"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Mezzanine", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Massive Attack"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Moving Pictures", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Rush"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Murder Ballads", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Nick Cave and the Bad Seeds"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Music For The Jilted Generation", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "The Prodigy"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "My Name is Skrillex", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Skrillex"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Nevermind", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Nirvana"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "New Divide", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Linkin Park"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "New York Dolls", Genre = genres.Single(g => g.Name == "Punk"), Price = Price(), Artist = artists.Single(a => a.Name == "New York Dolls"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Night At The Opera", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Queen"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Night Castle", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Trans-Siberian Orchestra"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Nkolo", Genre = genres.Single(g => g.Name == "World"), Price = Price(), Artist = artists.Single(a => a.Name == "Lokua Kanza"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "O Brother, Where Art Thou?", Genre = genres.Single(g => g.Name == "Country"), Price = Price(), Artist = artists.Single(a => a.Name == "Alison Krauss"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "O(+>", Genre = genres.Single(g => g.Name == "R&B"), Price = Price(), Artist = artists.Single(a => a.Name == "Prince"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Oceania", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Smashing Pumpkins"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Off the Deep End", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "Weird Al"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "OK Computer", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Radiohead"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "One Love", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "David Guetta"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Operation: Mindcrime", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Queensrÿche"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Opiate", Genre = genres.Single(g => g.Name == "Rock"), Price = 8.99M, Artist = artists.Single(a => a.Name == "Tool"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Paid in Full", Genre = genres.Single(g => g.Name == "Rap"), Price = Price(), Artist = artists.Single(a => a.Name == "Eric B. and Rakim"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Para Siempre", Genre = genres.Single(g => g.Name == "Latin"), Price = Price(), Artist = artists.Single(a => a.Name == "Vicente Fernandez"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Pause", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Four Tet"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Peace Sells... but Who's Buying", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Megadeth"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Physical Graffiti", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Led Zeppelin"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Pinkerton", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Weezer"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Pretty Hate Machine", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Nine Inch Nails"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Prisoner", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Jezabels"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Privateering", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Mark Knopfler"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "PSY's Best 6th Part 1", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "PSY"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Purple", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Stone Temple Pilots"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Raices", Genre = genres.Single(g => g.Name == "Latin"), Price = Price(), Artist = artists.Single(a => a.Name == "Los Tigres del Norte"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Raising Hell", Genre = genres.Single(g => g.Name == "Rap"), Price = Price(), Artist = artists.Single(a => a.Name == "Run DMC"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Raoul and the Kings of Spain ", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Tears For Fears"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Recovery [Explicit]", Genre = genres.Single(g => g.Name == "Rap"), Price = Price(), Artist = artists.Single(a => a.Name == "Eminem"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Reign In Blood", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Slayer"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Relayed", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Yes"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Revolver", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Beatles"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Ride the Lighting ", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Metallica"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Rise of the Phoenix", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Before the Dawn"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Room for Squares", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "John Mayer"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Root Down", Genre = genres.Single(g => g.Name == "Jazz"), Price = Price(), Artist = artists.Single(a => a.Name == "Jimmy Smith"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Rounds", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Four Tet"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Rubber Factory", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Black Keys"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Rust in Peace", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Megadeth"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Saturday Night Fever", Genre = genres.Single(g => g.Name == "R&B"), Price = Price(), Artist = artists.Single(a => a.Name == "Bee Gees"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Scary Monsters and Nice Sprites", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Skrillex"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Second Coming", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Stone Roses"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Serious About Men", Genre = genres.Single(g => g.Name == "Rap"), Price = Price(), Artist = artists.Single(a => a.Name == "The Rubberbandits"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Short Bus", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Filter"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Singles Collection", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "David Bowie"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Six Degrees of Inner Turbulence", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Dream Theater"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Slave To The Empire", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "T&N"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Slouching Towards Bethlehem", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Robert James"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Smash", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Offspring"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Something Special", Genre = genres.Single(g => g.Name == "Country"), Price = Price(), Artist = artists.Single(a => a.Name == "Dolly Parton"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Song(s) You Know By Heart", Genre = genres.Single(g => g.Name == "Country"), Price = Price(), Artist = artists.Single(a => a.Name == "Jimmy Buffett"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Sound of Music", Genre = genres.Single(g => g.Name == "Punk"), Price = Price(), Artist = artists.Single(a => a.Name == "Adicts"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Spiritual State", Genre = genres.Single(g => g.Name == "Rap"), Price = Price(), Artist = artists.Single(a => a.Name == "Nujabes"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Still Life", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Opeth"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Stop Making Sense", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Talking Heads"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Stranger than Fiction", Genre = genres.Single(g => g.Name == "Punk"), Price = Price(), Artist = artists.Single(a => a.Name == "Bad Religion"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Supermodified", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Amon Tobin"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Switched-On Bach", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Wendy Carlos"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Symphony", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Ted Nugent", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Ted Nugent"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Teflon Don", Genre = genres.Single(g => g.Name == "Rap"), Price = Price(), Artist = artists.Single(a => a.Name == "Rick Ross"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Tell Another Joke at the Ol' Choppin' Block", Genre = genres.Single(g => g.Name == "Indie"), Price = Price(), Artist = artists.Single(a => a.Name == "Danielson Famile"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Ten", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Pearl Jam"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Texas Flood", Genre = genres.Single(g => g.Name == "Blues"), Price = Price(), Artist = artists.Single(a => a.Name == "Stevie Ray Vaughan"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Best of 1990–2000", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Bridge", Genre = genres.Single(g => g.Name == "R&B"), Price = Price(), Artist = artists.Single(a => a.Name == "Melanie Fiona"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Cage", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Tygers of Pan Tang"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Chicago Transit Authority", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Chicago "), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Chronic", Genre = genres.Single(g => g.Name == "Rap"), Price = Price(), Artist = artists.Single(a => a.Name == "Dr. Dre"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Crane Wife", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "The Decemberists"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Cure", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "The Cure"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Dark Side Of The Moon", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Pink Floyd"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Divine Conspiracy", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Epica"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Dream of the Blue Turtles", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "Sting"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Final Frontier", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Iron Maiden"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Head and the Heart", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Head and the Heart"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Joshua Tree", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "U2"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Lumineers", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Lumineers"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Southern Harmony and Musical Companion", Genre = genres.Single(g => g.Name == "Blues"), Price = Price(), Artist = artists.Single(a => a.Name == "The Black Crowes"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Spade", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Butch Walker & The Black Widows"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Stone Roses", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Stone Roses"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Suburbs", Genre = genres.Single(g => g.Name == "Indie"), Price = Price(), Artist = artists.Single(a => a.Name == "Arcade Fire"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Three Tenors Disc1/Disc2", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Carreras, Pavarotti, Domingo"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Trees They Grow So High", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "The Wall", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Pink Floyd"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Them Crooked Vultures", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Them Crooked Vultures"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "This Is Happening", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "LCD Soundsystem"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Thunder, Lightning, Strike", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Go! Team"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Time to Say Goodbye", Genre = genres.Single(g => g.Name == "Classical"), Price = Price(), Artist = artists.Single(a => a.Name == "Sarah Brightman"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Time, Love & Tenderness", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "Michael Bolton"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Tomorrow Starts Today", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Mobile"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Tuesday Night Music Club", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Sheryl Crow"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Umoja", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "BLØF"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Under the Pink", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Tori Amos"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Undertow", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Tool"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Untrue", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Burial"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Use Your Illusion I", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Guns N' Roses"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Use Your Illusion II", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Guns N' Roses"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Version 2.0", Genre = genres.Single(g => g.Name == "Alternative"), Price = Price(), Artist = artists.Single(a => a.Name == "Garbage"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Wapi Yo", Genre = genres.Single(g => g.Name == "World"), Price = Price(), Artist = artists.Single(a => a.Name == "Lokua Kanza"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Wasteland Discotheque", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Raunchy"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Watermark", Genre = genres.Single(g => g.Name == "Electronic"), Price = Price(), Artist = artists.Single(a => a.Name == "Enya"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "We Were Exploding Anyway", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "65daysofstatic"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "White Pony", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Deftones"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Who's Next", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "The Who"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Wish You Were Here", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Pink Floyd"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "With Oden on Our Side", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Amon Amarth"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Worship Music", Genre = genres.Single(g => g.Name == "Metal"), Price = Price(), Artist = artists.Single(a => a.Name == "Anthrax"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "X&Y", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Coldplay"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Xinti", Genre = genres.Single(g => g.Name == "World"), Price = Price(), Artist = artists.Single(a => a.Name == "Sara Tavares"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Yano", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Yano"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Yesterday Once More Disc 1/Disc 2", Genre = genres.Single(g => g.Name == "Pop"), Price = Price(), Artist = artists.Single(a => a.Name == "The Carpenters"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "Zoso", Genre = genres.Single(g => g.Name == "Rock"), Price = Price(), Artist = artists.Single(a => a.Name == "Led Zeppelin"), AlbumArtUrl = AlbumImg() });
            context.Albums.AddOrUpdate(new Album { Title = "עד גבול האור", Genre = genres.Single(g => g.Name == "World"), Price = Price(), Artist = artists.Single(a => a.Name == "אריק אינשטיין"), AlbumArtUrl = AlbumImg() });
        }

        private static List<Artist> AddArtists(DashboardEntities context)
        {
            var artists = new List<Artist>
            {
                new Artist { Name = "65daysofstatic" },
                new Artist { Name = "Aaron Copland & London Symphony Orchestra" },
                new Artist { Name = "Aaron Goldberg" },
                new Artist { Name = "Above & Beyond" },
                new Artist { Name = "Above the Fold" },
                new Artist { Name = "AC/DC" },
                new Artist { Name = "Accept" },
                new Artist { Name = "Adicts" },
                new Artist { Name = "Adrian Leaper & Doreen de Feis" },
                new Artist { Name = "Aerosmith" },
                new Artist { Name = "Aisha Duo" },
                new Artist { Name = "Al di Meola" },
                new Artist { Name = "Alabama Shakes" },
                new Artist { Name = "Alanis Morissette" },
                new Artist { Name = "Alberto Turco & Nova Schola Gregoriana" },
                new Artist { Name = "Alice in Chains" },
                new Artist { Name = "Alison Krauss" },
                new Artist { Name = "Amon Amarth" },
                new Artist { Name = "Amon Tobin" },
                new Artist { Name = "Amr Diab" },
                new Artist { Name = "Amy Winehouse" },
                new Artist { Name = "Anita Ward" },
                new Artist { Name = "Anthrax" },
                new Artist { Name = "Antônio Carlos Jobim" },
                new Artist { Name = "Apocalyptica" },
                new Artist { Name = "Aqua" },
                new Artist { Name = "Armand Van Helden" },
                new Artist { Name = "Arcade Fire" },
                new Artist { Name = "Audioslave" },
                new Artist { Name = "Bad Religion" },
                new Artist { Name = "Barenaked Ladies" },
                new Artist { Name = "Barry Wordsworth & BBC Concert Orchestra" },
                new Artist { Name = "Bee Gees" },
                new Artist { Name = "Before the Dawn" },
                new Artist { Name = "Berliner Philharmoniker & Hans Rosbaud" },
                new Artist { Name = "Berliner Philharmoniker & Herbert Von Karajan" },
                new Artist { Name = "Billy Cobham" },
                new Artist { Name = "Black Label Society" },
                new Artist { Name = "Black Sabbath" },
                new Artist { Name = "BLØF" },
                new Artist { Name = "Blues Traveler" },
                new Artist { Name = "Boston Symphony Orchestra & Seiji Ozawa" },
                new Artist { Name = "Britten Sinfonia, Ivor Bolton & Lesley Garrett" },
                new Artist { Name = "Bruce Dickinson" },
                new Artist { Name = "Buddy Guy" },
                new Artist { Name = "Burial" },
                new Artist { Name = "Butch Walker & The Black Widows" },
                new Artist { Name = "Caetano Veloso" },
                new Artist { Name = "Cake" },
                new Artist { Name = "Calexico" },
                new Artist { Name = "Carly Rae Jepsen" },
                new Artist { Name = "Carreras, Pavarotti, Domingo" },
                new Artist { Name = "Cássia Eller" },
                new Artist { Name = "Cayouche" },
                new Artist { Name = "Chic" },
                new Artist { Name = "Chicago " },
                new Artist { Name = "Chicago Symphony Orchestra & Fritz Reiner" },
                new Artist { Name = "Chico Buarque" },
                new Artist { Name = "Chico Science & Nação Zumbi" },
                new Artist { Name = "Choir Of Westminster Abbey & Simon Preston" },
                new Artist { Name = "Chris Cornell" },
                new Artist { Name = "Christopher O'Riley" },
                new Artist { Name = "Cidade Negra" },
                new Artist { Name = "Cláudio Zoli" },
                new Artist { Name = "Coldplay" },
                new Artist { Name = "Creedence Clearwater Revival" },
                new Artist { Name = "Crosby, Stills, Nash, and Young" },
                new Artist { Name = "Daft Punk" },
                new Artist { Name = "Danielson Famile" },
                new Artist { Name = "David Bowie" },
                new Artist { Name = "David Coverdale" },
                new Artist { Name = "David Guetta" },
                new Artist { Name = "deadmau5" },
                new Artist { Name = "Deep Purple" },
                new Artist { Name = "Def Leppard" },
                new Artist { Name = "Deftones" },
                new Artist { Name = "Dennis Chambers" },
                new Artist { Name = "Deva Premal" },
                new Artist { Name = "Dio" },
                new Artist { Name = "Djavan" },
                new Artist { Name = "Dolly Parton" },
                new Artist { Name = "Donna Summer" },
                new Artist { Name = "Dr. Dre" },
                new Artist { Name = "Dread Zeppelin" },
                new Artist { Name = "Dream Theater" },
                new Artist { Name = "Duck Sauce" },
                new Artist { Name = "Earl Scruggs" },
                new Artist { Name = "Ed Motta" },
                new Artist { Name = "Edo de Waart & San Francisco Symphony" },
                new Artist { Name = "Elis Regina" },
                new Artist { Name = "Eminem" },
                new Artist { Name = "English Concert & Trevor Pinnock" },
                new Artist { Name = "Enya" },
                new Artist { Name = "Epica" },
                new Artist { Name = "Eric B. and Rakim" },
                new Artist { Name = "Eric Clapton" },
                new Artist { Name = "Eugene Ormandy" },
                new Artist { Name = "Faith No More" },
                new Artist { Name = "Falamansa" },
                new Artist { Name = "Filter" },
                new Artist { Name = "Foo Fighters" },
                new Artist { Name = "Four Tet" },
                new Artist { Name = "Frank Zappa & Captain Beefheart" },
                new Artist { Name = "Fretwork" },
                new Artist { Name = "Funk Como Le Gusta" },
                new Artist { Name = "Garbage" },
                new Artist { Name = "Gerald Moore" },
                new Artist { Name = "Gilberto Gil" },
                new Artist { Name = "Godsmack" },
                new Artist { Name = "Gonzaguinha" },
                new Artist { Name = "Göteborgs Symfoniker & Neeme Järvi" },
                new Artist { Name = "Guns N' Roses" },
                new Artist { Name = "Gustav Mahler" },
                new Artist { Name = "In This Moment" },
                new Artist { Name = "Incognito" },
                new Artist { Name = "INXS" },
                new Artist { Name = "Iron Maiden" },
                new Artist { Name = "Jagjit Singh" },
                new Artist { Name = "James Levine" },
                new Artist { Name = "Jamiroquai" },
                new Artist { Name = "Jimi Hendrix" },
                new Artist { Name = "Jimmy Buffett" },
                new Artist { Name = "Jimmy Smith" },
                new Artist { Name = "Joe Satriani" },
                new Artist { Name = "John Digweed" },
                new Artist { Name = "John Mayer" },
                new Artist { Name = "Jorge Ben" },
                new Artist { Name = "Jota Quest" },
                new Artist { Name = "Journey" },
                new Artist { Name = "Judas Priest" },
                new Artist { Name = "Julian Bream" },
                new Artist { Name = "Justice" },
                new Artist { Name = "Kent Nagano and Orchestre de l'Opéra de Lyon" },
                new Artist { Name = "King Crimson" },
                new Artist { Name = "Kiss" },
                new Artist { Name = "LCD Soundsystem" },
                new Artist { Name = "Le Tigre" },
                new Artist { Name = "Led Zeppelin" },
                new Artist { Name = "Legião Urbana" },
                new Artist { Name = "Lenny Kravitz" },
                new Artist { Name = "Les Arts Florissants & William Christie" },
                new Artist { Name = "Limp Bizkit" },
                new Artist { Name = "Linkin Park" },
                new Artist { Name = "Live" },
                new Artist { Name = "Lokua Kanza" },
                new Artist { Name = "London Symphony Orchestra & Sir Charles Mackerras" },
                new Artist { Name = "Los Tigres del Norte" },
                new Artist { Name = "Luciana Souza/Romero Lubambo" },
                new Artist { Name = "Lulu Santos" },
                new Artist { Name = "Lura" },
                new Artist { Name = "Marcos Valle" },
                new Artist { Name = "Marillion" },
                new Artist { Name = "Marisa Monte" },
                new Artist { Name = "Mark Knopfler" },
                new Artist { Name = "Martin Roscoe" },
                new Artist { Name = "Massive Attack" },
                new Artist { Name = "Maurizio Pollini" },
                new Artist { Name = "Megadeth" },
                new Artist { Name = "Mela Tenenbaum, Pro Musica Prague & Richard Kapp" },
                new Artist { Name = "Melanie Fiona" },
                new Artist { Name = "Men At Work" },
                new Artist { Name = "Metallica" },
                new Artist { Name = "M-Flo" },
                new Artist { Name = "Michael Bolton" },
                new Artist { Name = "Michael Tilson Thomas & San Francisco Symphony" },
                new Artist { Name = "Miles Davis" },
                new Artist { Name = "Milton Nascimento" },
                new Artist { Name = "Mobile" },
                new Artist { Name = "Modest Mouse" },
                new Artist { Name = "Mötley Crüe" },
                new Artist { Name = "Motörhead" },
                new Artist { Name = "Mumford & Sons" },
                new Artist { Name = "Munkle" },
                new Artist { Name = "Nash Ensemble" },
                new Artist { Name = "Neil Young" },
                new Artist { Name = "New York Dolls" },
                new Artist { Name = "Nick Cave and the Bad Seeds" },
                new Artist { Name = "Nicolaus Esterhazy Sinfonia" },
                new Artist { Name = "Nine Inch Nails" },
                new Artist { Name = "Nirvana" },
                new Artist { Name = "Norah Jones" },
                new Artist { Name = "Nujabes" },
                new Artist { Name = "O Terço" },
                new Artist { Name = "Oasis" },
                new Artist { Name = "Olodum" },
                new Artist { Name = "Opeth" },
                new Artist { Name = "Orchestra of The Age of Enlightenment" },
                new Artist { Name = "Os Paralamas Do Sucesso" },
                new Artist { Name = "Ozzy Osbourne" },
                new Artist { Name = "Paddy Casey" },
                new Artist { Name = "Page & Plant" },
                new Artist { Name = "Papa Wemba" },
                new Artist { Name = "Paul D'Ianno" },
                new Artist { Name = "Paul Oakenfold" },
                new Artist { Name = "Paul Van Dyk" },
                new Artist { Name = "Pearl Jam" },
                new Artist { Name = "Pet Shop Boys" },
                new Artist { Name = "Pink Floyd" },
                new Artist { Name = "Plug" },
                new Artist { Name = "Porcupine Tree" },
                new Artist { Name = "Portishead" },
                new Artist { Name = "Prince" },
                new Artist { Name = "Projected" },
                new Artist { Name = "PSY" },
                new Artist { Name = "Public Enemy" },
                new Artist { Name = "Queen" },
                new Artist { Name = "Queensrÿche" },
                new Artist { Name = "R.E.M." },
                new Artist { Name = "Radiohead" },
                new Artist { Name = "Rancid" },
                new Artist { Name = "Raul Seixas" },
                new Artist { Name = "Raunchy" },
                new Artist { Name = "Red Hot Chili Peppers" },
                new Artist { Name = "Rick Ross" },
                new Artist { Name = "Robert James" },
                new Artist { Name = "Roger Norrington, London Classical Players" },
                new Artist { Name = "Royal Philharmonic Orchestra & Sir Thomas Beecham" },
                new Artist { Name = "Run DMC" },
                new Artist { Name = "Rush" },
                new Artist { Name = "Santana" },
                new Artist { Name = "Sara Tavares" },
                new Artist { Name = "Sarah Brightman" },
                new Artist { Name = "Sasha" },
                new Artist { Name = "Scholars Baroque Ensemble" },
                new Artist { Name = "Scorpions" },
                new Artist { Name = "Sergei Prokofiev & Yuri Temirkanov" },
                new Artist { Name = "Sheryl Crow" },
                new Artist { Name = "Sir Georg Solti & Wiener Philharmoniker" },
                new Artist { Name = "Skank" },
                new Artist { Name = "Skrillex" },
                new Artist { Name = "Slash" },
                new Artist { Name = "Slayer" },
                new Artist { Name = "Soul-Junk" },
                new Artist { Name = "Soundgarden" },
                new Artist { Name = "Spyro Gyra" },
                new Artist { Name = "Stevie Ray Vaughan & Double Trouble" },
                new Artist { Name = "Stevie Ray Vaughan" },
                new Artist { Name = "Sting" },
                new Artist { Name = "Stone Temple Pilots" },
                new Artist { Name = "Styx" },
                new Artist { Name = "Sufjan Stevens" },
                new Artist { Name = "Supreme Beings of Leisure" },
                new Artist { Name = "System Of A Down" },
                new Artist { Name = "T&N" },
                new Artist { Name = "Talking Heads" },
                new Artist { Name = "Tears For Fears" },
                new Artist { Name = "Ted Nugent" },
                new Artist { Name = "Temple of the Dog" },
                new Artist { Name = "Terry Bozzio, Tony Levin & Steve Stevens" },
                new Artist { Name = "The 12 Cellists of The Berlin Philharmonic" },
                new Artist { Name = "The Axis of Awesome" },
                new Artist { Name = "The Beatles" },
                new Artist { Name = "The Black Crowes" },
                new Artist { Name = "The Black Keys" },
                new Artist { Name = "The Carpenters" },
                new Artist { Name = "The Cat Empire" },
                new Artist { Name = "The Cult" },
                new Artist { Name = "The Cure" },
                new Artist { Name = "The Decemberists" },
                new Artist { Name = "The Doors" },
                new Artist { Name = "The Eagles of Death Metal" },
                new Artist { Name = "The Go! Team" },
                new Artist { Name = "The Head and the Heart" },
                new Artist { Name = "The Jezabels" },
                new Artist { Name = "The King's Singers" },
                new Artist { Name = "The Lumineers" },
                new Artist { Name = "The Offspring" },
                new Artist { Name = "The Police" },
                new Artist { Name = "The Posies" },
                new Artist { Name = "The Prodigy" },
                new Artist { Name = "The Rolling Stones" },
                new Artist { Name = "The Rubberbandits" },
                new Artist { Name = "The Smashing Pumpkins" },
                new Artist { Name = "The Stone Roses" },
                new Artist { Name = "The Who" },
                new Artist { Name = "Them Crooked Vultures" },
                new Artist { Name = "TheStart" },
                new Artist { Name = "Thievery Corporation" },
                new Artist { Name = "Tiësto" },
                new Artist { Name = "Tim Maia" },
                new Artist { Name = "Ton Koopman" },
                new Artist { Name = "Tool" },
                new Artist { Name = "Tori Amos" },
                new Artist { Name = "Trampled By Turtles" },
                new Artist { Name = "Trans-Siberian Orchestra" },
                new Artist { Name = "Tygers of Pan Tang" },
                new Artist { Name = "U2" },
                new Artist { Name = "UB40" },
                new Artist { Name = "Uh Huh Her " },
                new Artist { Name = "Van Halen" },
                new Artist { Name = "Various Artists" },
                new Artist { Name = "Velvet Revolver" },
                new Artist { Name = "Venus Hum" },
                new Artist { Name = "Vicente Fernandez" },
                new Artist { Name = "Vinícius De Moraes" },
                new Artist { Name = "Weezer" },
                new Artist { Name = "Weird Al" },
                new Artist { Name = "Wendy Carlos" },
                new Artist { Name = "Wilhelm Kempff" },
                new Artist { Name = "Yano" },
                new Artist { Name = "Yehudi Menuhin" },
                new Artist { Name = "Yes" },
                new Artist { Name = "Yo-Yo Ma" },
                new Artist { Name = "Zeca Pagodinho" },
                new Artist { Name = "אריק אינשטיין"}
            };
            artists.ForEach(a => a.Rank = Random.Next(1, 100));
            artists.ForEach(s => context.Artists.Add(s));
            context.SaveChanges();
            return artists;
        }

        private static List<Genre> AddGenres(DashboardEntities context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "Pop" },
                new Genre { Name = "Rock" },
                new Genre { Name = "Jazz" },
                new Genre { Name = "Metal" },
                new Genre { Name = "Electronic" },
                new Genre { Name = "Blues" },
                new Genre { Name = "Latin" },
                new Genre { Name = "Rap" },
                new Genre { Name = "Classical" },
                new Genre { Name = "Alternative" },
                new Genre { Name = "Country" },
                new Genre { Name = "R&B" },
                new Genre { Name = "Indie" },
                new Genre { Name = "Punk" },
                new Genre { Name = "World" }
            };

            genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();
            return genres;
        }

        private static void AddTracks(DashboardEntities context)
        {
            var albums = context.Albums;

            context.Tracks.Add(new Track
                                   {
                                       Name = "Blackened",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 400,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "...And Justice for All",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 585,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eye of the Beholder",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 385,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 443,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Shortest Straw",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 394,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Harvester of Sorrow",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 344,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Frayed Ends of Sanity",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 461,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "To Live Is to Die",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 588,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dyers Eve",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 313,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One (Live Version)",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 479,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "...And Justice For All (Live)",
                                       Album = albums.Single(a => a.Title == "...And Justice For All"),
                                       Duration = 605,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vicarious",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 426,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jambi",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 448,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wings for Marie (Part 1)",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 371,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "10,000 Days (Wings Part 2)",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 673,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Pot",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 382,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lipan Conjuring",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 71,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lost Keys (Blame Hofmann)",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 226,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rosetta Stoned",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 671,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Intension",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 441,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Right in Two",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 535,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Viginti Tres",
                                       Album = albums.Single(a => a.Title == "10,000 Days"),
                                       Duration = 302,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Light",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 287,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "This World",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 205,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mirror",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 310,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Swallow",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 287,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Good",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 243,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pieces",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 246,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Angelhead feat. Lili Hayden",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 288,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ride",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 306,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oneness",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 181,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everywhere",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 305,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lay Me Down",
                                       Album = albums.Single(a => a.Title == "11i"),
                                       Duration = 496,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "4x4=12 (Continuous Mix)",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 4191,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Some Chords",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 442,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sofi Needs A Ladder",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 261,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "A City in Florida",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 339,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bad Selection",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 331,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Animal Rights",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 372,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Said (Michael Woods Remix)",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 424,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cthulhu Sleeps",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 632,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Right This Second",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 468,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Raise Your Weapon (Original Mix)",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 504,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Trick Pony",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 238,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everything Before",
                                       Album = albums.Single(a => a.Title == "4x4=12 "),
                                       Duration = 395,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Faster Kill Pussycat (Feat Brittany Murphy)",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 193,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Compromise (Featuring Spitfire)",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 223,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sex And Money (Featuring Pharrell Williams)",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 357,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Switch On (Featuring Ryan Tedder)",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 245,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Amsterdam",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 339,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Set It Off (Featuring Grandmaster Flash)",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 255,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Way I Feel (Featuring Ryan Tedder)",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 324,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Praise The Lord",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 252,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Save The Last Trance For Me",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 470,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Not Over (Featuring Ryan Tedder)",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 528,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vulnerable (Featuring Bad Apples)",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 354,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Feed Your Mind (Featuring Spitfire)",
                                       Album = albums.Single(a => a.Title == "A Lively Mind"),
                                       Duration = 175,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Politik",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 317,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In My Place",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 227,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "God Put a Smile Upon Your Face",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 297,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Scientist",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 306,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Clocks",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 251,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Daylight",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 326,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Green Eyes",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 222,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Warning Sign",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 329,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "A Whisper",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 237,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "A Rush of Blood to the Head",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 350,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Amsterdam",
                                       Album = albums.Single(a => a.Title == "A Rush of Blood to the Head"),
                                       Duration = 318,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Arrival",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 194,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Colder Than Winter",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 241,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ave Maria",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 248,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Silent Night",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 187,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In The Bleak Midwinter",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 222,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I've Been This Way Before",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 230,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jesu, Joy Of Man's Desiring",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 236,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Child In A Manger",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 186,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Wish It Could Be Christmas Every Day",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 279,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Amazing Grace",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 184,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ave Maria",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 180,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Believe In Father Christmas",
                                       Album = albums.Single(a => a.Title == "A Winter Symphony"),
                                       Duration = 225,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Come Together",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 258,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Something / Jam",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 327,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Maxwell's Silver Hammer",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 205,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oh! Darling",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 205,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Octopus's Garden",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 198,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Want You",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 348,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Come and Set It",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 149,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oh, I Want You",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 100,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Because",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 163,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Never Give Me Your Money",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 242,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sun King",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 146,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mean Mr. Mustard",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 66,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Her Majesty",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 23,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Polythene Pam",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 72,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "She Came in Through the Bathroom Window",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 215,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Golden Slumbers",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 91,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Carry That Weight",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 97,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The End",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 124,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ain't She Sweet (Rock'n'Roll Jam)",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 126,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Something (Harrison Solo)",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 201,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Maxwell's Silver Hammer (take 5)",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 229,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Octopus's Garden (take 2)",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 168,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Never Give Me Your Money (take 30)",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 350,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Golden Slumbers / Carry That Weight (take 13)",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 186,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The End (remix)",
                                       Album = albums.Single(a => a.Title == "Abbey Road"),
                                       Duration = 128,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Zoo Station",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 276,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Even Better Than the Real Thing",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 221,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 276,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Until the End of the World",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 279,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Who's Gonna Ride Your Wild Horses",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 237,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Cruel",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 350,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Fly",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 269,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mysterious Ways",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 244,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tryin' to Throw Your Arms Around the World",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 233,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ultra Violet (Light My Way)",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 331,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Acrobat",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 270,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Is Blindness",
                                       Album = albums.Single(a => a.Title == "Achtung Baby"),
                                       Duration = 263,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bored (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 245,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Minus Blindfold (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 243,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Weak (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 267,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nosebleed (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 265,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lifter (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 282,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Root (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 220,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "7 Words (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 223,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Birthmark (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 257,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Engine No.9 (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 204,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fireal (LP Version)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 393,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "First (Hidden Track)",
                                       Album = albums.Single(a => a.Title == "Adrenaline"),
                                       Duration = 214,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stinkfist",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 311,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eulogy",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 509,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "H.",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 367,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Useful Idiot",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 38,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Forty Six & 2",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 364,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Message to Harry Manback",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 74,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hooker With a Penis",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 273,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Intermission",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 56,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jimmy",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 324,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Die Eier von Satan",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 137,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pushit",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 595,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cesaro Summability",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 86,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ænema",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 399,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "(-) Ions",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 240,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Third Eye",
                                       Album = albums.Single(a => a.Title == "Ænima"),
                                       Duration = 827,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tell Me Why",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 178,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "After The Gold Rush",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 348,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Only Love Can Break Your Heart",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 229,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Southern Man",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 238,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Till The Morning Comes",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 80,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oh, Lonesome Me",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 229,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Let It Bring You Down",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 177,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Birds",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 153,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "When You Dance You Can Really Love",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 245,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Believe In You",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 301,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cripple Creek Ferry",
                                       Album = albums.Single(a => a.Title == "After the Goldrush"),
                                       Duration = 93,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Robot Rock / Oh Yeah",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 386,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Touch It / Technologic",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 328,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Television Rules the Nation / Crescendolls",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 289,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Too Long / Steam Machine",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 419,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Around the World / Harder Better Faster Stronger",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 341,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Burnin' / Too Long",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 429,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Face to Face / Short Circuit",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 294,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One More Time / Aerodynamic",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 369,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Aerodynamic Beats / Gabrielle , Forget About The World",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 210,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Prime Time Of Your Life / Brainwasher /Rollin 'and Scratchin' / Alive",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 620,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Da Funk / Dadftendirekt",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 395,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Superheroes / Human After All / Rock'n Roll",
                                       Album = albums.Single(a => a.Title == "Alive 2007"),
                                       Duration = 339,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fear",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 215,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Whatever Gets You True",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 178,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Can't Take That Away",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 146,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ancient Sorrow",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 263,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everybody Wants",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 236,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sweet Suburban Sky",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 237,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Downtown",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 251,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Would U B",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 202,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Winter's Fire",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 292,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rainwater",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 339,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It's Over Now",
                                       Album = albums.Single(a => a.Title == "Amen (So Be It)"),
                                       Duration = 202,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Glorious Epic of Three Men who are Awesome",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 259,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "How to Write a Love Song",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 245,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Can You Hear the Fucking Music Coming out of My Car?",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 139,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Birdplane",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 173,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "When Life is Good",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 85,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Songs to Sing Along To",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 151,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Language of Love",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 202,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Skeleton Man",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 152,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Serious",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 105,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Harry Potter and the Drunk Teenage Animals Escaping From Zoos",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 216,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Inspiration",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 60,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "WWJD?",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 214,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sexual Harassment",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 133,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Song for the Elderly",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 192,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ode to Kfc",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 114,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "4 Chords",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 348,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "El Pajaro Avion",
                                       Album = albums.Single(a => a.Title == "Animal Vehicle"),
                                       Duration = 90,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Apocalyptic Love",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 209,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Last Thrill",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 190,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Standing in the Sun",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 244,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You're a Lie",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 231,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No More Heroes",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 264,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Halo",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 203,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "We Will Roam",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 290,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anastasia",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 368,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Not for Me",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 322,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bad Rain",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 227,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hard & Fast",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 182,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Far and Away",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 315,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shots Fired",
                                       Album = albums.Single(a => a.Title == "Apocalyptic Love"),
                                       Duration = 229,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Drive",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 265,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Try Not to Breathe",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 229,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Sidewinder Sleeps Tonite (Album Version )",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 249,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everybody Hurts",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 363,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "New Orleans Instrumental No.1 ( LP Version )",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 135,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sweetness Follows ( LP Version )",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 260,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Monty Got A Raw Deal (LP Version)",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 196,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ignoreland ( LP Version )",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 266,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Star Me Kitten ( LP Version )",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 195,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Man on the Moon",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 314,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nightswimming",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 255,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Find The River ( LP Version )",
                                       Album = albums.Single(a => a.Title == "Automatic for the People"),
                                       Duration = 228,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Banadeek Ta'ala",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 199,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Halla Halla",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 209,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ma'drrsh Ana",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 236,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Alumak Leh",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 205,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ma'ak Bartah",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 237,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ya Reet Sennk",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 213,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mally Enaya",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 205,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Heya Hayati",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 316,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Youm Mat'belna",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 209,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Aghla Min Omry",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 290,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Aref Habiby",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 223,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tagroba Wa Adet",
                                       Album = albums.Single(a => a.Title == "Banadeek Ta'ala"),
                                       Duration = 304,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Barbie Girl (Radio Edit)",
                                       Album = albums.Single(a => a.Title == "Barbie Girl"),
                                       Duration = 197,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Barbie Girl (Spike's Plastic mix)",
                                       Album = albums.Single(a => a.Title == "Barbie Girl"),
                                       Duration = 527,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Barbie Girl (Spike's Anatomically Correct dub)",
                                       Album = albums.Single(a => a.Title == "Barbie Girl"),
                                       Duration = 479,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Barbie Girl (Extended Version)",
                                       Album = albums.Single(a => a.Title == "Barbie Girl"),
                                       Duration = 315,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "D'You Know What I Mean?",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 462,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Big Mouth",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 302,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Magic Pie",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 439,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stand By Me",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 356,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Hope, I Think, I Know",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 262,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Girl in the Dirty Shirt",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 349,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fade In-Out",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 412,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Go Away",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 288,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Be Here Now",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 313,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All Around the World",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 560,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It's Gettin' Better (Man!!)",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 420,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All Around the World (reprise)",
                                       Album = albums.Single(a => a.Title == "Be Here Now"),
                                       Duration = 128,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Enter Sandman (Explicit Version)",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 459,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sad But True (Explicit Version)",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 346,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Holier Than Thou",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 227,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Unforgiven",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 386,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wherever I May Roam (Explicit Version)",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 421,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Tread on Me",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 240,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Through the Never",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 242,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nothing Else Matters (Explicit Version)",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 409,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Of Wolf And Man (Explicit Version)",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 258,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The God That Failed",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 308,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Friend of Misery",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 407,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Struggle Within",
                                       Album = albums.Single(a => a.Title == "Black"),
                                       Duration = 233,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Leper Affinity",
                                       Album = albums.Single(a => a.Title == "Blackwater Park"),
                                       Duration = 621,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bleak",
                                       Album = albums.Single(a => a.Title == "Blackwater Park"),
                                       Duration = 555,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Harvest",
                                       Album = albums.Single(a => a.Title == "Blackwater Park"),
                                       Duration = 378,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Drapery Falls",
                                       Album = albums.Single(a => a.Title == "Blackwater Park"),
                                       Duration = 649,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dirge for November",
                                       Album = albums.Single(a => a.Title == "Blackwater Park"),
                                       Duration = 473,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Funeral Portrait",
                                       Album = albums.Single(a => a.Title == "Blackwater Park"),
                                       Duration = 524,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Patterns in the Ivy",
                                       Album = albums.Single(a => a.Title == "Blackwater Park"),
                                       Duration = 112,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blackwater Park",
                                       Album = albums.Single(a => a.Title == "Blackwater Park"),
                                       Duration = 725,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rise With Me",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 127,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blood",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 207,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Adrenalize",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 255,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Whore",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 245,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You're Gonna Listen",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 223,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It Is Written",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 30,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Burn",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 284,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Scarlet",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 230,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Aries",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 41,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "From the Ashes",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 266,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Beast Within",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 229,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Comanche",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 197,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Blood Legion (Legion)",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 269,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "11:11",
                                       Album = albums.Single(a => a.Title == "Blood"),
                                       Duration = 291,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ready Steady Go (feat. Asher D)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 253,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Southern Sun (feat. Carla Werner)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 417,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Time of Your Life (feat. Perry Farrell)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 257,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hypnotised (feat. Tiff Lacey)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 394,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Zoo York",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 325,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nixon's Spirit (feat. Hunter S. Thompson)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 168,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hold Your Hand (feat. Emiliana Torrini)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 219,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Starry Eyed Surprise (feat. Shifty Shellshock of Crazy Town)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 228,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Get Em Up (feat. Ice Cube)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 230,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Motion (feat. Grant Lee Philips)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 384,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Harder They Come (feat. Nelly Furtado & Tricky)",
                                       Album = albums.Single(a => a.Title == "Bunkka"),
                                       Duration = 227,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Intro",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 37,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hot Dog",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 230,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Generation",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 221,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Full Nelson",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 247,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Way (Album Version (Explicit))",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 274,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rollin' (Air Raid Vehicle)",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 214,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Livin' It Up",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 265,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The One",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 343,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Getcha Groove On (Album Version (Explicit))",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 269,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Take a Look Around",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 295,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It'll Be OK",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 306,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Boiler",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 344,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hold On",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 346,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name =
                                           "Rollin' (Urban Assault Vehicle) (Featuring DMX, Method Man And Redman)",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 382,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Outro",
                                       Album =
                                           albums.Single(
                                               a => a.Title == "Chocolate Starfish And The Hot Dog Flavored Water"),
                                       Duration = 115,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wartime (It's Time 2 Go Now)",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 266,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Runaway",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 232,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Just A Fantasy",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 222,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blood On My Hands",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 178,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Millionaire",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 201,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dance Revolution",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 225,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Master Plan",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 256,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fix",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 241,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Surrender",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 207,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ciao, Baby",
                                       Album = albums.Single(a => a.Title == "Ciao, Baby"),
                                       Duration = 260,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "La Wally",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 242,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anytime, Anywhere",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 199,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ave Maria",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 180,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lascia Ch'io Pianga",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 207,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hijo De La Luna",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 266,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What You Never Know",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 204,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "En Aranjuez Con Tu Amor",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 230,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "La Luna",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 298,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It's A Beautiful Day",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 236,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nella Fantasia",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 218,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Music of the Night",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 324,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "O Mio Babbino Caro",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 160,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pie Jesu",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 224,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Winterlight",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 196,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nessun Dorma",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 231,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Time to Say Goodbye",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 243,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "A Question of Honor, Part II",
                                       Album = albums.Single(a => a.Title == "Classics: The Best of Sarah Brightman"),
                                       Duration = 318,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Know Why",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 188,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Seven Years",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 144,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cold Cold Heart",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 217,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Feelin' the Same Way",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 176,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Come Away With Me",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 198,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shoot the Moon",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 235,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Turn Me On",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 154,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lonestar",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 185,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I've Got to See You Again",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 213,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Painter Song",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 161,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Flight Down",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 185,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nightingale",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 251,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Long Day Is Over",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 164,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Nearness of You",
                                       Album = albums.Single(a => a.Title == "Come Away With Me"),
                                       Duration = 187,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Opera Singer",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 246,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Meanwhile, Rick James",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 237,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Meanwhile, Rick James...",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 237,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shadow Stabbing",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 187,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Short Skirt/Long Jacket",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 204,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Commissioning A Symphony In C",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 179,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Commisioning a Symphony in C",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 179,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Arco Arena (Instrumental)",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 91,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Comfort Eagle",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 220,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Long Line Of Cars",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 203,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love You Madly",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 237,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pretty Pink Ribbon",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 188,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "World Of Two",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 220,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Never Gonna Give You Up",
                                       Album = albums.Single(a => a.Title == "Comfort Eagle"),
                                       Duration = 242,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Not A Love Song",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 213,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Explode",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 170,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wait Another Day",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 240,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Common Reaction",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 240,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Say So",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 209,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Covered",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 233,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everyone",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 216,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Away From Here",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 202,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Long",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 161,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dance With Me",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 181,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dreamer",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 232,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Not A Love Song (Morgan Page Remix) (Bonus Track)",
                                       Album = albums.Single(a => a.Title == "Common Reaction"),
                                       Duration = 431,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dead & Bloated",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 327,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sex Type Thing",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 219,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wicked Garden",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 245,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Memory",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 80,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sin",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 365,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Naked Sunday",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 229,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Creep",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 333,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Piece of Pie",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 324,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Plush",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 310,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wet My Bed",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 96,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crackerman",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 194,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Where the River Goes",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 506,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Plush (Acoustic Version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 230,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wicked Garden (LP version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 244,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Memory (LP Version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 80,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sin (LP Version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 365,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Naked Sunday (LP Version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 229,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Piece of Pie (LP Version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 324,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wet My Bed (LP Version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 97,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crackerman (LP Version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 194,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Where The River Goes (LP Version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 506,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Creep (LP version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 332,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Plush (LP version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 312,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dead & Bloated (LP Version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 310,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sex Type Thing (LP version)",
                                       Album = albums.Single(a => a.Title == "Core"),
                                       Duration = 217,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lights",
                                       Album = albums.Single(a => a.Title == "Cornerstone"),
                                       Duration = 278,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Why Me",
                                       Album = albums.Single(a => a.Title == "Cornerstone"),
                                       Duration = 237,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Babe",
                                       Album = albums.Single(a => a.Title == "Cornerstone"),
                                       Duration = 264,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Never Say Never",
                                       Album = albums.Single(a => a.Title == "Cornerstone"),
                                       Duration = 191,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Boat On A River",
                                       Album = albums.Single(a => a.Title == "Cornerstone"),
                                       Duration = 193,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Borrowed Time",
                                       Album = albums.Single(a => a.Title == "Cornerstone"),
                                       Duration = 299,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "First Time",
                                       Album = albums.Single(a => a.Title == "Cornerstone"),
                                       Duration = 265,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eddie",
                                       Album = albums.Single(a => a.Title == "Cornerstone"),
                                       Duration = 257,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love In The Midnight",
                                       Album = albums.Single(a => a.Title == "Cornerstone"),
                                       Duration = 323,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Issue No 5",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 61,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Don't Cry",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 140,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Luvotomy",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 313,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "STUCK IN YOUR LOVE",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 182,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Current Affairs",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 50,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Summer Time Love",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 307,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Simple & Lovely",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 229,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Picture Perfect Love",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 296,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Music Monopoly",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 86,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "she loves the CREAM",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 405,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Me After 12AM",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 256,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Song",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 346,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Long and Prosper",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 332,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "LOVE ME, HATE THE GAME",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 116,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lotta Love",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 407,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "People of Cosmicolor",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 81,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love to Live By",
                                       Album = albums.Single(a => a.Title == "Cosmicolor"),
                                       Duration = 340,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Genesis",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 234,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Let There Be Light",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 299,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "D.A.N.C.E.",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 207,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Newjack",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 216,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Phantom",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 263,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Phantom pt. II",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 200,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Valentine",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 176,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "TTHHEE PPAARRTTYY",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 243,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "DVNO",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 236,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stress",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 298,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Justice / Waters Of Nazareth",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 265,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Minute To Midnight",
                                       Album = albums.Single(a => a.Title == "Cross"),
                                       Duration = 220,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Web of Deception",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 273,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Culture of Fear",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 193,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Take My Soul",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 232,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Light Flares",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 181,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stargazer",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 225,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Where It All Starts",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 201,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tower Seven",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 469,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Is It Over?",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 203,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "False Flag Dub",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 185,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Safar (The Journey)",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 103,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fragments",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 251,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Overstand",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 220,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Free",
                                       Album = albums.Single(a => a.Title == "Culture of Fear"),
                                       Duration = 243,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Om Hraum Mitraya",
                                       Album = albums.Single(a => a.Title == "Dakshina"),
                                       Duration = 257,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Om Namah Shivaya",
                                       Album = albums.Single(a => a.Title == "Dakshina"),
                                       Duration = 390,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Guru Rinpoche Mantra",
                                       Album = albums.Single(a => a.Title == "Dakshina"),
                                       Duration = 537,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Aad Guray",
                                       Album = albums.Single(a => a.Title == "Dakshina"),
                                       Duration = 365,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Homage to Krishna",
                                       Album = albums.Single(a => a.Title == "Dakshina"),
                                       Duration = 531,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Om Purnam I",
                                       Album = albums.Single(a => a.Title == "Dakshina"),
                                       Duration = 237,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Om Purnam II",
                                       Album = albums.Single(a => a.Title == "Dakshina"),
                                       Duration = 318,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brahma Nandam",
                                       Album = albums.Single(a => a.Title == "Dakshina"),
                                       Duration = 588,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Speak To Me (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 68,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Breathe (Breathe In The Air) (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 168,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "On The Run (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 230,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Time (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 409,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Great Gig In The Sky (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 284,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Money (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 382,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Us And Them (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 469,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Any Colour You Like (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 206,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brain Damage (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 227,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eclipse (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Dark Side of the Moon"),
                                       Duration = 131,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "That Was Just Your Life",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 428,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The End of the Line",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 472,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Broken, Beat & Scarred",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 384,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Day That Never Comes",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 476,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All Nightmare Long",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 477,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cyanide",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 399,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Unforgiven III",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 466,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Judas Kiss",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 480,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Suicide & Redemption",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 597,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Apocalypse",
                                       Album = albums.Single(a => a.Title == "Death Magnetic"),
                                       Duration = 301,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Disillusion",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 200,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Autumn",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 198,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blood On The Walls",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 164,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nothing Short Of Giving In",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 216,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The City",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 198,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Press On",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 194,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Low",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 196,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Goodbye Blue",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 204,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Where It Stands Now",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 196,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "On The Boulevard",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 355,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Epitaph",
                                       Album = albums.Single(a => a.Title == "Deep End of Down"),
                                       Duration = 227,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tabanka Assigo",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 265,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Na ri na",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 219,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vazulina",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 291,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mundo é Nôs",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 239,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Es Bida",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 231,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tó Martins",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 274,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Batuku",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 276,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Padoce De Céu Azul",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 348,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oh Náia",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 231,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Um Cartinha",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 256,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Raboita Di Rubon Manel",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 290,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tem Um Hora Pa Tude",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 257,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ma'm Ba Dês Bês Kumida Dâ",
                                       Album = albums.Single(a => a.Title == "Di Korpu Ku Alma"),
                                       Duration = 228,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Over The Mountain (Remastered Original Recording)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 271,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Over the Mountain",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 271,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flying High Again",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 289,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flying High Again (Remastered Original Recording)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 284,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Can't Kill Rock And Roll",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 417,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Can't Kill Rock And Roll (Remastered Original Recording)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 419,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Believer",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 316,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Believer (Remastered Original Recording)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 316,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Little Dolls",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 337,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Little Dolls (Remastered Original Recording)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 339,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tonight (Remastered Original Recording)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 350,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tonight",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 348,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "S.A.T.O.",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 246,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "S.A.T.O. (Remastered Original Recording)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 247,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Diary Of A Madman",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 373,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Diary Of A Madman (Remastered Original Recording)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 374,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Don't Know (live)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 301,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Don't Know (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 290,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crazy Train (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 326,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Believer (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 337,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mr. Crowley (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 392,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flying High Again (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 257,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Revelation (Mother Earth) (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 358,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Steal Away (The Night) (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 480,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Suicide Solution (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 450,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Iron Man (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 249,
                                       Rank = 26
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Children Of The Grave (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 342,
                                       Rank = 27
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Paranoid (Live from Blizzard Of Ozz tour)",
                                       Album = albums.Single(a => a.Title == "Diary of a Madman"),
                                       Duration = 203,
                                       Rank = 28
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Them Bones",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 149,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dam That River",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 189,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rain When I Die",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 362,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sickman",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 329,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rooster",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 374,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Junkhead",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 309,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dirt",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 316,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "God Smack",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 230,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Iron Man",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 43,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hate to Feel",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 316,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Angry Chair",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 288,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Down in a Hole",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 336,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Would?",
                                       Album = albums.Single(a => a.Title == "Dirt"),
                                       Duration = 206,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "November",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 220,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "White Noise",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 128,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Darkness and the Light",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 204,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Truck",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 171,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Empire",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 203,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Methodism in Middle America",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 387,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nobody Else",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 147,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pipe Knot",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 181,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Think It Over",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 193,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Duluth",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 183,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shenandoah",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 259,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hammock Swinging",
                                       Album = albums.Single(a => a.Title == "Duluth"),
                                       Duration = 165,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mysterons",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 306,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sour Times",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 254,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Strangers",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 238,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It Could Be Sweet",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 259,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wandering Star",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 293,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It's a Fire",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 229,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Numb",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 238,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Roads",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 305,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pedestal",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 221,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Biscuit",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 304,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Glory Box",
                                       Album = albums.Single(a => a.Title == "Dummy"),
                                       Duration = 305,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Country Comfort",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 292,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Borrowed Love",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 218,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ring Of Fire",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 131,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "True Love Never Dies",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 227,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Angels",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 294,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fill Her Up",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 344,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Foggy Mountain Breakdown (2001 Earl Scruggs & Friends Version)",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 289,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Somethin' Just Ain't Right",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 234,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Found Love",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 190,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blue Ridge Mountain Blues",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 201,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Passin' Thru",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 337,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Foggy Mountain Rock/Foggy Mountain Special (Medley)",
                                       Album = albums.Single(a => a.Title == "Earl Scruggs and Friends"),
                                       Duration = 146,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In Paradisum",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 191,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eden",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 239,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Many Things",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 177,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anytime, Anywhere",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 199,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bailero",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 193,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dust In The Wind",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 221,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Il Mio Cuore Va",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 267,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deliver Me",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 240,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Un Jour Il Viendra",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 219,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nella Fantasia",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 218,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tu",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 249,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lascia Ch'io Pianga",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 207,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Only An Ocean Away",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 294,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Scene d'Amour",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 199,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nessun Dorma (Warner Version)",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 186,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Last Words You Said",
                                       Album = albums.Single(a => a.Title == "Eden"),
                                       Duration = 253,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lonely Boy",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 193,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dead and Gone",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 221,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gold on the Ceiling",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 224,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Little Black Submarines",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 250,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Money Maker",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 176,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Run Right Back",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 197,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hell of a Season",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 224,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stop Stop",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 208,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nova Baby",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 206,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mind Eraser",
                                       Album = albums.Single(a => a.Title == "El Camino"),
                                       Duration = 192,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flight Over Rio",
                                       Album = albums.Single(a => a.Title == "Elegant Gypsy"),
                                       Duration = 434,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Midnight Tango",
                                       Album = albums.Single(a => a.Title == "Elegant Gypsy"),
                                       Duration = 446,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mediterranean Sundance",
                                       Album = albums.Single(a => a.Title == "Elegant Gypsy"),
                                       Duration = 310,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Race With Devil On Spanish Highway",
                                       Album = albums.Single(a => a.Title == "Elegant Gypsy"),
                                       Duration = 374,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lady Of Rome, Sister Of Brazil",
                                       Album = albums.Single(a => a.Title == "Elegant Gypsy"),
                                       Duration = 105,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lady Of Rome Sister Of Brazil",
                                       Album = albums.Single(a => a.Title == "Elegant Gypsy"),
                                       Duration = 106,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Elegant Gypsy Suite",
                                       Album = albums.Single(a => a.Title == "Elegant Gypsy"),
                                       Duration = 554,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ten Seconds Before Sunrise",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 451,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everything",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 421,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Do You Feel Me",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 363,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Carpe Noctum",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 423,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Driving To Heaven",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 282,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sweet Things",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 342,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bright Morningstar",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 499,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Break My Fall",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 434,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In The Dark",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 276,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dance4Life",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 321,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Elements Of Life",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 505,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everything (Acoustic)",
                                       Album = albums.Single(a => a.Title == "Elements Of Life"),
                                       Duration = 212,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Yolele",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 203,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mandola",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 229,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Show Me The Way",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 241,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fa Fa Fa Fa Fa (Sad Song)",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 193,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rail On",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 146,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shofele",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 189,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Image",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 346,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sala Keba (Be Careful)",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 220,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Awa Y'okeyi",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 114,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Epelo",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 248,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ah Ouais (Oh Yes)",
                                       Album = albums.Single(a => a.Title == "Emotion"),
                                       Duration = 260,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "We Die Young",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 152,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Man in the Box",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 287,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sea of Sorrow",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 349,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bleed the Freak",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 241,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Can't Remember",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 223,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love, Hate, Love",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 386,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It Ain't Like That",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 278,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sunshine",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 284,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Put You Down",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 195,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Confusion",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 345,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Know Somethin (Bout You)",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 261,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Real Thing",
                                       Album = albums.Single(a => a.Title == "Facelift"),
                                       Duration = 243,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mean Street",
                                       Album = albums.Single(a => a.Title == "Fair Warning"),
                                       Duration = 299,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "\"Dirty Movies\"",
                                       Album = albums.Single(a => a.Title == "Fair Warning"),
                                       Duration = 247,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sinner's Swing!",
                                       Album = albums.Single(a => a.Title == "Fair Warning"),
                                       Duration = 189,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hear About It Later",
                                       Album = albums.Single(a => a.Title == "Fair Warning"),
                                       Duration = 273,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Unchained",
                                       Album = albums.Single(a => a.Title == "Fair Warning"),
                                       Duration = 207,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Push Comes To Shove",
                                       Album = albums.Single(a => a.Title == "Fair Warning"),
                                       Duration = 228,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So This Is Love?",
                                       Album = albums.Single(a => a.Title == "Fair Warning"),
                                       Duration = 185,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sunday Afternoon In The Park",
                                       Album = albums.Single(a => a.Title == "Fair Warning"),
                                       Duration = 118,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Foot Out The Door",
                                       Album = albums.Single(a => a.Title == "Fair Warning"),
                                       Duration = 117,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Contract on the World Love Jam (instrumental)",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 104,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brothers Gonna Work It Out",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 308,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "911 Is a Joke",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 197,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Incident at 66.6 FM (instrumental)",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 98,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Welcome to the Terrordome",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 328,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Meet the G That Killed Me",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 44,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pollywanacraka",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 232,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anti-Nigger Machine",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 197,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Burn Hollywood Burn",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 167,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Power to the People",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 230,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Who Stole the Soul?",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 230,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fear of a Black Planet",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 225,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Revolutionary Generation",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 343,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Can't Do Nuttin' for Ya, Man!",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 167,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Reggie Jax",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 96,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Leave This Off Your Fu*kin Charts (instrumental)",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 151,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "B Side Wins Again",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 226,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "War at 33 1/3",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 128,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Final Count of the Collision Between Us and the Damned (instrumental)",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 48,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fight the Power",
                                       Album = albums.Single(a => a.Title == "Fear of a Black Planet"),
                                       Duration = 277,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sunrise",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 200,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What Am I to You?",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 208,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Those Sweet Words",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 201,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Carnival Town",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 191,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In The Morning",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 246,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Be Here to Love Me",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 208,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Creepin' In (feat. Dolly Parton)",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 183,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Toes",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 225,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Humble Me",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 275,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Above Ground",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 223,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Long Way Home",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 192,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Prettiest Thing",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 230,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Miss You at All",
                                       Album = albums.Single(a => a.Title == "Feels Like Home"),
                                       Duration = 186,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Fly",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 176,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Why",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 309,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Murder in Mairyland Park",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 218,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "How Can Heaven Love Me",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 224,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ghost In the Machinery",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 262,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Take My Breath Away",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 409,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Something In the Air",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 262,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Heaven Is Here",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 242,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Loved You",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 249,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fly",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 170,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Do You Wanna Be Loved",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 260,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "How Can Heaven Love Me (Video Version)",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 227,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "A Question Of Honour",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 337,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "On The Nile",
                                       Album = albums.Single(a => a.Title == "Fly"),
                                       Duration = 70,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Run-Around",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 280,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stand",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 319,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Look Around",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 341,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fallible",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 286,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Mountains Win Again",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 309,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Freedom",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 241,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crash Burn",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 218,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Price To Pay",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 316,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hook",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 253,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Good, The Bad And The Ugly",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 115,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Just Wait",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 334,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brother John",
                                       Album = albums.Single(a => a.Title == "Four"),
                                       Duration = 501,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Piggy (Nothing Can Stop Me Now)",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 243,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Art of Self Destruction, Part One",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 342,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Self Destruction (Part Three)",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 208,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Heresy",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 234,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Downward Spiral (The Bottom)",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 358,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hurt (Quiet)",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 309,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "At the Heart of It All",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 371,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ruiner",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 297,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eraser (Denial: Realization)",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 394,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Self Destruction, Final",
                                       Album = albums.Single(a => a.Title == "Further Down the Spiral"),
                                       Duration = 342,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Supervixen",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 235,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Queer",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 277,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Only Happy When It Rains",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 227,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "As Heaven Is Wide",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 282,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Not My Idea",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 228,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "A Stroke of Luck",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 284,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vow",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 272,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stupid Girl",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 258,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dog New Tricks",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 235,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Lover's Box",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 234,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fix Me Now",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 282,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Milk",
                                       Album = albums.Single(a => a.Title == "Garbage"),
                                       Duration = 230,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Horn Intro",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 9,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The World at Large",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 272,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Float On",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 208,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ocean Breathes Salty",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 224,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dig Your Grave",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 12,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bury Me With It",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 229,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dance Hall",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 177,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bukowski",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 254,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "This Devil's Workday",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 139,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The View",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 250,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Satin in a Coffin",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 155,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Interlude (Milo)",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 58,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blame It On The Tetons",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 325,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Black Cadillacs",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 163,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Chance",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 181,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Good Times Are Killing Me",
                                       Album =
                                           albums.Single(a => a.Title == "Good News For People Who Love Bad News"),
                                       Duration = 256,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hello City",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 202,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Enid",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 247,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Grade 9",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 185,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brian Wilson",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 286,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Be My Yoko Ono",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 199,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wrap Your Arms Around Me",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 272,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What a Good Boy",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 249,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The King of Bedside Manor",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 143,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Box Set",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 286,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Love You",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 247,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "New Kid (On the Block)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 252,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blame It On Me",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 234,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Flag",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 232,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "If I Had $1,000,000",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 368,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crazy",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 290,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hello City (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 202,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crazy (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 290,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "If I Had $1,000,000 (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 265,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Flag (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 233,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blame It On Me (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 234,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "New Kid (On The Block) (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 253,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Love You (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 249,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Box/Set (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 289,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The King Of Bedside Manor (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 147,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What A Good Boy (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 235,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wrap Your Arms Around Me (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 275,
                                       Rank = 26
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Be My Yoko Ono (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 165,
                                       Rank = 27
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brian Wilson (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 289,
                                       Rank = 28
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Grade 9 (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 175,
                                       Rank = 29
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Enid (Album Version)",
                                       Album = albums.Single(a => a.Title == "Gordon"),
                                       Duration = 247,
                                       Rank = 30
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stand Up and Shout",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 250,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Holy Diver",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 301,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gypsy",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 216,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Caught in the Middle",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 251,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Talk to Strangers",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 364,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Straight Through the Heart",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 349,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Invisible",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 320,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rainbow in the Dark",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 296,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shame on the Night",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 1008,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 1)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 265,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 2)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 134,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 3)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 190,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 4)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 29,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 5)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 45,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 6)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 52,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 7)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 125,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 8)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 159,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 9)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 979,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "An Interview With Dio (Part 10)",
                                       Album = albums.Single(a => a.Title == "Holy Diver"),
                                       Duration = 95,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Daftendirekt",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 163,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wdpk 837 fm",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 28,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Revolution 909",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 234,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Da Funk",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 323,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Phoenix",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 296,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fresh",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 243,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Around the World",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 427,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rollin' & Scratchin'",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 446,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Teachers (extended mix)",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 172,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "High Fidelity",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 361,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rock'n Roll",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 452,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oh Yeah",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 120,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Burnin' (Original Mix)",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 412,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Indo Silver Club",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 273,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Alive",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 315,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Funk Ad",
                                       Album = albums.Single(a => a.Title == "Homework"),
                                       Duration = 51,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Song Remains the Same",
                                       Album = albums.Single(a => a.Title == "Houses Of The Holy"),
                                       Duration = 330,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Rain Song",
                                       Album = albums.Single(a => a.Title == "Houses Of The Holy"),
                                       Duration = 458,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Over the Hills and Far Away",
                                       Album = albums.Single(a => a.Title == "Houses Of The Holy"),
                                       Duration = 289,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Crunge",
                                       Album = albums.Single(a => a.Title == "Houses Of The Holy"),
                                       Duration = 195,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dancing Days",
                                       Album = albums.Single(a => a.Title == "Houses Of The Holy"),
                                       Duration = 221,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "D'yer Mak'er",
                                       Album = albums.Single(a => a.Title == "Houses Of The Holy"),
                                       Duration = 261,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Quarter",
                                       Album = albums.Single(a => a.Title == "Houses Of The Holy"),
                                       Duration = 420,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Ocean",
                                       Album = albums.Single(a => a.Title == "Houses Of The Holy"),
                                       Duration = 271,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Into",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 89,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hello",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 217,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Watch It Burn",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 264,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Low",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 260,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bring You Back",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 238,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "12804",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 243,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Alive",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 230,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Crown",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 270,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stella",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 277,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Closure",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 216,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Breaking Me",
                                       Album = albums.Single(a => a.Title == "Human"),
                                       Duration = 209,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Changes (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 213,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oh! You Pretty Things (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 191,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eight Line Poem (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 172,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Life On Mars? (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 231,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kooks (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 169,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Quicksand (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 302,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fill Your Heart (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 186,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Andy Warhol (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 231,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Song For Bob Dylan (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 251,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Queen Bitch (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 194,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Bewlay Brothers (1999 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Hunky Dory"),
                                       Duration = 320,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Women",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 342,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rocket",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 397,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Animal",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 245,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Bites",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 347,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pour Some Sugar on Me",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 153,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Armageddon It",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 324,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gods of War",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 793,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Shoot Shot Gun",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 267,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Run Riot",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 279,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hysteria",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 354,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Excitable",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 259,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love and Affection",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 277,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tear It Down",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 218,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ride Into The Sun (Re-Recording)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 185,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Wanna Be Your Hero",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 275,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ring of Fire",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 281,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Elected (live)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 271,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love and Affection (live)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 294,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Billy's Got a Gun (live)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 315,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rock Of Ages (Live)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 372,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Women (live)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 389,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Animal (extended version)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 293,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pour Some Sugar on Me (extended version)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 338,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Armageddon It ('88 Extended Mix)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 462,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Excitable (The Orgasmic Mix)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 386,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rocket (The Lunar Mix - Extended Version)",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 523,
                                       Rank = 26
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Release Me",
                                       Album = albums.Single(a => a.Title == "Hysteria"),
                                       Duration = 213,
                                       Rank = 27
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blackest Eyes",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 263,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Trains",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 356,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lips of Ashes",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 279,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Sound of Muzak",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 299,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gravity Eyelids",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 476,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wedding Nails",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 393,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Prodigal",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 332,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = ".3",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 325,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Creator Has a Mastertape",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 321,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Heartattack in a Layby",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 255,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Strip the Soul",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 441,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Collapse the Light Into Earth",
                                       Album = albums.Single(a => a.Title == "In Absentia"),
                                       Duration = 352,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Haunted (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 341,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "White Lies (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 277,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sabotage (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 221,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Complicated (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 480,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Get Back (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 324,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Far Away (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 212,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Another Sunday (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 393,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Talk In Grey (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 202,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In Circles (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 271,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In Between (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 204,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stormy Skies (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 264,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Détournement (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 141,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "New York City (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 325,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Castaway (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 207,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "La Dolce Vita (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 170,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Let Go (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 378,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fall With Me (Album Mix Edit)",
                                       Album = albums.Single(a => a.Title == "In Between"),
                                       Duration = 271,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "15 Step",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 236,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bodysnatchers",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 241,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nude",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 261,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Weird Fishes/Arpeggi",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 316,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All I Need",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 227,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Faust Arp",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 129,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Reckoner",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 287,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "House of Cards",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 327,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jigsaw Falling into Place",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 247,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Videotape",
                                       Album = albums.Single(a => a.Title == "In Rainbows"),
                                       Duration = 278,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "21st Century Schizoid Man",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 640,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Talk to the Wind",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 365,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Epitaph",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 528,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Moonchild",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 734,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Court of the Crimson King",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 566,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Moonchild (full version)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 735,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Talk To The Wind (Duo Version)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 301,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Talk To The Wind (Alternate Mix)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 392,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Epitaph (Backing Track)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 537,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wind session",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 275,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "21st Century Schizoid Man (2009 Stereo Mix)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 442,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Talk To The Wind (2009 Stereo Mix)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 364,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Epitaph (2009 Stereo Mix)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 526,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Moonchild (2009 Stereo Mix)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 732,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Court Of The Crimson King (2009 Stereo Mix)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 567,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "21st Century Schizoid Man (Original Master Edition 2004)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 443,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Talk to the Wind (Original Master Edition 2004)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 364,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Epitaph (Original Master Edition 2004)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 526,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Moonchild (Original Master Edition 2004)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 541,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Court Of The Crimson King (Original Master Edition 2004)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 568,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "21st Century Schizoid Man (instrumental)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 426,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Talk To The Wind (Studio Run Through)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 262,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Epitaph (Alternate Version)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 567,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Moonchild (Take 1)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 143,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Court Of The Crimson King (Take 3)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 433,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "21st Century Schizoid Man (live edit)",
                                       Album = albums.Single(a => a.Title == "In the court of the Crimson King"),
                                       Duration = 105,
                                       Rank = 26
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Indestructible",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 96,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fall Back Down",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 227,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Red Hot Moon",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 211,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "David Courtney",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 163,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Start Now",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 185,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Out of Control",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 101,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Django",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 145,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Arrested in Shanghai",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 251,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Travis Bickle",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 137,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Memphis",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 206,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spirit of '87",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 203,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ghost Band",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 98,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tropical London",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 182,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Roadblock",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 118,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Born Frustrated",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 176,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Back Up Against the Wall",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 201,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ivory Coast",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 139,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stand Your Ground",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 204,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Otherside",
                                       Album = albums.Single(a => a.Title == "Indestructible"),
                                       Duration = 112,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lights",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 190,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Feeling That Way",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 208,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anytime",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 208,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "La Do Da",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 181,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Patiently",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 203,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wheel In The Sky",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 251,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Somethin' To Hide",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 207,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Winds Of March",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 305,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Can Do",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 159,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Opened The Door",
                                       Album = albums.Single(a => a.Title == "Infinity"),
                                       Duration = 277,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Left to my own devices (2001 - Remaster)",
                                       Album = albums.Single(a => a.Title == "Introspective"),
                                       Duration = 284,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Want A Dog (2001 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Introspective"),
                                       Duration = 375,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Domino Dancing (2001 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Introspective"),
                                       Duration = 459,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I'm Not Scared (2001 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Introspective"),
                                       Duration = 443,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Always On My Mind/In My House (2001 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Introspective"),
                                       Duration = 542,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It's Alright (2001 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Introspective"),
                                       Duration = 564,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Journeyman",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 398,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Piece of Paper",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 160,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Goto 10",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 262,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Surge",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 125,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lost & Found",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 293,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wooden Toy",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 145,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mass & Spring",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 256,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Calculate",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 93,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kitty Cat",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 256,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bedtime Stories",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 224,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Night Swim",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 356,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dropped from the Sky",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 430,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Morning Ms Candis",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 214,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Last Look",
                                       Album = albums.Single(a => a.Title == "ISAM"),
                                       Duration = 160,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All I Really Want",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 284,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Oughta Know",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 249,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Perfect",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 187,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hand in My Pocket",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 218,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Right Through You",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 175,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Forgiven",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 300,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Learn",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 238,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Head Over Feet",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 263,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mary Jane",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 280,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ironic",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 227,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Not the Doctor",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 227,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wake Up",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 293,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Oughta Know (Hidden LP Remix + Additional Hidden Track)",
                                       Album = albums.Single(a => a.Title == "Jagged Little Pill"),
                                       Duration = 493,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Guns in the Sky",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 143,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "New Sensation",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 219,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Devil Inside",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 312,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Need You Tonight",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 182,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mediate",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 155,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Loved One",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 194,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wildlife",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 190,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Never Tear Us Apart",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 181,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mystify",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 198,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kick",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 193,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Calling All Nations",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 183,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tiny Daggers",
                                       Album = albums.Single(a => a.Title == "Kick"),
                                       Duration = 210,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hit the Lights",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 257,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Four Horsemen",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 433,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Motorbreath",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 188,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jump in the Fire",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 281,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "(Anaesthesia) Pulling Teath",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 254,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Whiplash",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 249,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Phantom Lord",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 302,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Remorse",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 386,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Seek & Destroy",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 415,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Metal Militia",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 311,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Four Horsemen (Live)",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 331,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Whiplash (Live)",
                                       Album = albums.Single(a => a.Title == "Kill 'Em All"),
                                       Duration = 259,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So What",
                                       Album = albums.Single(a => a.Title == "Kind of Blue"),
                                       Duration = 654,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Freddy Freeloader",
                                       Album = albums.Single(a => a.Title == "Kind of Blue"),
                                       Duration = 589,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blue in Green",
                                       Album = albums.Single(a => a.Title == "Kind of Blue"),
                                       Duration = 337,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All Blues",
                                       Album = albums.Single(a => a.Title == "Kind of Blue"),
                                       Duration = 696,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flamenco Sketches",
                                       Album = albums.Single(a => a.Title == "Kind of Blue"),
                                       Duration = 566,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flamenco Sketches (alternate take)",
                                       Album = albums.Single(a => a.Title == "Kind of Blue"),
                                       Duration = 574,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tiny Little Bows",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 202,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "This Kiss",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 229,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Call Me Maybe",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 195,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Curiosity",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 213,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Good Time",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 205,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "More Than a Memory",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 242,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Turn Me Up",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 224,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hurt So Good",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 189,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Beautiful",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 198,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tonight I’m Getting Over You",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 219,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Guitar String / Wedding Ring",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 207,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Your Heart Is a Muscle",
                                       Album = albums.Single(a => a.Title == "Kiss"),
                                       Duration = 230,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deceptacon",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 184,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hot Topic",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 223,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What's Yr Take On Cassavetes",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 142,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The The Empty",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 123,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Phanta",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 193,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eau D'Bedroom Dancing",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 174,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Let's Run",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 154,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My My Metrocard",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 173,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Friendship Station",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 187,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Slideshow At Free University",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 167,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dude. Yr So Crazy",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 206,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Les and Ray",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 130,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hot Topic (BBC Evening Session)",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 186,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deceptacon (BBC Evening Session)",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 189,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The The Empty (BBC Evening Session)",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 122,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sweetie (BBC Evening Session)",
                                       Album = albums.Single(a => a.Title == "Le Tigre"),
                                       Duration = 162,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Whole Lotta Love",
                                       Album = albums.Single(a => a.Title == "Led Zeppelin II"),
                                       Duration = 333,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What Is and What Should Never Be",
                                       Album = albums.Single(a => a.Title == "Led Zeppelin II"),
                                       Duration = 284,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Lemon Song",
                                       Album = albums.Single(a => a.Title == "Led Zeppelin II"),
                                       Duration = 379,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Thank You",
                                       Album = albums.Single(a => a.Title == "Led Zeppelin II"),
                                       Duration = 289,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Heartbreaker",
                                       Album = albums.Single(a => a.Title == "Led Zeppelin II"),
                                       Duration = 254,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Living Loving Maid [She's Just A Woman]",
                                       Album = albums.Single(a => a.Title == "Led Zeppelin II"),
                                       Duration = 159,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ramble On",
                                       Album = albums.Single(a => a.Title == "Led Zeppelin II"),
                                       Duration = 263,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Moby Dick",
                                       Album = albums.Single(a => a.Title == "Led Zeppelin II"),
                                       Duration = 261,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bring It on Home",
                                       Album = albums.Single(a => a.Title == "Led Zeppelin II"),
                                       Duration = 260,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crucify",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 298,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Girl",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 246,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Silent All These Years",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 274,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Precious Things",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 285,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Winter",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 345,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Happy Phantom",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 196,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "China",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 298,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Leather",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 191,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mother",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 417,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tear in Your Hand",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 277,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Me and a Gun",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 223,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Little Earthquakes",
                                       Album = albums.Single(a => a.Title == "Little Earthquakes"),
                                       Duration = 410,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fishies",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 192,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Car Song",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 262,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Many Nights",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 212,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lonely Moon",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 227,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "How To Explain",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 218,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Days Like These",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 248,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dumb Things",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 229,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Lost Song",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 200,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Rhythm",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 206,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Wine Song",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 441,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All That Talking",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 408,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Chariot",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 307,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "'til the Ocean Takes Us All",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 247,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sly",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 234,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hello",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 230,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hotel California",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 233,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rhyme and Reason",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 333,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Two Shoes",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 316,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In My Pocket",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 307,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Longer There",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 236,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Darkness",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 320,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sunny Moon",
                                       Album = albums.Single(a => a.Title == "Live on Earth"),
                                       Duration = 187,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Living",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 251,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Livin'",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 250,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Need Anyone (Demo)",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 267,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Lucky One",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 194,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shine",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 290,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Saints and Sinners",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 216,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Saints & Sinners",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 217,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Whole Of The Moon (Live Version)",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 372,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bend Down Low",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 237,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fear (Radio Edit)",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 216,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Lucky One (Demo Version)",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 238,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Want It Can't Have It",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 194,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Want It Cant Have It",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 195,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dont Need Anyone",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 224,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Need Anyone",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 221,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bend Down Low (Live at The Olympia)",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 310,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Reach Out",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 267,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Promised Land",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 202,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All In A Day",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 182,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "See You Again",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 208,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Family Tree",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 235,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stumble",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 188,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anyone Thats Yet To Come",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 309,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anyone That's Yet To Come",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 305,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Miracle",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 260,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Self Servin Society",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 310,
                                       Rank = 26
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Self Servin' Society",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 924,
                                       Rank = 27
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Homemade Bread",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 924,
                                       Rank = 28
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Time 4 Bed",
                                       Album = albums.Single(a => a.Title == "Living"),
                                       Duration = 924,
                                       Rank = 29
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Probably On A Thursday",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 208,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Perfect Year",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 205,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Only You",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 233,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Changes Everything",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 213,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Seeing Is Believing",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 272,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Think Of Me",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 249,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Any Dream Will Do",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 228,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Don't Know How To Love Him",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 231,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Too Much In Love To Care",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 278,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Phantom of the Opera",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 258,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Make Up My Heart",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 213,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Cry For Me Argentina",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 353,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everything's Alright",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 271,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Whistle Down The Wind",
                                       Album = albums.Single(a => a.Title == "Love Changes Everything"),
                                       Duration = 209,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Magical Mystery Tour",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 169,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Fool on the Hill",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 179,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flying",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 133,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blue Jay Way",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 233,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Your Mother Should Know",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 146,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I'm the Walrus",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 277,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hello Goodbye",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 203,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Strawberry Fields Forever",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 245,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Penny Lane",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 180,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Baby You're a Rich Man",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 179,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All You Need Is Love",
                                       Album = albums.Single(a => a.Title == "Magical Mystery Tour"),
                                       Duration = 217,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Battery",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 312,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Master of Puppets",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 514,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Thing That Should Not Be",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 394,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Welcome Home (Sanitarium) (Sanitarium)",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 387,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Disposable Heroes",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 496,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Leper Messiah",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 340,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Orion",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 506,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Damage Inc.",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 332,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Battery (live)",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 293,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Thing That You Should Not Be (Live)",
                                       Album = albums.Single(a => a.Title == "Master of Puppets"),
                                       Duration = 422,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pain Lies On The Riverside",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 312,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Operation Spirit (The Tyranny Of Tradition)",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 198,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Beauty Of Gray",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 251,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brothers Unaware",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 284,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tired Of Me",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 205,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mirror Song",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 218,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Waterboy",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 187,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Take My Anthem",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 278,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Are The World",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 264,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Good Pain",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 339,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mother Earth Is A Vicious Crowd",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 249,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "10,000 Years (Peace Is Now)",
                                       Album = albums.Single(a => a.Title == "Mental Jewelry"),
                                       Duration = 309,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Foreword",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 13,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Stay",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 187,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Somewhere I Belong",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 213,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lying from You",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 174,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hit the Floor",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 163,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Easier to Run",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 203,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Faint",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 162,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Figure.09",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 196,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Breaking the Habit",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 195,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "From the Inside",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 174,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nobody's Listening",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 178,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Session",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 144,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Numb",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 186,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lying From You [Live LP Underground Tour 2003]",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 183,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "From The Inside [Live LP Underground Tour 2003]",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 175,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Easier To Run [Live LP Underground Tour 2003]",
                                       Album = albums.Single(a => a.Title == "meteora"),
                                       Duration = 201,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Angel",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 379,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Risingson",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 299,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Teardrop",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 330,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Inertia Creeps",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 359,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Exchange",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 250,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dissolved Girl",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 365,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Man Next Door",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 354,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Black Milk",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 380,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mezzanine",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 355,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Group Four",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 490,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "(Exchange)",
                                       Album = albums.Single(a => a.Title == "Mezzanine"),
                                       Duration = 249,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tom Sawyer",
                                       Album = albums.Single(a => a.Title == "Moving Pictures"),
                                       Duration = 276,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Red Barchetta",
                                       Album = albums.Single(a => a.Title == "Moving Pictures"),
                                       Duration = 367,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "YYZ",
                                       Album = albums.Single(a => a.Title == "Moving Pictures"),
                                       Duration = 266,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Limelight",
                                       Album = albums.Single(a => a.Title == "Moving Pictures"),
                                       Duration = 261,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Camera Eye",
                                       Album = albums.Single(a => a.Title == "Moving Pictures"),
                                       Duration = 661,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Witch Hunt",
                                       Album = albums.Single(a => a.Title == "Moving Pictures"),
                                       Duration = 285,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vital Signs",
                                       Album = albums.Single(a => a.Title == "Moving Pictures"),
                                       Duration = 286,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Song Of Joy",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 326,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stagger Lee",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 330,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Henry Lee",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 236,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lovely Creature",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 253,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Where The Wild Roses Grow",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 237,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Curse Of Millhaven",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 543,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Kindness Of Strangers",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 277,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crow Jane",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 254,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "O'Malley's Bar",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 868,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Death Is Not The End",
                                       Album = albums.Single(a => a.Title == "Murder Ballads"),
                                       Duration = 268,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Intro",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 45,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Break and Enter",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 387,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Their Law",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 400,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Full Throttle",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 303,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Voodoo People",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 387,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Speedway (Theme from \"Fastlane\")",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 534,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Heat (The Energy)",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 267,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Poison",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 374,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Good (Start the Dance)",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 377,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Love (edit)",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 232,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Narcotic Suite: 3 Kilos",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 445,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Narcotic Suite: Skylined",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 358,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Narcotic Suite: Claustrophobic Song",
                                       Album = albums.Single(a => a.Title == "Music For The Jilted Generation"),
                                       Duration = 432,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Name Is Skrillex",
                                       Album = albums.Single(a => a.Title == "My Name is Skrillex"),
                                       Duration = 272,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "WEEKENDS!!!",
                                       Album = albums.Single(a => a.Title == "My Name is Skrillex"),
                                       Duration = 285,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fucking Die 1",
                                       Album = albums.Single(a => a.Title == "My Name is Skrillex"),
                                       Duration = 230,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fucking Die 2 (€€ Cooper Mix)",
                                       Album = albums.Single(a => a.Title == "My Name is Skrillex"),
                                       Duration = 337,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Do Da Oliphant",
                                       Album = albums.Single(a => a.Title == "My Name is Skrillex"),
                                       Duration = 207,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "With You Friends",
                                       Album = albums.Single(a => a.Title == "My Name is Skrillex"),
                                       Duration = 382,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Smells Like Teen Spirit",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 302,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In Bloom",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 255,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Come as You Are",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 219,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Breed",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 184,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lithium",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 257,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Polly",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 196,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Territorial Pissings",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 143,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Drain You",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 224,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lounge Act",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 156,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stay Away",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 211,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "On a Plain",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 225,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Something in the Way",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 242,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Endless, Nameless",
                                       Album = albums.Single(a => a.Title == "Nevermind"),
                                       Duration = 404,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "New Divide (Album Version)",
                                       Album = albums.Single(a => a.Title == "New Divide"),
                                       Duration = 271,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Personality Crisis",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 228,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Looking for a Kiss",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 227,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vietnamese Baby",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 277,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lonely Planet Boy",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 248,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Frankenstein (Orig.)",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 359,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Trash",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 234,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bad Girl",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 190,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Subway Train",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 300,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pills",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 175,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Private World",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 233,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jet Boy",
                                       Album = albums.Single(a => a.Title == "New York Dolls"),
                                       Duration = 394,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Night Enchanted",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 346,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Childhood Dreams",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 265,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sparks",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 359,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Mountain",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 293,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Night Castle",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 237,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Safest Way Into Tomorrow",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 297,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mozart And Memories",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 316,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Another Way You Can Die",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 234,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Toccata - Carpimus Noctem",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 242,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Lion's Roar",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 275,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dreams We Conceive",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 310,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mother And Son",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 40,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "There Was A Life",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 575,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Moonlight and Madness",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 304,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Time Floats On",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 217,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Epiphany",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 656,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bach Lullaby",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 49,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Father, Son & Holy Ghost",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 408,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Remnants Of A Lullaby",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 190,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Safest Way Into Tomorrow (Reprise)",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 103,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Embers",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 227,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Child Of The Night",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 207,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Believe",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 372,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nutrocker",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 245,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Carmina Burana",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 162,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tracers",
                                       Album = albums.Single(a => a.Title == "Night Castle"),
                                       Duration = 347,
                                       Rank = 26
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Quasar",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 296,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Panopticon",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 232,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Celestials",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 238,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Violet Rays",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 259,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Love Is Winter",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 212,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Diamond, One Heart",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 230,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pinwheels",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 344,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oceania",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 547,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pale Horse",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 278,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Chimera",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 257,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Glissandra",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 247,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Inkless",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 188,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wildflower",
                                       Album = albums.Single(a => a.Title == "Oceania"),
                                       Duration = 283,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Airbag",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 285,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Paranoid Android",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 384,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Subterranean Homesick Alien",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 268,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Exit Music (for a Film)",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 265,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Let Down",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 300,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Karma Police",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 263,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fitter Happier",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 117,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Electioneering",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 231,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Climbing up the Walls",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 285,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Surprises",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 229,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lucky",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 260,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Tourist",
                                       Album = albums.Single(a => a.Title == "OK Computer"),
                                       Duration = 327,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "When Love Takes Over (feat. Kelly Rowland)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 191,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gettin' Over (feat. Chris Willis)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 180,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sexy Bitch (feat. Akon)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 195,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Memories (feat. Kid Cudi)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 210,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "On The Dancefloor (feat. will.i.am & apl.de.ap)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 223,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It's The Way You Love Me (feat. Kelly Rowland)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 252,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Missing You (feat. Novel)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 184,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Choose (feat. Ne-Yo & Kelly Rowland)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 238,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "How Soon Is Now (Dirty South)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 249,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Gotta Feeling (FMIF Remix) [Edit]",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 225,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Love (feat. Estelle)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 241,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Wanna Go Crazy (feat.  will.i.am)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 204,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sound Of Letting Go (feat. Chris Willis)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 226,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Toyfriend (feat. Wynter Gordon)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 197,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "If We Ever (feat. Makeba)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 281,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gettin' Over You (feat. Fergie & LMFAO)",
                                       Album = albums.Single(a => a.Title == "One Love"),
                                       Duration = 185,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Remember Now (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 77,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anarchy-X (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 87,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Revolution Calling (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 278,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Operation: Mindcrime (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 284,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Speak (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 221,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spreading The Disease (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 246,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Mission (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 346,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Suite Sister Mary (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 637,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Needle Lies (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 188,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Electric Requiem (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 82,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Breaking The Silence (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 273,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Don't Believe In Love (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 262,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Waiting For 22 (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 65,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Empty Room (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 92,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eyes Of A Stranger (2003 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 412,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Mission (Live) (2006 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 369,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Empty Room (Live 24-Bit Digitally Remastered 06)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 162,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Remember Now (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 71,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anarchy-X (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 87,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Revolution Calling (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 290,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Operation: Mindcrime (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 254,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Speak (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 226,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spreading The Disease (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 311,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Mission (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 349,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Suite Sister Mary (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 721,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Needle Lies (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 206,
                                       Rank = 26
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Electric Requiem (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 76,
                                       Rank = 27
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Breaking The Silence (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 273,
                                       Rank = 28
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Don't Believe In Love (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 268,
                                       Rank = 29
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Waiting For 22 (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 71,
                                       Rank = 30
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Empty Room (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 86,
                                       Rank = 31
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eyes Of A Stranger (Live)",
                                       Album = albums.Single(a => a.Title == "Operation: Mindcrime"),
                                       Duration = 471,
                                       Rank = 32
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sweat",
                                       Album = albums.Single(a => a.Title == "Opiate"),
                                       Duration = 226,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hush",
                                       Album = albums.Single(a => a.Title == "Opiate"),
                                       Duration = 173,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Part of Me",
                                       Album = albums.Single(a => a.Title == "Opiate"),
                                       Duration = 206,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cold and Ugly (live)",
                                       Album = albums.Single(a => a.Title == "Opiate"),
                                       Duration = 247,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jerk-Off (live)",
                                       Album = albums.Single(a => a.Title == "Opiate"),
                                       Duration = 253,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Opiate",
                                       Album = albums.Single(a => a.Title == "Opiate"),
                                       Duration = 509,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Gaping Lotus Experience",
                                       Album = albums.Single(a => a.Title == "Opiate"),
                                       Duration = 139,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Glue of the World",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 301,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Twenty Three",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 213,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Harmony One",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 101,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Parks",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 362,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Leila Came Around And We Watched A Video",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 99,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Untangle",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 275,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everything Is Alright",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 151,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No More Mosquitoes",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 218,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tangle",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 223,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Could Ruin My Day",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 422,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hilarious Movie of the 90's",
                                       Album = albums.Single(a => a.Title == "Pause"),
                                       Duration = 208,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Custard Pie",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 253,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Rover",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 337,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In My Time Of Dying",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 665,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Houses Of The Holy",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 242,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Trampled Under Foot",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 336,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kashmir",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 508,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In The Light",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 526,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bron-Yr-Aur",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 126,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Down By The Seaside",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 316,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ten Years Gone",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 392,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Night Flight",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 217,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Wanton Song",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 249,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Boogie With Stu",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 233,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Black Country Woman",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 272,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sick Again",
                                       Album = albums.Single(a => a.Title == "Physical Graffiti"),
                                       Duration = 282,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tired of Sex",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 181,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Getchoo",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 173,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Other One",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 182,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Why Bother?",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 126,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Across the Sea",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 275,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Good Life",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 257,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "El Scorcho",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 244,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pink Triangle",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 238,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Falling For You",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 229,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Butterfly",
                                       Album = albums.Single(a => a.Title == "Pinkerton"),
                                       Duration = 175,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Head Like a Hole",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 300,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Terrible Lie",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 299,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Down in It",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 227,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sanctified",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 349,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Something I Can Never Have",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 400,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kinda I Want To",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 275,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sin",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 255,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "That's What I Get",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 269,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Only Time",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 288,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ringfinger",
                                       Album = albums.Single(a => a.Title == "Pretty Hate Machine"),
                                       Duration = 342,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Prisoner",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 252,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Endless Summer",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 251,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Long Highway",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 362,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Try Colour",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 314,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rosebud",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 255,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "City Girl",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 324,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nobody Nowhere",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 164,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Horsehead",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 269,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Austerlitz",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 184,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deep Wide Ocean",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 285,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Piece of Mind",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 241,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Reprise",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 56,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Catch Me",
                                       Album = albums.Single(a => a.Title == "Prisoner"),
                                       Duration = 345,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Redbud Tree",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 199,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Haul Away",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 242,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Forget Your Hat",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 315,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Privateering",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 379,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Miss You Blues",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 258,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Corned Beef City",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 212,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Go, Love",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 293,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hot Or What",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 294,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Yon Two Crows",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 267,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Seattle",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 257,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kingdom Of Gold",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 323,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Got To Have Something",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 241,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Radio City Serenade",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 313,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Used To Could",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 216,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gator Blood",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 255,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bluebird",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 207,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dream Of The Drowned Submariner",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 297,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blood And Water",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 319,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Today Is Okay",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 285,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "After The Beanstalk",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 234,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Why Aye Man (Live From Music Bank London/2011)",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 430,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cleaning My Gun (Live From Music Bank London/2011)",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 284,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Corned Beef City (Live From Music Bank London/2011)",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 266,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sailing To Philadelphia (Live From Music Bank London/2011)",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 433,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hill Farmer's Blues (Live From Music Bank London/2011)",
                                       Album = albums.Single(a => a.Title == "Privateering"),
                                       Duration = 316,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Meatplow",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 218,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vasoline",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 176,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lounge Fly",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 318,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Interstate Love Song",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 194,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Still Remains",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 213,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pretty Penny",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 221,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Silvergun Superman",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 316,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Big Empty",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 295,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Unglued",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 182,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Army Ants",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 226,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kitchenware & Candybars",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 271,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Andy Warhol (MTV Unplugged) / My Second Album",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 396,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vasoline(LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 175,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Interstate Love Song (LP version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 193,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Silvergun Superman (LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 316,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pretty Penny (LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 222,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Meatplow (LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 218,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Still Remains (LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 213,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kitchenware & Candybars (LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 486,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Army Ants (LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 226,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Unglued (LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 154,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lounge Fly (LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 319,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Big Empty (LP Version)",
                                       Album = albums.Single(a => a.Title == "Purple"),
                                       Duration = 293,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Raoul And The Kings Of Spain",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 314,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Falling Down",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 293,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Secrets",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 281,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "God's Mistake",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 226,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sketches of Pain",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 259,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Los Reyes Católicos",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 104,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Los Reyes Catolicos",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 104,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sorry",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 287,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Humdrum and Humble",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 249,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Choose You",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 205,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Drink The Water",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 289,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Me And My Big Ideas",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 270,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Los Reyes Católicos (Reprise)",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 222,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Los Reyes Catolicos (Reprise)",
                                       Album = albums.Single(a => a.Title == "Raoul and the Kings of Spain "),
                                       Duration = 222,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Angel Of Death",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 291,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Piece By Piece",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 122,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Necrophobic",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 100,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Altar Of Sacrifice",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 170,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jesus Saves",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 174,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Criminally Insane",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 143,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Reborn",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 131,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Epidemic",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 143,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Postmortem",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 207,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Raining Blood",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 253,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Aggressive Perfector",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 149,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Criminally Insane (Remix)",
                                       Album = albums.Single(a => a.Title == "Reign In Blood"),
                                       Duration = 187,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Taxman",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 158,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eleanor Rigby",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 127,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I'm Only Sleeping",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 177,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love You To",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 176,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Here, There and Everywhere",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 145,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Yellow Submarine",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 158,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "She Said She Said",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 153,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Good Day Sunshine",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 129,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "And Your Bird Can Sing",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 132,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "For No One",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 117,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Doctor Robert",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 132,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Want to Tell You",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 148,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tomorrow Never Knows",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 176,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Got to Get You Into My Life",
                                       Album = albums.Single(a => a.Title == "Revolver"),
                                       Duration = 146,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Exordium",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 87,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pitch-Black Universe",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 283,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Phoenix Rising",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 283,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cross To Bear",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 209,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Throne of Ice",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 391,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Perfect Storm",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 282,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fallen World",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 262,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eclipse",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 339,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Closure",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 224,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Unbreakable (2012 Version)",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 197,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deliverance",
                                       Album = albums.Single(a => a.Title == "Rise of the Phoenix"),
                                       Duration = 205,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Such Thing",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 230,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Why Georgia",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 233,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Stupid Mouth",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 219,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Your Body Is A Wonderland",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 248,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Neon",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 249,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "City Love",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 238,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "83",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 289,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "3x5",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 289,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Song For No One",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 290,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Back To You",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 260,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Great Indoors",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 243,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Not Myself",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 216,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "[silence]",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 4,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "St. Patrick's Day",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 318,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Phantom Track",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 4,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lenny",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 130,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Wind Cries Mary",
                                       Album = albums.Single(a => a.Title == "Room for Squares"),
                                       Duration = 235,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sagg Shootin' His Arrow",
                                       Album = albums.Single(a => a.Title == "Root Down"),
                                       Duration = 704,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "For Everyone Under The Sun",
                                       Album = albums.Single(a => a.Title == "Root Down"),
                                       Duration = 355,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "After Hours",
                                       Album = albums.Single(a => a.Title == "Root Down"),
                                       Duration = 659,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Root Down And Get It",
                                       Album = albums.Single(a => a.Title == "Root Down"),
                                       Duration = 66,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Let's Stay Together",
                                       Album = albums.Single(a => a.Title == "Root Down"),
                                       Duration = 385,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Slow Down Sagg",
                                       Album = albums.Single(a => a.Title == "Root Down"),
                                       Duration = 621,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Root Down And Get It (Alternate Take)",
                                       Album = albums.Single(a => a.Title == "Root Down"),
                                       Duration = 732,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hands",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 339,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "She Moves She",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 280,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "First Thing",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 73,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Angel Rocks Back and Forth",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 306,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spirit Fingers",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 201,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Unspoken",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 568,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Chia",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 32,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "As Serious as Your Life",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 287,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "And They All Look Broken Hearted",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 308,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Slow Jam",
                                       Album = albums.Single(a => a.Title == "Rounds"),
                                       Duration = 317,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "When The Lights Go Out",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 192,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "10 A.M. Automatic",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 179,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Just Couldn't Tie Me Down",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 178,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All Hands Against His Own",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 197,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Desperate Man",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 235,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Girl Is On My Mind",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 208,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Lengths",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 295,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Grown So Ugly",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 148,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stack Shot Billy",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 202,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Act Nice and Gentle",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 162,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Aeroplane Blues",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 171,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Keep Me",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 172,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Till I Get My Way",
                                       Album = albums.Single(a => a.Title == "Rubber Factory"),
                                       Duration = 151,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Holy Wars...The Punishment Due (2004 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 375,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hangar 18 (2004 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 310,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Take No Prisoners (2004 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 206,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Five Magics (24-Bit Digitally Remastered 04)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 338,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Poison Was The Cure (24-Bit Digitally Remastered 04)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 176,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lucretia (24-Bit Digitally Remastered 04)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 235,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tornado Of Souls (2004 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 318,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dawn Patrol (24-Bit Digitally Remastered 04)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 111,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rust In Peace...Polaris (24-Bit Digitally Remastered 04)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 342,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Creation (24-Bit Digitally Remastered 04)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 96,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rust In Peace...Polaris (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 324,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Take No Prisoners (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Rust in Peace"),
                                       Duration = 202,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rock N’ Roll (Will Take You to the Mountain)",
                                       Album = albums.Single(a => a.Title == "Scary Monsters and Nice Sprites"),
                                       Duration = 286,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Scary Monsters and Nice Sprites",
                                       Album = albums.Single(a => a.Title == "Scary Monsters and Nice Sprites"),
                                       Duration = 197,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kill Everybody",
                                       Album = albums.Single(a => a.Title == "Scary Monsters and Nice Sprites"),
                                       Duration = 299,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All I Ask of You",
                                       Album = albums.Single(a => a.Title == "Scary Monsters and Nice Sprites"),
                                       Duration = 342,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Scatta",
                                       Album = albums.Single(a => a.Title == "Scary Monsters and Nice Sprites"),
                                       Duration = 236,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "With You, Friends (Long Drive)",
                                       Album = albums.Single(a => a.Title == "Scary Monsters and Nice Sprites"),
                                       Duration = 389,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Breaking Into Heaven",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 418,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Driving South",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 310,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ten Storey Love Song",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 260,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Daybreak",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 394,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Your Star Will Shine",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 176,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Straight to the Man",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 194,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Begging You",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 293,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tightrope",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 264,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Good Times",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 341,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tears",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 411,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "How Do You Sleep",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 300,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Spreads",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 347,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Foz",
                                       Album = albums.Single(a => a.Title == "Second Coming"),
                                       Duration = 387,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bag Of Glue",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 262,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pure Awkward",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 229,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Bank",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 263,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Wanna Fight Your Father",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 209,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Be Mhaith Liom Bruíon Le D'Athair",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 231,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tommy Bread",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 131,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Willie O'Dea",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 285,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Horse Outside",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 216,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Psychiatrist",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 222,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Up Da Ra",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 253,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Greyhound Shuffle",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 247,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Antneys Eye",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 286,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "[unknown]",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 705,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "26 x 28 cm. Oil on Mr. Consodine",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 89,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Like To Shift Girls",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 244,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Black Man",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 184,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fight Me At Mass",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 165,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Banknodes",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 92,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spoiling Ivan",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 228,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Buddies In Boston",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 141,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Choppy Nagle",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 96,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spastic Hawk",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 260,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Drawing",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 95,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Danny Dyer",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 245,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Double Dropping Yokes with Eamon DeValera",
                                       Album = albums.Single(a => a.Title == "Serious About Men"),
                                       Duration = 273,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hey Man Nice Shot",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 312,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dose",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 234,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Under",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 258,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spent",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 278,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Take Another",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 263,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stuck in Here",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 214,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It's Over",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 216,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gerbil",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 201,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "White Like That",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 257,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Consider This",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 259,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Cool",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 266,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It's Over (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 216,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stuck In Here (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 215,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Take Another (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 263,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spent (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 278,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Under (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 258,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dose (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 234,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gerbil (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 201,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hey Man Nice Shot (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 314,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "White Like That (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 257,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Consider This (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 259,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Cool (Album Version)",
                                       Album = albums.Single(a => a.Title == "Short Bus"),
                                       Duration = 266,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Space Oddity (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 315,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Changes (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 215,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Starman",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 254,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ziggy Stardust (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 194,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Suffragette City (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 206,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "John, I'm Only Dancing (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 167,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jean Genie",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 318,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Drive-In Saturday",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 270,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Life on Mars?",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 222,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sorrow",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 171,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rebel Rebel (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 264,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rock & Roll Suicide",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 178,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Diamond Dogs (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 364,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Knock on Wood",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 206,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Young Americans (1990 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 313,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fame",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 251,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Golden Years",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 243,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "TVC 15",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 222,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sound and Vision",
                                       Album = albums.Single(a => a.Title == "Singles Collection"),
                                       Duration = 185,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Glass Prison (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 832,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Solitary Shell (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 348,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Blind Faith (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 621,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Misunderstood (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 0,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Great Debate (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 825,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Disappear (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 405,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Overture (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 409,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "About To Crash (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 350,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "War Inside My Head (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 128,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Test That Stumped Them All (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 303,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Goodnight Kiss (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 377,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "About To Crash - Reprise (LP Version)",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 245,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Losing Time / Grand Finale (LP Version",
                                       Album = albums.Single(a => a.Title == "Six Degrees of Inner Turbulence"),
                                       Duration = 360,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Say Sorry",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 196,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wide Open",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 211,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everything Under the Stars",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 309,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Get Raw (Midnight Mix)",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 249,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Heroine",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 264,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mine, Mine, Mine",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 227,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In My Van",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 228,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nothing (Where's Jimmy Longneck)",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 205,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Still ... I Worry (Snack Song)",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 228,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Gimme the Blues",
                                       Album = albums.Single(a => a.Title == "Slouching Towards Bethlehem"),
                                       Duration = 272,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Time to Relax",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 25,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nitro (Youth Energy)",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 147,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bad Habit",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 223,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gotta Get Away",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 232,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Genocide",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 213,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Something to Believe In",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 197,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Come Out and Play",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 197,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Self Esteem",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 257,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It'll Be a Long Time",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 163,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Killboy Powerhead",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 122,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What Happened to You?",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 132,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Alone",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 77,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Not the One",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 174,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Smash",
                                       Album = albums.Single(a => a.Title == "Smash"),
                                       Duration = 640,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crippled Bird",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 224,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Something Special",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 185,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Change",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 220,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Will Always Love You",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 261,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Will Always Love You",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 197,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Will Always Love You",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 198,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Green-Eyed Boy",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 233,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Speakin' Of The Devil",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 194,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jolene",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 179,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Good Way Of Saying Good-bye",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 177,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Seeker",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 183,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Teach Me To Trust",
                                       Album = albums.Single(a => a.Title == "Something Special"),
                                       Duration = 207,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spiritual State",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 392,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sky is Tumbling",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 269,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gone Are The Days",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 362,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spiral",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 221,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "City Lights",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 194,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Color Of Autumn",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 104,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dawn On The Side",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 315,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Yes",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 471,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rainyway Back Home",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 156,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Far Fowls",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 265,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fellows",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 124,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Waiting for the Clouds",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 232,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Prayer",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 209,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Island",
                                       Album = albums.Single(a => a.Title == "Spiritual State"),
                                       Duration = 307,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Moor (Remastered)",
                                       Album = albums.Single(a => a.Title == "Still Life"),
                                       Duration = 684,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Godhead's Lament",
                                       Album = albums.Single(a => a.Title == "Still Life"),
                                       Duration = 814,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Benighted",
                                       Album = albums.Single(a => a.Title == "Still Life"),
                                       Duration = 529,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Moonlapse Vertigo",
                                       Album = albums.Single(a => a.Title == "Still Life"),
                                       Duration = 540,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Face of Melinda",
                                       Album = albums.Single(a => a.Title == "Still Life"),
                                       Duration = 599,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Serenity Painted Death",
                                       Album = albums.Single(a => a.Title == "Still Life"),
                                       Duration = 551,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "White Cluster",
                                       Album = albums.Single(a => a.Title == "Still Life"),
                                       Duration = 564,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Psycho Killer",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 268,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Heaven",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 221,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Thank You for Sending Me an Angel",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 130,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Found a Job",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 299,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Slippery People (Live)",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 252,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Burning Down The House",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 246,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Life During Wartime",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 220,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Making Flippy Floppy",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 280,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Swamp",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 314,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What a Day That Was",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 360,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Naive Melody (This Must Be the Place)",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 296,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Once in a Lifetime",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 259,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Genius of Love",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 445,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Girlfriend Is Better",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 266,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Take Me to the River",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 333,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crosseyed and Painless",
                                       Album = albums.Single(a => a.Title == "Stop Making Sense"),
                                       Duration = 429,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Incomplete",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 148,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Leave Mine to Me",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 126,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stranger Than Fiction",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 141,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tiny Voices",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 156,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Handshake",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 169,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Better Off Dead",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 158,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Infected",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 246,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Television",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 123,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Individual",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 117,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hooray for Me...",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 168,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Slumber",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 160,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Marked",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 107,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Inner Logic",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 177,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What It Is",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 127,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "21st Century Digital Boy",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 177,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "21st Century (Digital Boy)",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 167,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "News From the Front",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 141,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Markovian Process",
                                       Album = albums.Single(a => a.Title == "Stranger than Fiction"),
                                       Duration = 89,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Get Your Snack On",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 262,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Four Ton Mantis",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 254,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Slowly",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 338,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Marine Machines",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 345,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Golfer versus Boxer",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 378,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deo",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 405,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Precursor",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 280,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Saboteur",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 319,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Chocolate Lovely",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 364,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rhino Jockey",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 449,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Keepin' It Steel",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 270,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Natureland",
                                       Album = albums.Single(a => a.Title == "Supermodified"),
                                       Duration = 349,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sinfonia to Cantata BWV 29",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 206,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Air on a G String from Orchestral Suite No. 3, BWV 1068",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 153,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Two-Part Invention No. 8 in F major, BWV 779",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 46,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Two-Part Invention No. 14 in B-flat major, BWV 785",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 94,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Two-Part Invention No. 4 in D minor, BWV 775",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 53,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jesu, Joy of Man's Desiring",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 179,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name =
                                           "Well-Tempered Clavier, Book 1: Prelude and Fugue No. 7 in E-Flat major, BWV 852",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 434,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name =
                                           "Well-Tempered Clavier, Book 1: Prelude and Fugue No. 2 in C minor, BWV 847",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 167,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wachet auf, ruft uns die Stimme, BWV 645",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 218,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brandenburg Concerto, No. 3 in G major, BWV 1048: I. Allegro",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 390,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name =
                                           "Brandenburg Concerto, No. 3 in G major, BWV 1048: II. Adagio (1968 version)",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 172,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brandenburg Concerto, No. 3 in G major, BWV 1048: III. Allegro",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 311,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Initial Experiments & Demonstration",
                                       Album = albums.Single(a => a.Title == "Switched-On Bach"),
                                       Duration = 514,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gothica",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 79,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fleurs Du Mal",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 249,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Symphony",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 285,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Canto Della Terra",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 239,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sanvean",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 230,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Will Be With You (Where The Lost Ones Go)",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 271,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Schwere Träume",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 201,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sarai Qui",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 236,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Storia d'Amore",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 242,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Let It Rain",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 256,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Attesa",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 269,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pasión",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 316,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Running",
                                       Album = albums.Single(a => a.Title == "Symphony"),
                                       Duration = 369,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stranglehold",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 502,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stormtroopin'",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 355,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hey Baby",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 238,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Just What The Doctor Ordered",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 221,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Snakeskin Cowboys",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 272,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Motor City Madhouse",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 261,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Where Have You Been All My Life",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 243,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Make Me Feel Right At Home",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 171,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Queen Of The Forest",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 214,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stormtroopin' (Hammersmith Odeon, London)",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 404,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Just What The Doctor Ordered (Hammersmith Odeon, London)",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 291,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Motor City Madhouse (Hammersmith Odeon, London)",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 514,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Magic Party (Outtake)",
                                       Album = albums.Single(a => a.Title == "Ted Nugent"),
                                       Duration = 176,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I'm Not A Star",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 180,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Free Mason",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 248,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tears Of Joy",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 334,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Maybach Music III",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 266,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Live Fast, Die Young",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 374,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Super High",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 227,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No. 1",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 234,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "MC Hammer",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 299,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "B.M.F. (Blowin' Money Fast)",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 250,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Aston Martin Music",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 271,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All The Money In The World",
                                       Album = albums.Single(a => a.Title == "Teflon Don"),
                                       Duration = 281,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Once",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 215,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Even Flow",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 449,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Alive",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 385,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Why Go",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 199,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Black",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 420,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Jeremy",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 331,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oceans",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 204,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Porch",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 433,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Garden",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 212,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Alive (live)",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 293,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deep",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 267,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Release",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 323,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Master/Slave",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 228,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Alive (Live Version)",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 292,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wash",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 213,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dirty Frank",
                                       Album = albums.Single(a => a.Title == "Ten"),
                                       Duration = 337,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I'm Cryin'",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 227,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mary Had A Little Lamb (Live)",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 368,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rude Mood",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 168,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tell Me",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 181,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Testify",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 202,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Testify (Live)",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 234,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "SRV Speaks",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 102,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pride And Joy",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 193,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dirty Pool",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 320,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Struck Baby",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 132,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mary Had A Little Lamb",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 255,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lenny",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 307,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wham! (Live)",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 261,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tin Pan Alley (aka Roughest Pl",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 462,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Texas Flood",
                                       Album = albums.Single(a => a.Title == "Texas Flood"),
                                       Duration = 321,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Give It To Me Right (Acoustic Version)",
                                       Album = albums.Single(a => a.Title == "The Bridge"),
                                       Duration = 198,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Monday Morning (Acoustic Version)",
                                       Album = albums.Single(a => a.Title == "The Bridge"),
                                       Duration = 272,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Teach Him (Acoustic Version)",
                                       Album = albums.Single(a => a.Title == "The Bridge"),
                                       Duration = 282,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "It Kills Me (Acoustic Version)",
                                       Album = albums.Single(a => a.Title == "The Bridge"),
                                       Duration = 244,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ay Yo (Acoustic Version)",
                                       Album = albums.Single(a => a.Title == "The Bridge"),
                                       Duration = 214,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rendezvous",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 199,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lonely At The Top",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 234,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Letter From L. A.",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 193,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Paris By Air",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 187,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tides",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 258,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Making Tracks",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 218,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Cage",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 73,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Potion No. 9",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 127,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Always See What You Want to See",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 193,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Danger in Paradise",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 208,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Actor",
                                       Album = albums.Single(a => a.Title == "The Cage"),
                                       Duration = 258,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Chronic (Intro)",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 117,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fuck Wit Dre Day (And Everybody's Celebratin')",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 154,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Let Me Ride",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 261,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Day The Niggaz Took Over (Soundtrack Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 273,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nuthin' But a \"G\" Thang",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 239,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deeez Nuuuts",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 225,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lil' Ghetto Boy",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 326,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "A Nigga Witta Gun",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 233,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rat-Tat-Tat-Tat",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 229,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The $20 Sack Pyramid",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 173,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lyrical Gangbang",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 243,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "High Powered",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 164,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Doctor's Office",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 63,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stranded on Death Row",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 285,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Roach (The Chronic Outro)",
                                       Album = albums.Single(a => a.Title == "The Chronic"),
                                       Duration = 277,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Crane Wife 3",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 258,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Island",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 743,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Yankee Bayonet (I Will Be Home Then)",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 259,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "O Valencia!",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 236,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Perfect Crime #2",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 333,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "When the War Came",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 305,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shankill Butchers",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 279,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Summersong",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 208,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Crane Wife 1 & 2",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 681,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sons & Daughters",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 313,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Culling Of The Fold",
                                       Album = albums.Single(a => a.Title == "The Crane Wife"),
                                       Duration = 262,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lost",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 248,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Labyrinth",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 315,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Before Three",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 280,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The End Of The World",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 224,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anniversary",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 263,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Us Or Them",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 250,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "alt.end",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 271,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "(I Don't Know What's Going) On",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 178,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Taking Off",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 200,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Never",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 245,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Promise",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 613,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Going Nowhere",
                                       Album = albums.Single(a => a.Title == "The Cure"),
                                       Duration = 208,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "(A) Speak To Me (B) Breathe In The Air",
                                       Album = albums.Single(a => a.Title == "The Dark Side Of The Moon"),
                                       Duration = 237,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "On the Run",
                                       Album = albums.Single(a => a.Title == "The Dark Side Of The Moon"),
                                       Duration = 213,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Time",
                                       Album = albums.Single(a => a.Title == "The Dark Side Of The Moon"),
                                       Duration = 409,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Great Gig in the Sky",
                                       Album = albums.Single(a => a.Title == "The Dark Side Of The Moon"),
                                       Duration = 284,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Money",
                                       Album = albums.Single(a => a.Title == "The Dark Side Of The Moon"),
                                       Duration = 392,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Us and Them",
                                       Album = albums.Single(a => a.Title == "The Dark Side Of The Moon"),
                                       Duration = 471,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Any Colour You Like",
                                       Album = albums.Single(a => a.Title == "The Dark Side Of The Moon"),
                                       Duration = 176,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eclipse",
                                       Album = albums.Single(a => a.Title == "The Dark Side Of The Moon"),
                                       Duration = 122,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Brain Damage",
                                       Album = albums.Single(a => a.Title == "The Dark Side Of The Moon"),
                                       Duration = 247,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Indigo",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 126,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Obsessive Devotion",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 433,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Menace of Vanity",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 254,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Chasing the Dragon",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 460,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Never Enough",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 287,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "La'Fetach Chatat Rovetz - The Last Embrace",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 108,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Death Of A Dream - The Embrace That Smothers Part 7",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 364,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fools Of Damnation - The Embrace That Smothers Part 9",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 522,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Living A Lie - The Embrace That Smothers Part 8",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 297,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Beyond Belief",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 325,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Safeguard to Paradise",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 228,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sancta Terra",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 298,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Divine Conspiracy",
                                       Album = albums.Single(a => a.Title == "The Divine Conspiracy"),
                                       Duration = 833,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "If You Love Somebody Set Them Free",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 297,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Is The Seventh Wave",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 212,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Russians",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 239,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Children's Crusade",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 302,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shadows In The Rain",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 290,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "We Work The Black Seam",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 343,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Consider Me Gone",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 261,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Dream Of The Blue Turtles",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 78,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Moon Over Bourbon Street",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 175,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fortress Around Your Heart",
                                       Album = albums.Single(a => a.Title == "The Dream of the Blue Turtles"),
                                       Duration = 277,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Satellite 15.....The Final Frontier",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 519,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "El Dorado",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 353,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mother Of Mercy",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 319,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Coming Home",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 358,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Alchemist",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 268,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Isle Of Avalon",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 544,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Starblind",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 466,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Talisman",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 526,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Man Who Would Be King",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 506,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "When The Wild Wind Blows",
                                       Album = albums.Single(a => a.Title == "The Final Frontier"),
                                       Duration = 638,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lost In My Mind",
                                       Album = albums.Single(a => a.Title == "The Head and the Heart"),
                                       Duration = 258,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Where The Streets Have No Name (Album Version - Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 336,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Still Haven't Found What I'm Looking For (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 277,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "With Or Without You (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 295,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bullet The Blue Sky (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 271,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Running To Stand Still (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 257,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Red Hill Mining Town (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 292,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In God's Country (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 176,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Trip Through Your Wires (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 211,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Tree Hill (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 322,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Exit (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 253,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mothers Of The Disappeared (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 314,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Luminous Times (Hold On To Love) (Remasterd)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 274,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Walk To The Water (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 289,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spanish Eyes (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 193,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deep In The Heart (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 270,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Silver And Gold (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 277,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sweetest Thing (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 184,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Race Against Time (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 242,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Where The Streets Have No Name (Single Edit Remastered)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 287,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Silver And Gold (Sun City Version)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 282,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Beautiful Ghost/Introduction To Songs Of Experience",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 232,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wave Of Sorrow (Birdland)",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 243,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Desert Of Our Love",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 296,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rise Up",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 244,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Drunk Chicken/America",
                                       Album = albums.Single(a => a.Title == "The Joshua Tree"),
                                       Duration = 91,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flowers in Your Hair",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 110,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Classy Girl",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 166,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Submarines",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 163,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dead Sea",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 248,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ho Hey",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 163,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Slow It Down",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 307,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stubborn Love",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 279,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Big Parade",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 328,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Charlie Boy",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 262,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flapper Girl",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 195,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Morning Song",
                                       Album = albums.Single(a => a.Title == "The Lumineers"),
                                       Duration = 319,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sting Me",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 266,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Remedy",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 335,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Thorn In My Pride",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 575,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bad Luck Blue Eyes Goodbye",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 389,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sometimes Salvation",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 387,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hotel Illness",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 218,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Black Moon Creeping",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 357,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No Speak No Slave",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 330,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Morning Song",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 376,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Time Will Tell",
                                       Album =
                                           albums.Single(a => a.Title == "The Southern Harmony and Musical Companion"),
                                       Duration = 247,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Wanna Be Adored (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 296,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Wanna Be Adored",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 292,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "She Bangs The Drums (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 229,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "She Bangs the Drums",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 222,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Elephant Stone",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 183,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Waterfall (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 279,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Waterfall",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 218,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Stop (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 320,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bye Bye Badman",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 246,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Stop",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 320,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bye Bye Bad Man (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 243,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bye Bye Bad Man",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 244,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Elizabeth My Dear (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 52,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Elizabeth My Dear",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 54,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "(Song For My) Sugar Spun Sister (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 204,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Made Of Stone (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 254,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "(Song for My) Sugar Spun Sister",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 204,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shoot You Down (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 251,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Made of Stone",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 253,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "This Is The One (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 299,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shoot You Down",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 251,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "This Is the One",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 298,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Am The Resurrection (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 495,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fools Gold (Remastered)",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 592,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Am the Resurrection",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 493,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fools Gold",
                                       Album = albums.Single(a => a.Title == "The Stone Roses"),
                                       Duration = 323,
                                       Rank = 26
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Suburbs",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 314,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ready To Start",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 254,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Modern Man",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 280,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rococo",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 237,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Empty Room",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 171,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "City With No Children",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 192,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Half Light I",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 254,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Half Light II (No Celebration)",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 265,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Suburban War",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 280,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Month of May",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 231,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wasted Hours",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 199,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Deep Blue",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 267,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "We Used to Wait",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 301,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sprawl I (Flatland)",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 174,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sprawl II (Mountains Beyond Mountains)",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 317,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Suburbs (Continued)",
                                       Album = albums.Single(a => a.Title == "The Suburbs"),
                                       Duration = 86,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Early One Morning",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 213,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Come You Not from Newcastle?",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 86,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sweet Polly Oliver",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 173,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Trees They Grow so High",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 273,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Ash Grove",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 162,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "O Waly, Waly",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 276,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "How Sweet the Answer",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 132,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Plough Boy",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 122,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Voici le Printemps",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 120,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Last Rose of Summer",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 272,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "La Belle Est au Jardin d'Amour",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 214,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fileuse",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 124,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dear Harp of My Country!",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 153,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Little Sir William",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 207,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "O Can Ye Sew Cushions?",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 156,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oft in the Stilly Night",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 168,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Quand j'Etais Chez Mon Père",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 129,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "There's None to Soothe",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 129,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Oliver Cromwell",
                                       Album = albums.Single(a => a.Title == "The Trees They Grow So High"),
                                       Duration = 50,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In The Flesh? (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 199,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Thin Ice (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 150,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Another Brick In The Wall (Part 1) (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 190,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Happiest Days Of Our Lives (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 111,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Another Brick In The Wall (Part 2) (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 240,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mother (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 337,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Goodbye Blue Sky (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 168,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Empty Spaces (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 128,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Young Lust (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 210,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Of My Turns (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 217,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Leave Me Now (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 256,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Another Brick In The Wall (Part 3) (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 75,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Goodbye Cruel World (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 75,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hey You (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 281,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Is There Anybody Out There? (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 161,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Nobody Home (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 204,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vera (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 93,
                                       Rank = 17
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bring The Boys Back Home (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 86,
                                       Rank = 18
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Comfortably Numb (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 384,
                                       Rank = 19
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Show Must Go On (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 95,
                                       Rank = 20
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In The Flesh (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 257,
                                       Rank = 21
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Run Like Hell (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 263,
                                       Rank = 22
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Waiting For The Worms (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 238,
                                       Rank = 23
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Stop (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 30,
                                       Rank = 24
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Trial (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 320,
                                       Rank = 25
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Outside The Wall (1994 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "The Wall"),
                                       Duration = 103,
                                       Rank = 26
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No One Loves Me & Neither Do I",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 309,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mind Eraser, No Chaser",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 245,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "New Fang",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 227,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dead End Friends",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 194,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Elephants",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 408,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Scumbag Blues",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 264,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bandoliers",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 340,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Reptiles",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 254,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Interlude With Ludes",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 223,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Warsaw or the First Breath You Take After You Give Up",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 468,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Caligulove",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 294,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gunman",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 284,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Spinning in Daffodils",
                                       Album = albums.Single(a => a.Title == "Them Crooked Vultures"),
                                       Duration = 446,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dance Yrself Clean",
                                       Album = albums.Single(a => a.Title == "This Is Happening"),
                                       Duration = 534,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Drunk Girls",
                                       Album = albums.Single(a => a.Title == "This Is Happening"),
                                       Duration = 218,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "One Touch",
                                       Album = albums.Single(a => a.Title == "This Is Happening"),
                                       Duration = 463,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All I Want",
                                       Album = albums.Single(a => a.Title == "This Is Happening"),
                                       Duration = 399,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Can Change",
                                       Album = albums.Single(a => a.Title == "This Is Happening"),
                                       Duration = 350,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Wanted a Hit",
                                       Album = albums.Single(a => a.Title == "This Is Happening"),
                                       Duration = 544,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pow Pow",
                                       Album = albums.Single(a => a.Title == "This Is Happening"),
                                       Duration = 501,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Somebody's Calling Me",
                                       Album = albums.Single(a => a.Title == "This Is Happening"),
                                       Duration = 411,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Home",
                                       Album = albums.Single(a => a.Title == "This Is Happening"),
                                       Duration = 471,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Panther Dash",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 169,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ladyflash",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 276,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Feelgood By Numbers",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 114,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Power Is On",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 193,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Get It Together",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 206,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "We Just Won't Be Defeated",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 164,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Junior Kickstart",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 257,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everyone´s A V.I.P To Someone",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 297,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Air Raid GTR",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 39,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bottle Rocket",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 247,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Friendship Update",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 238,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hold Yr Terror Close",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 136,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Huddle Formation",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 178,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Everyone's A VIP To Someone",
                                       Album = albums.Single(a => a.Title == "Thunder, Lightning, Strike"),
                                       Duration = 167,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Time To Say Goodbye (Con Te Partiro)",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 246,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No One Like You",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 284,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Just Show Me How To Love You",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 238,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tu Quieres Volver",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 229,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In Pace",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 186,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "There For Me",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 212,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bilitis-Generique",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 204,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Who Wants To Live Forever",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 234,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "La Wally",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 242,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Naturaleza Muerta",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 324,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "En Aranjuez Con Tu Amor",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 230,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In Trutina",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 150,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "O Mio Babbino Caro",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 160,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Alleluja",
                                       Album = albums.Single(a => a.Title == "Time to Say Goodbye"),
                                       Duration = 190,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hands Tied",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 187,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "New York Minute",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 216,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Out Of My Head",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 216,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Montreal Calling",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 255,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "See Right Through Me",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 247,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Looking Out",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 196,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Scars",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 195,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dusting Down The Stars",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 234,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tomorrow Starts Today",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 186,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "How Can I Be Saved",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 196,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Lovedrug",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 252,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bleeding Words",
                                       Album = albums.Single(a => a.Title == "Tomorrow Starts Today"),
                                       Duration = 378,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Run, Baby, Run",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 293,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Leaving Las Vegas",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 311,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Strong Enough",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 191,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Can't Cry Anymore",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 222,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Solidify",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 249,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Na-Na Song",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 193,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "No One Said It Would Be Easy",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 330,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "What I Can Do For You",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 254,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "All I Wanna Do",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 284,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "We Do What We Can",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 340,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Shall Believe",
                                       Album = albums.Single(a => a.Title == "Tuesday Night Music Club"),
                                       Duration = 334,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Binnenstebuiten (Yele)",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 365,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mens",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 235,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Aanzoek zonder ringen",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 224,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hemingway",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 220,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wennen Aan September",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 258,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Geen Tango",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 279,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Laag Bij De Grond",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 263,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Herinnering Aan Later",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 201,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Vreemde Wegen",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 256,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Donker Hart",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 249,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Een Manier Om Thuis Te Komen",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 312,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "De Hemel Is De Aarde",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 273,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Eén En Alleen",
                                       Album = albums.Single(a => a.Title == "Umoja"),
                                       Duration = 419,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pretty Good Year (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 205,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "God (LP version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 238,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bells For Her (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 320,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Past the Mission (LP version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 245,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Baker Baker (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 198,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Wrong Band  (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 182,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Waitress  (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 189,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cornflake Girl (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 306,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Icicle (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 345,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cloud On My Tongue (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 282,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Space Dog (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 311,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Yes, Anastasia  (LP Version)",
                                       Album = albums.Single(a => a.Title == "Under the Pink"),
                                       Duration = 570,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Intolerance",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 293,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Prison Sex",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 296,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sober",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 306,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bottom",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 434,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crawl Away",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 330,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Swamp Song",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 332,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Undertow",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 322,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "4°",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 363,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Flood",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 466,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Disgustipated",
                                       Album = albums.Single(a => a.Title == "Undertow"),
                                       Duration = 947,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Untitled",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 50,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Archangel",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 241,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Near Dark",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 237,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ghost Hardware",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 295,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Endorphin",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 180,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Etched Headplate",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 362,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In McDonalds",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 130,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Untrue",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 379,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shell of Light",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 283,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dog Shelter",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 182,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Homeless",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 323,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "UK",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 103,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Raver",
                                       Album = albums.Single(a => a.Title == "Untrue"),
                                       Duration = 298,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Right Next Door To Hell (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 182,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dust N' Bones (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 298,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Live and Let Die",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 196,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Cry",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 284,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Perfect Crime (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 143,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Ain't The First",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 156,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bad Obsession (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 328,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Back Off Bitch (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 303,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Double Talkin' Jive (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 203,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "November Rain",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 538,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Garden",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 323,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Garden Of Eden (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 161,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Damn Me",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 318,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bad Apples (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 268,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dead Horse",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 258,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Coma (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion I"),
                                       Duration = 616,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Civil War",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 463,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "14 Years",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 262,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Yesterdays",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 196,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Knockin' On Heaven's Door",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 336,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Get In The Ring (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 342,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shotgun Blues (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 203,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Breakdown",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 425,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name =
                                           "Pretty Tied Up (The Perils Of Rock N' Roll Decadence) (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 288,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Locomotive (Complicity)",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 523,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "So Fine",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 246,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Estranged",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 565,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Could Be Mine",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 344,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Don't Cry (Album Version (Alternate Lyrics))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 284,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My World (Album Version (Explicit))",
                                       Album = albums.Single(a => a.Title == "Use Your Illusion II"),
                                       Duration = 86,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Temptation Waits",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 276,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Think I'm Paranoid",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 217,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "When I Grow Up",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 201,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Medication",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 249,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Special",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 216,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hammering in My Head",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 291,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Push It",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 243,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Trick Is To Keep Breathing",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 252,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dumb",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 230,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sleep Together",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 243,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wicked Ways",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 222,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "You Look So Fine",
                                       Album = albums.Single(a => a.Title == "Version 2.0"),
                                       Duration = 323,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mungu",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 67,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Yoka",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 189,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shadow Dancer",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 211,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wapi Yo",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 182,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ping Pongo",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 7,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Salle",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 219,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Just To Say I Love You",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 196,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Liteya",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 171,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "C'Est Ma Terre",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 162,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Anata O",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 188,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Molili",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 197,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kumba Ngai",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 154,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Reunion",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 188,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Life",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 172,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shadow Dancer (Version Française)",
                                       Album = albums.Single(a => a.Title == "Wapi Yo"),
                                       Duration = 212,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "This Blackout Is Your Apocalypse",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 139,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Somewhere Along The Road",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 251,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Bash",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 280,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Warriors",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 253,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Straight To Hell",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 219,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Welcome The Storm",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 256,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wasteland Discotheque",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 258,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Somebody's Watching Me",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 234,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "A Heavy Burden",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 287,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "To The Lighthouse",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 314,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Showdown Recovery",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 264,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Comfort In Leaving",
                                       Album = albums.Single(a => a.Title == "Wasteland Discotheque"),
                                       Duration = 477,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Watermark",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 145,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cursum Perficio",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 248,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "On Your Shore",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 239,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Storms In Africa",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 243,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Exile",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 260,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Miss Clare Remembers",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 119,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Orinoco Flow",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 265,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Evening Falls..",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 228,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "River",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 191,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Longships",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 218,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Na Laetha Geal M'oige",
                                       Album = albums.Single(a => a.Title == "Watermark"),
                                       Duration = 235,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Mountainhead",
                                       Album = albums.Single(a => a.Title == "We Were Exploding Anyway"),
                                       Duration = 333,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crash Tactics",
                                       Album = albums.Single(a => a.Title == "We Were Exploding Anyway"),
                                       Duration = 227,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Dance Dance Dance",
                                       Album = albums.Single(a => a.Title == "We Were Exploding Anyway"),
                                       Duration = 241,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Piano Fights",
                                       Album = albums.Single(a => a.Title == "We Were Exploding Anyway"),
                                       Duration = 230,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Weak4",
                                       Album = albums.Single(a => a.Title == "We Were Exploding Anyway"),
                                       Duration = 234,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Come To Me",
                                       Album = albums.Single(a => a.Title == "We Were Exploding Anyway"),
                                       Duration = 480,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Go Complex",
                                       Album = albums.Single(a => a.Title == "We Were Exploding Anyway"),
                                       Duration = 244,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Debutante",
                                       Album = albums.Single(a => a.Title == "We Were Exploding Anyway"),
                                       Duration = 441,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tiger Girl",
                                       Album = albums.Single(a => a.Title == "We Were Exploding Anyway"),
                                       Duration = 637,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Back To School (Mini Maggit) (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 236,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Feiticeira (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 189,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Digital Bath (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 254,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Elite (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 240,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Rx Queen (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 266,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Street Carp (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 161,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Teenager (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 199,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Knife Prty (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 288,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Korea (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 202,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Passenger (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 367,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Change (In The House Of Flies) (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 297,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pink Maggit (LP Version)",
                                       Album = albums.Single(a => a.Title == "White Pony"),
                                       Duration = 453,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Baba O'Riley (Remixed Version)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 309,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bargain",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 336,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Love Ain't For Keeping (Original Album Version)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 131,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "My Wife (Original Album Version)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 214,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Song Is Over (Original Album Version)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 377,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Getting In Tune (Original Album Version)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 289,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Going Mobile (Original Album Version)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 222,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Behind Blue Eyes (Original Album Version)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 221,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Won't Get Fooled Again (remix)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 514,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pure and Easy",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 262,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Baby Don't You Do It",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 149,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Naked Eye",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 392,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Water (The Young Vic Theatre Live Version)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 386,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Too Much of Anything",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 265,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I Don't Even Know Myself",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 376,
                                       Rank = 15
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Behind Blue Eyes (Alternate Studio Version)",
                                       Album = albums.Single(a => a.Title == "Who's Next"),
                                       Duration = 208,
                                       Rank = 16
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shine On You Crazy Diamond (Part One) (1-5) (1992 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Wish You Were Here"),
                                       Duration = 807,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Welcome To The Machine (1992 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Wish You Were Here"),
                                       Duration = 445,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Have A Cigar (1992 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Wish You Were Here"),
                                       Duration = 306,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Wish You Were Here (1992 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Wish You Were Here"),
                                       Duration = 339,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Shine On You Crazy Diamond (Part Two) (6-9) (1992 Digital Remaster)",
                                       Album = albums.Single(a => a.Title == "Wish You Were Here"),
                                       Duration = 740,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Valhall Awaits Me",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 282,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Runes to My Memory",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 271,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Asator",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 183,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hermod's Ride To Hel  Lokes Treachery Part 1",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 279,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hermod's Ride To Hel - Lokes Treachery Part 1",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 279,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Gods of War Arise",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 361,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "With Oden on Our Side",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 273,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Cry of the Black Birds",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 228,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Under The Northern Star",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 256,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Prediction of Warfare",
                                       Album = albums.Single(a => a.Title == "With Oden on Our Side"),
                                       Duration = 397,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Worship (Intro)",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 100,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Earth on Hell",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 190,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Devil You Know",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 286,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fight 'Em Til You Can't",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 349,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "I'm Alive",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 336,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hymn 1",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 38,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "In the End",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 408,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Giant",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 227,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Hymn 2",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 44,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Judas Priest",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 384,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Crawl",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 329,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "The Constant",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 301,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Revolution Screams",
                                       Album = albums.Single(a => a.Title == "Worship Music"),
                                       Duration = 954,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Quando Dás Um Pouco Mais",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 282,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Sumanai",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 267,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ponte de Luz",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 265,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Caminhanti",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 43,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Pé Na Strada",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 253,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Di Alma",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 271,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Bué (Você é...)",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 253,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Keda Livre",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 178,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Só d'Imagina",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 257,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Minino",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 204,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Voz Di Vento",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 251,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Exala",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 206,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Fundi Ku Mi",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 322,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Manso Manso (Hidden Track - Mana Fe After 1 Min. of Silence)",
                                       Album = albums.Single(a => a.Title == "Xinti"),
                                       Duration = 600,
                                       Rank = 14
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kumusta na",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 211,
                                       Rank = 1
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Tsinelas",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 166,
                                       Rank = 2
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "State u",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 170,
                                       Rank = 3
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Banal Na Aso Santong Kabayo",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 269,
                                       Rank = 4
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Trapo",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 204,
                                       Rank = 5
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Iskolar ng bayan",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 180,
                                       Rank = 6
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Kaka",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 125,
                                       Rank = 7
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Esem",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 221,
                                       Rank = 8
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "McJo",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 174,
                                       Rank = 9
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Coño ka P're",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 143,
                                       Rank = 10
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Senti",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 288,
                                       Rank = 11
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Naroon",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 198,
                                       Rank = 12
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Ate",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 184,
                                       Rank = 13
                                   });
            context.Tracks.Add(new Track
                                   {
                                       Name = "Travel Times",
                                       Album = albums.Single(a => a.Title == "Yano"),
                                       Duration = 286,
                                       Rank = 14
                                   });

            context.SaveChanges();
        }

        private static void AddOrders(DashboardEntities context)
        {
            var now = DateTime.Now;
            for (var day = now - TimeSpan.FromDays(366); day < now; day += TimeSpan.FromDays(1))
            {
                AddOrdersForDay(context, day);
            }
        }
        private static void AddOrdersForDay(DashboardEntities context, DateTime day)
        {
            var ordersToMake = Random.Next(3, 7);
            for (int i = 0; i < ordersToMake; i++)
            {
                AddFakeOrder(context, day);
            }
            context.SaveChanges();
        }
        private static void AddFakeOrder(DashboardEntities context, DateTime day)
        {
            var order = FakeO.Create.Fake<Order>(x => x.Address = FakeO.Address.StreetAddress(),
                x => x.City = FakeO.Address.City(),
                x => x.Country = "US",
                x => x.Email = FakeO.Internet.Email(),
                x => x.FirstName = FakeO.Name.First(),
                x => x.LastName = FakeO.Name.Last(),
                x => x.OrderDate = day + TimeSpan.FromHours(Random.NextDouble() * 23),
                x => x.Phone = FakeO.Phone.Number(),
                x => x.PostalCode = FakeO.Address.ZipCode(),
                x => x.State = FakeO.Address.UsStateAbbr(),
                x => x.Username = "foo",
                x => x.OrderDetails = null);
            context.Orders.Add(order);
            var details = AddFakeOrderDetails(context, order);
            order.Total = details.Sum(x => x.UnitPrice * x.Quantity);
        }
        private static List<OrderDetail> AddFakeOrderDetails(DashboardEntities context, Order order)
        {
            var albumsInOrder = Random.Next(1, 2);
            var details = FakeO.Create.Fake<OrderDetail>(albumsInOrder,
                x => x.AlbumId = FakeO.Number.Next(1, 200),
                x => x.OrderId = order.OrderId,
                x => x.Quantity = 1,
                x => x.UnitPrice = Price()).ToList();
            details.ForEach(x => context.OrderDetails.Add(x));
            return details;
        }
    }
}