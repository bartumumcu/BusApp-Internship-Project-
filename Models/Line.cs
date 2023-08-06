namespace BusApp.Models
{
    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int length { get; set; }
        public virtual ICollection<Bus> busses { get; set; }
    }
}
