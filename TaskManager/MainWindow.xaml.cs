using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ProcInfo> listInfo;
        
        public MainWindow()
        {
            InitializeComponent();
            LoadInfo();
        }

        public void LoadInfo()
        {
            listInfo = new ObservableCollection<ProcInfo>();
            var processes = Process.GetProcesses();

            int i = 0;

            foreach (var process in processes)
            {
                listInfo.Add(new ProcInfo
                {
                    Id = process.Id,
                    ProcessName = process.ProcessName + ".exe",
                    Resp = (process.Responding) ? "Выполняется" : "Не выполняется",
                    MemorySize = process.PrivateMemorySize64
                });

            }

            tmDataGrid.ItemsSource = listInfo;

        }

        private void btnKillProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.GetProcessById(listInfo[tmDataGrid.SelectedIndex].Id).Kill();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Невозможно снять процесс:\n" + exc);
            }

            LoadInfo();

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadInfo();

        }
    }
}
