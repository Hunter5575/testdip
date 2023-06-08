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
    /// Логика взаимодействия для DetiPage.xaml
    /// </summary>
    public partial class DetiPage : Page
    {
        private void Update()
        {
            IEnumerable<Grup> grups = EfModel.Init().Grups.ToList();
            CBGroup.ItemsSource = grups;
        }
        Deti deti;
        public DetiPage(Deti deti)
        {
            this.deti = deti;
           
            InitializeComponent();
            Update();
            
            DataContext = deti;
            
        }

        private void BtSaveClick(object sender, RoutedEventArgs e)
        {
            if (deti.IdDeti == 0)
            {
                // создаем новый объект Deti и заполняем его свойства
                deti.Status = ((ComboBoxItem)CBStatus.SelectedItem).Content.ToString();
                if (CBGroup.SelectedItem != null && CBGroup.SelectedItem is Grup grupSelectedItem)
                {

                    deti.Grup = grupSelectedItem.IdGrup;
                    
                }
                else
                {
                    MessageBox.Show("error");
                }
                deti.DataNavigation = new Datum(); // create new instance of DataNavigation
                deti.DataNavigation.Data = DateTime.Now; // set Data property to DateTime.Now
                
                // добавляем новый объект Deti в DbSet Detis
                EfModel.Init().Detis.Add(deti);
            }

            // сохраняем изменения в базе данных
            EfModel.Init().SaveChanges();
            NavigationService.Navigate(new DetiLVpPage());
        }
    }
}
