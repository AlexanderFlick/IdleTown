using BLL.Models;
using BLL.Models.Market;
using BLL.Models.Resources;
using BLL.Models.Townspeople;
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
        private Pickaxe pickaxes = new Pickaxe();
        private Sickle sickles = new Sickle();
        private Markets market = new Markets();
        private Farmer farmers = new Farmer();
        private Storage storage = new Storage();
        private Stone stones = new Stone();
        private Miner miners = new Miner();
        private Warehouse warehouse = new Warehouse();
        private Merchant merchants = new Merchant();
        private Blacksmith blacksmiths = new Blacksmith();

        private readonly IWheatService wheat;
        private readonly ITimerService timer;
        private readonly IStoneService stone;
        private readonly IFarmerService farmer;
        private readonly IMinerService miner;
        private readonly IMerchantService merchant;
        private readonly IBlackSmithService blacksmith;
        private readonly string filler = "";
        private readonly string purchased = "Purchased!";

        public MainWindow(IWheatService wheat, ITimerService timer, IStoneService stone, IFarmerService farmer, IMinerService miner, IMerchantService merchant, IBlackSmithService blacksmith)
        {
            this.wheat = wheat;
            this.timer = timer;
            this.stone = stone;
            this.farmer = farmer;
            this.miner = miner;
            this.merchant = merchant;
            this.blacksmith = blacksmith;
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
            farmer.Harvest(farmers, wheats, sickles);
            miner.Harvest(miners, stones, pickaxes);
            UpdateWheatText();
            UpdateStoneText();
            UpdateMarketText();
            UpdateTownsPeopleText();
        }

        private void BuyWarehouse(object sender, RoutedEventArgs e)
        {
            stone.BuyWarehouse(person, warehouse, stones);
            UpdateStoneText();
        }

        private void UpdateTownsPeopleText()
        {
            farmerCost.Text = "Gold to Hire Farmer: " + farmers.Cost;
            minerCost.Text = "Gold to Hire Miner: " + miners.Cost;
            minerWheatCost.Text = "Wheat to Hire Miner: " + miners.WheatCost;
            merchantWheatCost.Text = "Wheat to Hire Merchant: " + merchants.WheatPrice;
            BlacksmithGoldCost.Text = "Gold to Hire Blacksmith: " + blacksmiths.Cost;
            BlacksmithStoneCost.Text = "Stone to Hire Blacksmith: " + blacksmiths.StoneCost;
            BlacksmithWheatCost.Text = "Wheat to Hire Blacksmith: " + blacksmiths.WheatCost;
            sickleGoldCost.Text = "Gold to Upgrade Sickle: " + sickles.GoldCost;
            sickleStoneCost.Text = "Stone to Upgrade Sickle: " + sickles.StoneCost;
            sickleQuality.Text = "Sickle Quality: " + sickles.Quality;
            farmerGain.Text = "+" + farmers.TotalHarvest + " Wheat/Sec";
            minerGain.Text = "+" + miners.TotalHarvest + " Stone/Sec";
            if (merchants.Active)
            {
                merchantWheatCost.Text = filler;
                MerchantPurchased.Text = purchased;
                HireMerchantButton.IsEnabled = false;
                HireFarmerButton.IsEnabled = true;
                MarketTab.IsEnabled = true;
                farmerCost.IsEnabled = true;
                MerchantPurchased.IsEnabled = true;
            }
            if (farmers.Active)
            {
                farmerCost.Text = filler;
                FarmerPurchased.Text = purchased;
                HireFarmerButton.IsEnabled = false;
                HireMinerButton.IsEnabled = true;
            }
            if (miners.Active)
            {
                HireMinerButton.IsEnabled = false;
                minerCost.IsEnabled = true;
                minerWheatCost.IsEnabled = true;
                minerWheatCost.Text = filler;
                minerCost.Text = purchased;
                BlacksmithButton.IsEnabled = true;
            }
            if (blacksmiths.Active)
            {
                BlacksmithGoldCost.Text = filler;
                BlacksmithStoneCost.Text = filler;
                BlacksmithWheatCost.Text = purchased;
                BlacksmithButton.IsEnabled = false;
                sickleButton.IsEnabled = true;
            }
        }

        #region Townspeople

        private void HireMerchant(object sender, RoutedEventArgs e)
        {
            merchant.Hire(merchants, wheats);
            UpdateWheatText();
            UpdateTownsPeopleText();
        }

        private void HireFarmer(object sender, RoutedEventArgs e)
        {
            farmer.Hire(person, farmers);
            UpdateWheatText();
            UpdateTownsPeopleText();
        }

        private void HireMiner(object sender, RoutedEventArgs e)
        {
            miner.Hire(person, miners, wheats);
            UpdateWheatText();
            UpdateStoneText();
            UpdateTownsPeopleText();
        }

        private void HireBlacksmith(object sender, RoutedEventArgs e)
        {
            blacksmith.Hire(person, blacksmiths, wheats, stones, sickles);
            UpdateWheatText();
            UpdateStoneText();
            UpdateTownsPeopleText();
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

        private void UpdateMarketText()
        {
            stoneMarketPrices.Text = "Stone Price: $" + merchants.StonePrice;
            wheatMarketPrices.Text = "Wheat Price: $" + merchants.WheatPrice;
        }

        #endregion MerchantFeatures

        #region Wheat

        private void GetWheat(object sender, RoutedEventArgs e)
        {
            wheat.Gain(wheats);
            UpdateWheatText();
            UpdateTownsPeopleText();
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
            //farmerGain.Text = "+" + farmers.TotalHarvest + " Wheat/sec";
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
            UpdateTownsPeopleText();
        }

        private void UpdateStoneText()
        {
            goldText.Text = "Total Gold: " + person.Gold;
            stoneText.Text = "Stone: " + stones.Total + "/" + stones.Max;
            stonePerClick.Text = "Stone Per Click: " + stones.PerClick;
            minerCost.Text = "Gold To Hire Miner: " + miners.Cost;
            warehouseCost.Text = "Warehouse Gold Cost: " + market.Cost;
            warehouseTotal.Text = "Total Warehouses: " + market.Total;
        }

        #endregion Stone

        private void UpgradeSickle(object sender, RoutedEventArgs e)
        {
            blacksmith.UpgradeSickle(person, sickles, stones, farmers);
            UpdateWheatText();
            UpdateStoneText();
            UpdateTownsPeopleText();
        }
    }
}