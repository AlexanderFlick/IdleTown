namespace BLL.Models
{
    public class BasicWorker
    {
        public int Cost { get; set; } = 4;
        public int TotalHarvest { get; set; }
        public int PerClick { get; set; } = 1;
        public int IncreaseWithPurchase { get; set; } = 10;
        public int HarvestRate { get; set; } = 1;
        public bool Active { get; set; } = false;
    }
}