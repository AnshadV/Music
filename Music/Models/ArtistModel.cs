using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Models
{
    public class ArtistModel
    {
        [Key]
        public int ArtistId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Bio { get; set; }

        public ICollection<SongModel> Songs { get; set; }

    }
}
