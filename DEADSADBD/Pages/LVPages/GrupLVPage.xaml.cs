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
    /// Логика взаимодействия для GrupLVPage.xaml
    /// </summary>
    public partial class GrupLVPage : Page
    {
        private void UpdateData()
        {
            LvDeti.ItemsSource = EfModel.Init().Grups.Include(v=>v.VospitNavigation).ToList();
        }
        public GrupLVPage()
        {
            InitializeComponent();
            UpdateData();
        }
        private void BtDetiClick(object sender, MouseButtonEventArgs e)
        {
            Grup deti = (Grup)LvDeti.SelectedItem;
            NavigationService.Navigate(new GroupPage(deti));

        }

        private void BtAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupPage(new Grup()));
        }

        private void BtDelClick(object sender, RoutedEventArgs e)
        {
            EfModel.Init().Remove(LvDeti.SelectedItem);
            EfModel.Init().SaveChanges();
            MessageBox.Show("Выполнено");
            UpdateData();
        }
    }
}
