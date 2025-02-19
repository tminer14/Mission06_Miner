using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06Miner.Models
{
    public class Movie
    {
        //create get set properties from the movie, using error messages and other parameters
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public required string Title { get; set; }


        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        
        public string? Rating { get; set; }

        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Copied to plex is required.")]
        public bool CopiedToPlex { get; set; }


        [StringLength(25, ErrorMessage = "Notes cannot be more than 25 characters.")]
        public string? Notes { get; set; }


    }
}
