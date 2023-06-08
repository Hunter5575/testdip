using DEADSADBD.Classes;
using DEADSADBD.Database;
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

namespace DEADSADBD.Pages.LVPages
{
    /// <summary>
    /// Логика взаимодействия для PolzovLVPage.xaml
    /// </summary>
    public partial class PolzovLVPage : Page
    {
        private void UpdateData()
        {
            LvDeti.ItemsSource = EfModel.Init().Polzovs.Where(f => f.Fio.Contains(TbSearch.Text)).ToList();
        }
        public PolzovLVPage()
        {
            InitializeComponent();
            UpdateData();
        }
        private void BtDetiClick(object sender, MouseButtonEventArgs e)
        {
            Polzov deti = (Polzov)LvDeti.SelectedItem;
            NavigationService.Navigate(new PolzovPage(deti));

        }

        private void BtAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PolzovPage(new Polzov()));
        }

        private void BtDelClick(object sender, RoutedEventArgs e)
        {
            EfModel.Init().Remove(LvDeti.SelectedItem);
            EfModel.Init().SaveChanges();
            MessageBox.Show("Выполнено");
            UpdateData();
        }

        private void TbSearch_Changed(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
