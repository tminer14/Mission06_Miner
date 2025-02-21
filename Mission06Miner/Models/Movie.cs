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
        public int? CategoryId { get; set; }//set as foreign key
        public Category? Category { get; set; } //allows me to access related category object

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } 

        //set required range for years
        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 2025)]
        public int Year { get; set; }

        public string? Director { get; set; }

        
        public string? Rating { get; set; }


        [Required(ErrorMessage = "Edited is required.")]
        public bool Edited { get; set; }


        public string? LentTo { get; set; }


        [Required(ErrorMessage = "Copied to plex is required.")]
        public bool CopiedToPlex { get; set; }


        [StringLength(25, ErrorMessage = "Notes cannot be more than 25 characters.")]
        public string? Notes { get; set; }


    }
}
