using System;
using System.Windows;
using System.Windows.Threading;

namespace IsThisThingOn
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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
        }
    }
}