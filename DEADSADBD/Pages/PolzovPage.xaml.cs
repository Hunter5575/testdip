using DEADSADBD.Classes;
using DEADSADBD.Database;
using DEADSADBD.Pages.LVPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PolzovPage.xaml
    /// </summary>
    public partial class PolzovPage : Page
    {
        private void Update()
        {
            IEnumerable<Roll> rolls = EfModel.Init().Rolls.ToList();
            CbRoll.ItemsSource = rolls;
            
        }
        Polzov polzovs;
        public PolzovPage(Polzov polzovs)
        {
            this.polzovs = polzovs;
            InitializeComponent();
            Update();
            DataContext = polzovs;
        }

        private void BtSaveClick(object sender, RoutedEventArgs e)
        {
            if (polzovs.IdPolzov == 0)
            {
                
                if (CbRoll.SelectedItem != null && CbRoll.SelectedItem is Roll rollSelectedItem)
                {

                    polzovs.IdRoll = rollSelectedItem.IdRoll;

                }
                EfModel.Init().Polzovs.Add(polzovs);
            }
            EfModel.Init().SaveChanges();
            NavigationService.Navigate(new PolzovLVPage());
        }
    }
}
