using BusApp.Data;
using System.Text.Json.Serialization;

namespace BusApp.Models
{
    public class Trip
    {
        public int Id { get; set; }

        
        public DateTime STime { get; set; }
        public DateTime ETime { get; set; }
        public Driver Driver { get; set; }
        public Bus Bus { get; set; }
        public Line Line { get; set; }

        //Functions
        public void calcProfit()
        {
            var context = new ApplicationDbContext(); 
            int pro = (this.ETime - this.STime).Hours * 100;
            this.Driver.addMoney(pro);            
        }
    }
}
