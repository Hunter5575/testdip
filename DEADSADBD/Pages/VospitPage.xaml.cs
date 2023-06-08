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
    /// Логика взаимодействия для VospitPage.xaml
    /// </summary>
    public partial class VospitPage : Page
    {
        private void Update()
        { 
            IEnumerable<Roll> rolls= EfModel.Init().Rolls.ToList();
            CbRoll.ItemsSource = rolls;
            IEnumerable<Grup> grups = EfModel.Init().Grups.ToList();
            CBGroup.ItemsSource = grups;
        }
        Vospit vospit;
        public VospitPage(Vospit vospit)
        {
            this.vospit = vospit;
            InitializeComponent();
            Update();
            DataContext = vospit;
        }
        private void BtSaveClick(object sender, RoutedEventArgs e)
        {
            if (vospit.IdVospit == 0)
            {
                if (CBGroup.SelectedItem != null && CBGroup.SelectedItem is Grup grupSelectedItem)
                {

                    vospit.Grup = grupSelectedItem.Nomer.ToString();

                }
                if (CbRoll.SelectedItem != null && CbRoll.SelectedItem is Roll rollSelectedItem)
                {

                    vospit.IdRols = rollSelectedItem.IdRoll;

                }
                EfModel.Init().Vospits.Add(vospit);
            }
            EfModel.Init().SaveChanges();
            NavigationService.Navigate(new VospitLVPage());
        }
    }
}
