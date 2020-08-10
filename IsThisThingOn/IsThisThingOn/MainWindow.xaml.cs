using BLL.Models;
using BLL.Services;
using System;
using System.Windows;

namespace IsThisThingOn
{
    public partial class MainWindow : Window
    {
        Person person = new Person();
        private readonly IWheatService wheat;

        public MainWindow(IWheatService wheat)
        {
            this.wheat = wheat;
            InitializeComponent();
        }

        private void GetWheat(object sender, RoutedEventArgs e)
        {
            wheat.Gain(person);
            UpdateText();
        }

        private void SellWheat(object sender, RoutedEventArgs e)
        {
            wheat.Sell(person);
            UpdateText();
        }

        private void HireFarmer(object sender, RoutedEventArgs e)
        {
            wheat.HireFarmer(person);
            UpdateText();
        }

        private void BuyStorage(object sender, RoutedEventArgs e)
        {
            wheat.BuyStorage(person);
            UpdateText();
        }

        private void BuyMarket(object sender, RoutedEventArgs e)
        {
            wheat.BuyMarket(person);
            UpdateText();
        }

        private void UpdateText()
        {
            goldText.Text = "Total Gold: " + person.Gold.ToString();
            wheatText.Text = "Wheat: " + person.WheatTotal.ToString() + "/" + person.WheatMax.ToString();
            wheatPrices.Text = "Price: $" + person.WheatPrice;
            wheatPerClick.Text = "Wheat Per Click: " + person.WheatPerClick;
            totalFarmer.Text = "Total Farmers: " + person.Farmers;
            farmerGain.Text = "+" + person.WheatPerSec + " Wheat/click";
            farmerCost.Text = "Gold To Hire Farmer: " + person.FarmerGoldCost;
            storageTotal.Text = "Total Warehouses: " + person.StorageUnits;
            storageIncrease.Text = "+" + person.ChestIncreaseWheatMax + " Max Wheat";
            storageCost.Text = "Storage Gold Cost: " + person.StorageCost;
            marketCost.Text = "Gold To Buy Market: " + person.MarketCost;
            marketTotal.Text = "Total Markets: " + person.Markets;
            marketIncrease.Text = "x" + person.WheatPerSale + " Per Sale";
        }

        
    }
}
