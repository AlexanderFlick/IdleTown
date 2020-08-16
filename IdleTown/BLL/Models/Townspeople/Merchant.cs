namespace BLL.Models.Market
{
    public class Merchant : BasicWorker
    {
        public int WheatMultiplier { get; set; }
        public int StoneMultiplier { get; set; }
        public int WheatPrice { get; set; }
        public int StonePrice { get; set; }

        public int WheatQuantitySold { get; set; } = 1;
        public int StoneQuantitySold { get; set; } = 1;
    }
}