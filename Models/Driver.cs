namespace BusApp.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int Money { get; set; } = 0;

        public Driver() { }

        public Driver(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public void addMoney(int profit)
        {
            this.Money += profit;
        }

    }
}
