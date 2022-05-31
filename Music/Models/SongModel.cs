using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Models
{
    public class SongModel
    {
        [Key]
        public int SongId { get; set; }
        
        [DisplayName("Song Name")]
        [Column(TypeName = "nvarchar(50)")]
        public String SongName { get; set; }

        [DisplayName("Release Date")]
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Cover Image")]
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] CoverImage { get; set; }

        [Column(TypeName = "int")]
        public int Rating { get; set; }

        [ForeignKey("ArtistModel")]
        public int ArtistId { get; set; }

        [NotMapped]
        public IEnumerable<ArtistModel> ArtistCollection { get; set; }

        public ArtistModel ArtistModel { get; set; }

    }

   
}
