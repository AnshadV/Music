using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Models
{
    public class ArtistSongModel
    {
        [Key]
        public int ArtistSongId { get; set; }


        [ForeignKey("SongModel")]
        [Column(TypeName = "int")]
        public int SongId { get; set; }

        [ForeignKey("ArtistModel")]
        [Column(TypeName = "int")]
        public int ArtistId { get; set; }

        public SongModel SongModel { get; set; }

        public ArtistModel ArtistModel { get; set; }


    }
}
