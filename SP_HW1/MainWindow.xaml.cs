using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SP_HW1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var processes = Process.GetProcesses();
            dataGrdid.ItemsSource = processes;
        }

        private void dataGrdid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                var selectedItem = dataGrdid.SelectedItem;
                if (selectedItem != null)
                {
                    using (var process = selectedItem as Process)
                    {
                        process.Kill();
                    }

                    var processes = Process.GetProcesses();
                    dataGrdid.ItemsSource = processes;
                    MessageBox.Show("Процесс завершен");
                }
            }
            catch
            {
                MessageBox.Show("Отказано в доступе");
            }
        }
    }
}
