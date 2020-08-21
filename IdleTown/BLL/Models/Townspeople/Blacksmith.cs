namespace BLL.Models.Townspeople
{
    public class Blacksmith : BasicWorker
    {
        public int WheatCost { get; set; } = 6;
        public int StoneCost { get; set; } = 5;
    }
}