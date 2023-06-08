using DEADSADBD.Classes;
using DEADSADBD.Database;
using DEADSADBD.Pages;
using DEADSADBD.Pages.LVPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DEADSADBD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtPosechClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new PosechPage());
        }

        private void BtOtchetClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new OtchetPage());
        }

        private void BtDetiClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new DetiLVpPage());
            //FrNav.Navigate(new DetiPage(new Deti()));
        }

        private void BtGroupClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new GrupLVPage());
        }

        private void BtVospitClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new VospitLVPage());
        }

        private void BtPolzovatClick(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new PolzovLVPage());
        }
    }
}
