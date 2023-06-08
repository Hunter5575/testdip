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
using System.Windows.Shapes;

namespace DEADSADBD.Okno
{
    /// <summary>
    /// Логика взаимодействия для Avtor.xaml
    /// </summary>
    public partial class Avtor : Window
    {
        public Avtor()
        {
            InitializeComponent();
        }

        private void BtClickEnter(object sender, RoutedEventArgs e)
        {
            if(AuthClass.Auth(TbLogin.Text,TbPassword.Text))
            {
                MessageBox.Show("Добро пожаловать!" );
                Hide();
                new MainWindow().Show();
                Close();
            }
            else if (AuthClass.Auth1(TbLogin.Text, TbPassword.Text))
            {
                MessageBox.Show("Добро пожаловать!" );
                Hide();
                new MainWindow().Show();
                Close();

            }
            else
            {
                MessageBox.Show("Проверьте введённые данные");
            }
        }
    }
}
