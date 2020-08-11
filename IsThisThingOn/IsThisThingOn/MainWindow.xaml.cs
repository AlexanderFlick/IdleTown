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

        private readonly IWheatService wheat;
        private readonly ITimerService timer;

        public MainWindow(IWheatService wheat, ITimerService timer)
        {
            this.wheat = wheat;
            this.timer = timer;
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
            UpdateText();
        }

        private void GetWheat(object sender, RoutedEventArgs e)
        {
            wheat.Gain(wheats);
            UpdateText();
        }

        private void SellWheat(object sender, RoutedEventArgs e)
        {
            wheat.Sell(person, wheats);
            UpdateText();
        }

        private void HireFarmer(object sender, RoutedEventArgs e)
        {
            wheat.HireFarmer(person, farmer, wheats);
            UpdateText();
        }

        private void BuyStorage(object sender, RoutedEventArgs e)
        {
            wheat.BuyStorage(person, storage, wheats);
            UpdateText();
        }

        private void BuyMarket(object sender, RoutedEventArgs e)
        {
            wheat.BuyMarket(person, market, wheats);
            UpdateText();
        }

        private void UpdateText()
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
    }
}