using System.ComponentModel.DataAnnotations;

namespace DotNetCoreMVCDemo.DomainLayer.Entity
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
}
