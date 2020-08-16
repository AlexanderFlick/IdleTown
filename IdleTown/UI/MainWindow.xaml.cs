using BLL.Models;
using BLL.Models.Market;
using BLL.Services;
using BLL.Services.WorkerServices;
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
        private Miner miners = new Miner();
        private Warehouse warehouse = new Warehouse();
        private Merchant merchants = new Merchant();

        private readonly IWheatService wheat;
        private readonly ITimerService timer;
        private readonly IStoneService stone;
        private readonly IFarmerService farmer;
        private readonly IMinerService miner;
        private readonly IMerchantService merchant;

        public MainWindow(IWheatService wheat, ITimerService timer, IStoneService stone, IFarmerService farmer, IMinerService miner, IMerchantService merchant)
        {
            this.wheat = wheat;
            this.timer = timer;
            this.stone = stone;
            this.farmer = farmer;
            this.miner = miner;
            this.merchant = merchant;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1000);
            dt.Tick += HarvestTicker;
            dt.Start();
        }

        private void HarvestTicker(object sender, EventArgs e)
        {
            farmer.Harvest(farmers, wheats);
            miner.Harvest(miners, stones);
            UpdateWheatText();
            UpdateStoneText();
            UpdateMarketText();
        }

        private void BuyWarehouse(object sender, RoutedEventArgs e)
        {
            stone.BuyWarehouse(person, warehouse, stones);
            UpdateStoneText();
        }

        private void UpdateMarketText()
        {
            stoneMarketPrices.Text = "Stone Price: " + merchants.StonePrice;
            wheatMarketPrices.Text = "Wheat Price: " + merchants.WheatPrice;
        }

        private void UpdateTownspeopleText()
        {
            merchantWheatCost.Text = "Wheat to Hire Merchant: " + merchants.WheatPrice;
        }

        #region Townspeople

        private void HireMerchant(object sender, RoutedEventArgs e)
        {
            merchant.Hire(person, merchants);
            UpdateWheatText();
        }

        private void HireFarmer(object sender, RoutedEventArgs e)
        {
            farmer.Hire(person, farmers);
            UpdateWheatText();
        }

        private void HireMiner(object sender, RoutedEventArgs e)
        {
            miner.Hire(person, miners, wheats);
            UpdateStoneText();
        }

        #endregion Townspeople

        #region MerchantFeatures

        private void SellStone(object sender, RoutedEventArgs e)
        {
            merchant.SellStone(person, merchants, stones);
            UpdateStoneText();
        }

        private void SellWheat(object sender, RoutedEventArgs e)
        {
            merchant.SellWheat(person, merchants, wheats);
            UpdateWheatText();
        }

        #endregion MerchantFeatures

        #region Wheat

        private void GetWheat(object sender, RoutedEventArgs e)
        {
            wheat.Gain(wheats);
            UpdateWheatText();
        }

        private void BuyStorage(object sender, RoutedEventArgs e)
        {
            wheat.BuyStorage(person, storage, wheats);
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

        #endregion Wheat

        #region Stone

        private void GetStone(object sender, RoutedEventArgs e)
        {
            stone.Gain(stones);
            UpdateStoneText();
        }

        private void UpdateStoneText()
        {
            goldText.Text = "Total Gold: " + person.Gold;
            stoneText.Text = "Stone: " + stones.Total + "/" + stones.Max;
            stonePerClick.Text = "Stone Per Click: " + stones.PerClick;
            minerGain.Text = "+" + miners.TotalHarvest + " Stone/sec";
            minerCost.Text = "Gold To Hire Miner: " + miners.Cost;
            warehouseCost.Text = "Warehouse Gold Cost: " + market.Cost;
            warehouseTotal.Text = "Total Warehouses: " + market.Total;
            //warehouseIncrease.Text = "+" + stones.Price + " Max Wheat";
        }

        #endregion Stone
    }
}