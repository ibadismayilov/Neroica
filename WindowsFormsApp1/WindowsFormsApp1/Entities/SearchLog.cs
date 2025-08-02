using System;
using System.ComponentModel.DataAnnotations;
using WindowsFormsApp1.Entities.Auth;
using WindowsFormsApp1.Entities.Common;

namespace WindowsFormsApp1.Entities
{
    public class SearchLog : BaseEntity
    {
        public Guid UserId { get; set; }

        public RegisterEntity User { get; set; }

        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; }

        [StringLength(255)]
        public string SearchQueryTitle { get; set; }

        public DateTime SearchDate { get; set; } = DateTime.Now;
    }
}
