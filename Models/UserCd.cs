using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace testEntity.Models
{
    [PrimaryKey(nameof(CdId), nameof(UserId))]
    public class UserCd
	{
        // Propreties
        [Display(Name = "Who are you?")]
        public int UserId { get; set; }

        [Display(Name = "Select CD to Borrow")]
        public int CdId { get; set; }


        public virtual Cd? Cd { get; set; }
        public virtual User? User { get; set; }


        public DateTime BorrowingDate { get; set; } = DateTime.Now;




    }
}

