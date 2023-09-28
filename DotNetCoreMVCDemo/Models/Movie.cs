using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreMVCDemo.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string? MovieName { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
        public  ICollection<Tickets>? Tickets { get; set; }

    }

    public class Tickets
    {
        public Guid Id { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? ShowDate { get; set; }
        public Gender? Gender { get; set; }
        public decimal? Amount { get; set; }

        public Guid? MovieId { get; set; }
        public  Movie? Movie { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female=2
    }
}
