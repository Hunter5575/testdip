using DEADSADBD.Classes;
using DEADSADBD.Database;
using DEADSADBD.Pages.LVPages;
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

namespace DEADSADBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Page
    {
        private void Update()
        {
            CBVospit.ItemsSource = EfModel.Init().Vospits.ToList();
        }
        Grup grup;   
        public GroupPage(Grup grup)
        {
            this.grup = grup;
            InitializeComponent();
            Update();
            DataContext = grup;
        }

        private void BtSaveClick(object sender, RoutedEventArgs e)
        {
            if (grup.IdGrup == 0)
            {
                if (CBVospit.SelectedItem != null && CBVospit.SelectedItem is Vospit grupSelectedItem)
                {

                    grup.Vospit = grupSelectedItem.IdVospit;

                }
                EfModel.Init().Grups.Add(grup);
            }
            EfModel.Init().SaveChanges();
            NavigationService.Navigate(new GrupLVPage());
        }
    }
}
