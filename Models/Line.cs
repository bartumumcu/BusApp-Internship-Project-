namespace BusApp.Models
{
    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int length { get; set; }
        public List<Bus> busses { get; set; } = new List<Bus>();
    }
}
