using BLL.Models;
using BLL.Services;
using System;
using System.Windows;
using System.Windows.Threading;

namespace IsThisThingOn
{
    public partial class MainWindow : Window
    {
        private Person person = new Person();
        private Wheat wheats = new Wheat();
        private Markets market = new Markets();
        private Farmer farmer = new Farmer();
        private Storage storage = new Storage();
        private Stone stones = new Stone();
        private Miner miner = new Miner();
        private Warehouse warehouse = new Warehouse();

        private readonly IWheatService wheat;
        private readonly ITimerService timer;
        private readonly IStoneService stone;

        public MainWindow(IWheatService wheat, ITimerService timer, IStoneService stone)
        {
            this.wheat = wheat;
            this.timer = timer;
            this.stone = stone;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(farmer.HarvestRate);
            dt.Tick += farmerTicker;
            dt.Start();
        }

        private void farmerTicker(object sender, EventArgs e)
        {
            wheat.Harvest(farmer, wheats);
            UpdateWheatText();
        }

        private void GetWheat(object sender, RoutedEventArgs e)
        {
            wheat.Gain(wheats);
            UpdateWheatText();
        }

        private void SellWheat(object sender, RoutedEventArgs e)
        {
            wheat.Sell(person, wheats);
            UpdateWheatText();
        }

        private void HireFarmer(object sender, RoutedEventArgs e)
        {
            wheat.HireFarmer(person, farmer, wheats);
            UpdateWheatText();
        }

        private void BuyStorage(object sender, RoutedEventArgs e)
        {
            wheat.BuyStorage(person, storage, wheats);
            UpdateWheatText();
        }

        private void BuyMarket(object sender, RoutedEventArgs e)
        {
            wheat.BuyMarket(person, market, wheats);
            UpdateWheatText();
        }

        private void UpdateWheatText()
        {
            goldText.Text = "Total Gold: " + person.Gold.ToString();
            wheatText.Text = "Wheat: " + wheats.Total.ToString() + "/" + wheats.Max.ToString();
            wheatPrices.Text = "Price: $" + wheats.Price;
            wheatPerClick.Text = "Wheat Per Click: " + wheats.PerClick;
            totalFarmer.Text = "Total Farmers: " + farmer.Total;
            farmerGain.Text = "+" + farmer.TotalHarvest + " Wheat/sec";
            farmerCost.Text = "Gold To Hire Farmer: " + farmer.Cost;
            storageTotal.Text = "Total Warehouses: " + storage.Total;
            storageIncrease.Text = "+" + storage.IncreaseWheatMax + " Max Wheat";
            storageCost.Text = "Storage Gold Cost: " + storage.Cost;
            marketCost.Text = "Gold To Buy Market: " + market.Cost;
            marketTotal.Text = "Total Markets: " + market.Total;
            marketIncrease.Text = "x" + wheats.Price + " Per Sale";
        }


        private void GetStone(object sender, RoutedEventArgs e)
        {
            stone.Gain(stones);
            UpdateStoneText();
        }
        private void UpdateStoneText()
        {
            stoneText.Text = "Stone: " + stones.Total + "/" + stones.Max;
            stonePrices.Text = "Price: $" + stones.Price;
            stonePerClick.Text = "Stone Per Click: " + stones.PerClick;
            totalMiner.Text = "Total Miners: " + miner.Total;
            minerGain.Text = "+" + miner.TotalHarvest + " Stone/sec";
            minerCost.Text = "Gold To Hire Miner: " + miner.Cost;
            warehouseTotal.Text = "Total Warehouses: " + warehouse.Total;
            warehouseIncrease.Text = "+" + warehouse.IncreaseStoneMax + " Max Stone";
            warehouseCost.Text = "Storage Gold Cost: " + warehouse.Cost;
            marketerCost.Text = "Gold To Buy Market: " + market.Cost;
            marketerTotal.Text = "Total Markets: " + market.Total;
            marketerIncrease.Text = "x" + stones.Price + " Per Sale";
        }
    }
}