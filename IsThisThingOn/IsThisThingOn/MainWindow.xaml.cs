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
        private readonly ITimerService timer;
        private readonly IItemService itemService;

        public MainWindow(IWheatService wheat, ITimerService timer, IItemService itemService)
        {
            this.wheat = wheat;
            this.timer = timer;
            this.itemService = itemService;
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

        private void UpdateText()
        {
            goldText.Text = "Total Gold: " + person.Gold.ToString();
            wheatText.Text = "Wheat: " + person.WheatTotal.ToString() + "/" + person.WheatMax.ToString();
            wheatPrices.Text = "Price: $" + person.WheatPrice;
            wheatPerClick.Text = "Wheat Per Click: " + person.WheatPerClick;
            totalFarmer.Text = "Total Farmers: " + person.Farmers;
            farmerGain.Text = "+" + person.WheatPerSec + " Wheat/sec";
            farmerCost.Text = "Gold To Hire Farmer: " + person.FarmerGoldCost;
            storageTotal.Text = "Total Warehouses: " + person.StorageUnits;
            storageIncrease.Text = "+" + person.ChestIncreaseWheatMax + " Max Wheat Storage";
            storageCost.Text = "Storage Gold Cost: " + person.StorageCost;

        }
    }
}
