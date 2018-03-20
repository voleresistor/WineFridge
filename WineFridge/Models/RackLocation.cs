namespace WineFridge.Models
{
    public class RackLocation
    {
        public int WineID { get; set; }
        public Wine Wine { get; set; }

        public int RackID { get; set; }
        public RackLocation Location { get; set; }
    }
}
