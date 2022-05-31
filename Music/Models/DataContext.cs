using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music.Models;

namespace Music.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        { }

        public DbSet<ArtistModel> Artists { get; set; }

        public DbSet<ArtistSongModel> ArtistSong { get; set; }

        public DbSet<Music.Models.SongModel> SongModel { get; set; }
    }
}
