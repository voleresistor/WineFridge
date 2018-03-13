namespace WineFridge.Models
{
    public class Winery
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }

        public Winery() { }

        public Winery(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
