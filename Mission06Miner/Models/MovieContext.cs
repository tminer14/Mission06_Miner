//using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Mission06Miner.Models
{
    public class MovieContext : DbContext
    {
        //create constructor for the movie
        public MovieContext(DbContextOptions<MovieContext> options) //constructor
            : base(options)
        { 
        }
            public DbSet<Movie> Movies { get; set; }
    }
}
