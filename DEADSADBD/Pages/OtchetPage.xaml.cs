using DEADSADBD.Classes;
using DEADSADBD.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для OtchetPage.xaml
    /// </summary>
    public partial class OtchetPage : Page
    {
       

        public OtchetPage()
        {
            InitializeComponent();
        }

        private void BtDetiExClick(object sender, RoutedEventArgs e)
        { Mouse.OverrideCursor = Cursors.Wait;
            string strWriteFilePath = string.Empty;
            SaveFileDialog saveFile = new SaveFileDialog { Filter = "*Excel|*.xlsx|All files|*.*" };
            bool? result = saveFile.ShowDialog();
            if (result == true)
                strWriteFilePath = saveFile.FileName;
            else
                return;
            {

                FileStream stream = new FileStream(strWriteFilePath, FileMode.Create, FileAccess.ReadWrite);

                IWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet("Deti");

                Type type = typeof(Deti);
                PropertyInfo[] properties = type.GetProperties();

                IRow row = sheet.CreateRow(0);

                for (int c = 0; c < properties.Length; c++)
                {
                    row.CreateCell(c).SetCellValue(properties[c].Name);
                }


                List<Deti> deti = EfModel.Init().Detis.Include(g=>g.GrupNavigation).Include(d=>d.DataNavigation).ToList();
                for (int r = 0; r < deti.Count(); r++)
                {
                    IRow innerRow = sheet.CreateRow(r + 1);

                    for (int c = 0; c < properties.Length; c++)
                    {
                        innerRow.CreateCell(c).SetCellValue(properties[c].GetValue(deti[r]).ToString());
                    }
                }
                book.Write(stream);
                book.Close();
                stream.Close();
            }

            Mouse.OverrideCursor = null;
        
    }

        private void BtGrupExClick(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            string strWriteFilePath = string.Empty;
            SaveFileDialog saveFile = new SaveFileDialog { Filter = "*Excel|*.xlsx|All files|*.*" };
            bool? result = saveFile.ShowDialog();
            if (result == true)
                strWriteFilePath = saveFile.FileName;
            else
                return;
            {

                FileStream stream = new FileStream(strWriteFilePath, FileMode.Create, FileAccess.ReadWrite);

                IWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet("Grup");

                Type type = typeof(Deti);
                PropertyInfo[] properties = type.GetProperties();

                IRow row = sheet.CreateRow(0);

                for (int a = 0; a < properties.Length; a
                    ++)
                {
                    row.CreateCell(a).SetCellValue(properties[a].Name);
                }


                List<Grup> grup = EfModel.Init().Grups.Include(g => g.VospitNavigation).ToList();
                for (int i = 0; i < grup.Count(); i++)
                {
                    IRow innerRow = sheet.CreateRow(i + 1);

                    for (int a = 0; a < properties.Length; a++)
                    {
                        innerRow.CreateCell(a).SetCellValue(Convert.ToString(properties[a].GetValue(grup[i])));
                    }
                }
                book.Write(stream);
                book.Close();
                stream.Close();
            }

            Mouse.OverrideCursor = null;
        }

        private void BtVospitExClick(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            string strWriteFilePath = string.Empty;
            SaveFileDialog saveFile = new SaveFileDialog { Filter = "*Excel|*.xlsx|All files|*.*" };
            bool? result = saveFile.ShowDialog();
            if (result == true)
                strWriteFilePath = saveFile.FileName;
            else
                return;
            {

                FileStream stream = new FileStream(strWriteFilePath, FileMode.Create, FileAccess.ReadWrite);

                IWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet("Vospit");

                Type type = typeof(Deti);
                PropertyInfo[] properties = type.GetProperties();

                IRow row = sheet.CreateRow(0);

                for (int c = 0; c < properties.Length; c++)
                {
                    row.CreateCell(c).SetCellValue(properties[c].Name);
                }


                List<Vospit> vospits = EfModel.Init().Vospits.Include(g => g.IdRolsNavigation).ToList();
                for (int r = 0; r < vospits.Count(); r++)
                {
                    IRow innerRow = sheet.CreateRow(r + 1);

                    for (int c = 0; c < properties.Length; c++)
                    {
                        innerRow.CreateCell(c).SetCellValue(properties[c].GetValue(vospits[r]).ToString());
                    }
                }
                book.Write(stream);
                book.Close();
                stream.Close();
            }

            Mouse.OverrideCursor = null;
        }

        private void BtPolzovExClick(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            string strWriteFilePath = string.Empty;
            SaveFileDialog saveFile = new SaveFileDialog { Filter = "*Excel|*.xlsx|All files|*.*" };
            bool? result = saveFile.ShowDialog();
            if (result == true)
                strWriteFilePath = saveFile.FileName;
            else
                return;
            {

                FileStream stream = new FileStream(strWriteFilePath, FileMode.Create, FileAccess.ReadWrite);

                IWorkbook book = new XSSFWorkbook();
                ISheet sheet = book.CreateSheet("Polzov");

                Type type = typeof(Deti);
                PropertyInfo[] properties = type.GetProperties();

                IRow row = sheet.CreateRow(0);

                for (int c = 0; c < properties.Length; c++)
                {
                    row.CreateCell(c).SetCellValue(properties[c].Name);
                }


                List<Polzov> polzovs = EfModel.Init().Polzovs.Include(g => g.IdRollNavigation).ToList();
                for (int r = 0; r < polzovs.Count(); r++)
                {
                    IRow innerRow = sheet.CreateRow(r + 1);

                    for (int c = 0; c < properties.Length; c++)
                    {
                        innerRow.CreateCell(c).SetCellValue(properties[c].GetValue(polzovs[r]).ToString());
                    }
                }
                book.Write(stream);
                book.Close();
                stream.Close();
            }

            Mouse.OverrideCursor = null;
        }
    }
}
