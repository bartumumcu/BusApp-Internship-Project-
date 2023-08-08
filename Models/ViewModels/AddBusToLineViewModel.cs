using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusApp.Models.ViewModels
{
    public class AddBusToLineViewModel
    {
        public int LineId { get; set; }
        public List<Line> Lines { get; set; }
        public int BusId { get; set; }
        public List<Bus> Buses { get; set; } = new List<Bus>();

        public AddBusToLineViewModel() { }
    }
}
