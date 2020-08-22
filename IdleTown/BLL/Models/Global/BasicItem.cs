namespace BLL.Models.Global
{
    public class BasicItem
    {
        public int HarvestIncrease { get; set; } = 1;
        public int WheatCost { get; set; } = 1;
        public int StoneCost { get; set; } = 2;
        public int GoldCost { get; set; } = 4;
        public bool Active = false;
        public int UpgradeStatus { get; set; } = 0;
    }
}