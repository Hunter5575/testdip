using DEADSADBD.Classes;
using DEADSADBD.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data;

namespace DEADSADBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для PosechPage.xaml
    /// </summary>
    public partial class PosechPage : Page
    {
        private List<Deti> _detis;

        private void LoadData()
        {
            // Получаем данные из контекста EF
            using (var context = new EfModel())
            {
                _detis = context.Detis
                    .Include(d => d.GrupNavigation)
                    .Include(d => d.DataNavigation)
                    
                    .ToList();

                // Устанавливаем источник данных для datagrid
                DGVPosesh.ItemsSource = _detis;

                // Заполняем ComboBox списком уникальных значений для столбца "Номер группы"
                var groupNumbers = _detis.Select(d => d.GrupNavigation.Nomer.ToString()).Distinct().ToList();
                foreach (var item in groupNumbers)
                {
                    CBFiltrGroup.Items.Add(item);
                }

                // Заполняем ComboBox списком уникальных значений для столбца "Статус"
                var statuses = _detis.Select(d => d.Status).Distinct().ToList();
                foreach (var status in statuses)
                {
                    CBFiltrStatus.Items.Add(status);
                }

                // Добавляем обработчики событий Checked и Unchecked для DataGridCheckBoxColumn
                DGVPosesh.LoadingRow += (sender, e) =>
                {
                    var row = e.Row;
                    var deti = row.Item as Deti;

                    if (deti != null)
                    {
                        var cell = DGVPosesh.Columns.FirstOrDefault(c => c.Header.ToString() == "Актив").GetCellContent(row);

                        if (cell is CheckBox checkBox)
                        {
                            checkBox.Checked += (o, args) =>
                            {
                                deti.Status = "Присутствует";

                            };

                            checkBox.Unchecked += (o, args) =>
                            {
                                deti.Status = "Отсутствует";

                            };
                        }
                    }
                };
                DGVPosesh.CellEditEnding += DGVPosesh_CellEditEnding;
            }
        }
        private void FilterData()
        {
            var groupFilter = CBFiltrGroup.SelectedItem as string;
            var statusFilter = CBFiltrStatus.SelectedItem as string;

            if (!string.IsNullOrEmpty(groupFilter) && !string.IsNullOrEmpty(statusFilter))
            {
                DGVPosesh.ItemsSource = _detis.Where(d =>
                    d.GrupNavigation.Nomer.ToString() == groupFilter &&
                    d.Status == statusFilter).ToList();
            }
            else if (!string.IsNullOrEmpty(groupFilter))
            {
                DGVPosesh.ItemsSource = _detis.Where(d =>
                    d.GrupNavigation.Nomer.ToString() == groupFilter).ToList();
            }
            else if (!string.IsNullOrEmpty(statusFilter))
            {
                DGVPosesh.ItemsSource = _detis.Where(d => d.Status == statusFilter).ToList();
            }
            else
            {
                DGVPosesh.ItemsSource = _detis;
            }
        }
        public PosechPage()
        {
            InitializeComponent();

            // Загружаем данные в datagrid и заполняем ComboBox при инициализации страницы
            LoadData();
        }
        private void CBFiltrGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Фильтруем данные по группам при изменении значения комбобокса
            FilterData();
        }

        private void CBFiltrStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Фильтруем данные по статусу при изменении значения комбобокса
            FilterData();
        }

        private void DGVPosesh_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Проверьте, принадлежит ли отредактированая ячейка столбцу "Статус"
            if (e.Column == DGTStatus)
            {
                // Получите сущность "Deti", соответствующей отредактированной строке
                var deti = e.Row.Item as Deti;

                // Получите указанное значение из редактируемой ячейки
                var editedValue = (e.EditingElement as TextBox)?.Text;

                // Обновите свойство "Status" сущности "Deti"
                deti.Status = editedValue;

                // Сохраниет данные в базе данных
                using (var context = new EfModel())
                {
                    context.Update(deti);
                    context.SaveChanges();
                }
            }
        }

        private void CBAktiv1_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null && checkBox.DataContext is Deti deti)
            {
                deti.Status = "Присутствует";
                using (var context = new EfModel())
                {
                    context.Update(deti);
                    context.SaveChanges();
                }
            }
           
        }

        private void CBAktiv1_Unchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox != null && checkBox.DataContext is Deti deti)
            {
                deti.Status = "Отсутствует";
           using (var context = new EfModel())
            {
                context.Update(deti);
                context.SaveChanges();
            }
            }
        }
        private void DPDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранную дату
            var selectedDate = DPDate.SelectedDate;

            // Обновляем данные в списке Deti
            foreach (var deti in _detis)
            {
                deti.DataNavigation.Data = selectedDate.Value.Date;
            }

            // Сохраняем изменения в базе данных
            using (var context = new EfModel())
            {
                context.UpdateRange(_detis);
                context.SaveChanges();
            }

            // Обновляем источник данных для DataGrid
            DGVPosesh.ItemsSource = _detis;
        }

        private void TbSearch_Changed(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
