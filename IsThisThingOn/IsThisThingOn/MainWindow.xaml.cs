using BLL.Models;
using BLL.Services;
using System;
using System.Windows;

namespace IsThisThingOn
{
    public partial class MainWindow : Window
    {
        Person person = new Person();
        Wheat wheats = new Wheat();
        Markets market = new Markets();
        Farmer farmer = new Farmer();
        Storage storage = new Storage();

        private readonly IWheatService wheat;

        public MainWindow(IWheatService wheat)
        {
            this.wheat = wheat;
            InitializeComponent();
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
            farmerGain.Text = "+" + wheats.PerClick + " Wheat/click";
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
