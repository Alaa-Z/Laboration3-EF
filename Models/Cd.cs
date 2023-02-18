using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testEntity.Models
{
    public class Cd
    {
        //Propreties
        // Primary key
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public Artist? Artist { get; set; }

        [Display(Name = "Select en Artist")]
        public int ArtistId { get; set; }

        [NotMapped]
        public virtual ICollection<UserCd>? UserCd { get; set; }


    }
}

