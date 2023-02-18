using System;
using System.ComponentModel.DataAnnotations;


namespace testEntity.Models

{
	public class Artist
	{
        //Propreties 
        // Primary key
        public int Id { get; set; }
        
		[Required]
        [Display (Name="Name of the artist")]
        public string? Name { get; set; }

        public List<Cd>? Cd { get; set; }
    }
}

