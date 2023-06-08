using DEADSADBD.Classes;
using DEADSADBD.Database;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для DetiLVpPage.xaml
    /// </summary>
    public partial class DetiLVpPage : Page
    {
        private void UpdateData()
        {
            LvDeti.ItemsSource = EfModel.Init().Detis.Include(g => g.GrupNavigation).Where(f=>f.Fio.Contains(TbSearch.Text)).ToList();
        }
        public DetiLVpPage()
        {
            InitializeComponent();
            UpdateData();
        }

        private void BtDetiClick(object sender, MouseButtonEventArgs e)
        {
            Deti deti = (Deti)LvDeti.SelectedItem;
            NavigationService.Navigate(new DetiPage(deti));

        }

        private void BtAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DetiPage(new Classes.Deti()));
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
