namespace DotNetCoreMVCDemo.Services
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
    public class Services : IDateTime
    {
        public DateTime Now
        {
            get {  return DateTime.Now; }    
        }
    }
}
