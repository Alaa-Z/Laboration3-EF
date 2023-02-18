using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testEntity.Models
{
	public class User
	{
        // Propreties
        // Primary key
		public int Id { get; set; }

        [Required]
        public string? Name {get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [NotMapped]
        public virtual ICollection<UserCd>? UserCd { get; set; }

    }
}

