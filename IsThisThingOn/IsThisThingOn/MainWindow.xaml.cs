using BLL.Models;
using BLL.Services;
using System.Windows;

namespace IsThisThingOn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

        private void UpdateText()
        {
            goldText.Text = "Total Gold: " + person.gold.ToString();
            var wheatTotal = person.wheatTotal.ToString() + "/" + person.wheatMax.ToString();
            wheatText.Text = wheatTotal;
            var wheatPrice = "Price: $" + person.wheatPrice;
            wheatPrices.Text = wheatPrice;
        }
    }
}
