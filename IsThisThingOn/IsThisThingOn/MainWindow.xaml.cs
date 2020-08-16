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
        private Farmer farmers = new Farmer();
        private Storage storage = new Storage();
        private Stone stones = new Stone();
        private Miner miner = new Miner();
        private Warehouse warehouse = new Warehouse();

        private readonly IWheatService wheat;
        private readonly ITimerService timer;
        private readonly IStoneService stone;
        private readonly IFarmerService farmer;

        public MainWindow(IWheatService wheat, ITimerService timer, IStoneService stone, IFarmerService farmer)
        {
            this.wheat = wheat;
            this.timer = timer;
            this.stone = stone;
            this.farmer = farmer;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(farmers.HarvestRate);
            dt.Tick += HarvestTicker;
            dt.Start();
        }

        private void HarvestTicker(object sender, EventArgs e)
        {
            farmer.Harvest(farmers, wheats);
            stone.Harvest(miner, stones);
            UpdateWheatText();
            UpdateStoneText();
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
            farmer.Hire(person, farmers);
            UpdateWheatText();
        }

        private void BuyStorage(object sender, RoutedEventArgs e)
        {
            wheat.BuyStorage(person, storage, wheats);
            UpdateWheatText();
        }

        private void BuyWheatMarket(object sender, RoutedEventArgs e)
        {
            wheat.BuyMarket(person, market, wheats);
            UpdateWheatText();
        }

        private void UpdateWheatText()
        {
            goldText.Text = "Total Gold: " + person.Gold.ToString();
            wheatText.Text = "Wheat: " + wheats.Total.ToString() + "/" + wheats.Max.ToString();
            wheatPerClick.Text = "Wheat Per Click: " + wheats.PerClick;
            farmerGain.Text = "+" + farmers.TotalHarvest + " Wheat/sec";
            farmerCost.Text = "Gold To Hire Farmer: " + farmers.Cost;
            storageTotal.Text = "Total Warehouses: " + storage.Total;
            storageIncrease.Text = "+" + storage.IncreaseWheatMax + " Max Wheat";
            storageCost.Text = "Storage Gold Cost: " + storage.Cost;
        }

        private void GetStone(object sender, RoutedEventArgs e)
        {
            stone.Gain(stones);
            UpdateStoneText();
        }

        private void SellStone(object sender, RoutedEventArgs e)
        {
            stone.Sell(person, stones);
            UpdateStoneText();
        }

        private void HireMiner(object sender, RoutedEventArgs e)
        {
            stone.HireMiner(person, miner);
            UpdateStoneText();
        }

        private void BuyWarehouse(object sender, RoutedEventArgs e)
        {
            stone.BuyWarehouse(person, warehouse, stones);
            UpdateStoneText();
        }

        private void UpdateStoneText()
        {
            goldText.Text = "Total Gold: " + person.Gold;
            stoneText.Text = "Stone: " + stones.Total + "/" + stones.Max;
            stonePerClick.Text = "Stone Per Click: " + stones.PerClick;
            minerGain.Text = "+" + miner.TotalHarvest + " Stone/sec";
            minerCost.Text = "Gold To Hire Miner: " + miner.Cost;
            warehouseCost.Text = "Warehouse Gold Cost: " + market.Cost;
            warehouseTotal.Text = "Total Warehouses: " + market.Total;
            warehouseIncrease.Text = "+" + stones.Price + " Max Wheat";
        }

        private void UpdateMarketText()
        {
            stoneMarketPrices.Text = "Stone Price: " + stones.Price;
            wheatMarketPrices.Text = "Wheat Price: " + wheats.Price;
        }
    }
}
