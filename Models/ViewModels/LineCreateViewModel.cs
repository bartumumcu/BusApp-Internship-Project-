using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusApp.Models.ViewModels
{
    public class LineCreateViewModel
    {
        public Line Line { get; set; }
        public List<Bus> Buses { get; set; } 
        public List<Driver> Drivers { get; set; }   
        public List<Line> Lines { get; set; }
        public Driver Driver { get; set; }
        public Bus Bus { get; set; }
        public Trip Trip { get; set; }
    }
}
