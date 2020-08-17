namespace BLL.Models.Market
{
    public class Merchant : BasicWorker
    {
        public int WheatMultiplier { get; set; }
        public int StoneMultiplier { get; set; }
        public int WheatPrice { get; set; } = 2;
        public int StonePrice { get; set; } = 7;

        public int WheatQuantitySold { get; set; } = 1;
        public int StoneQuantitySold { get; set; } = 1;
    }
}