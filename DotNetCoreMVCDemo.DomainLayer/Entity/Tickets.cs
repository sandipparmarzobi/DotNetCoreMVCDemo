namespace DotNetCoreMVCDemo.DomainLayer.Entity
{
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
}
