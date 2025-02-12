using System.ComponentModel.DataAnnotations;

namespace Mission06Miner.Models
{
    public class Movie
    {
        //create get set properties from the movie, using error messages and other parameters
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public string Rating { get; set; }

       
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot be more than 25 characters.")]
        public string? Notes { get; set; }


    }
}
