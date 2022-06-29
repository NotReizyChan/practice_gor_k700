using System;
using System.Collections.Generic;
using System.IO;
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

namespace practice_gor_k700
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        prac_gotEntities context;
        MainWindow window;
        public Window1(Worker worker, MainWindow window)
        {
            InitializeComponent();
            if(worker.position == 2)
            {
                RequestButton.Visibility = Visibility.Collapsed;
                PartsButton.Visibility = Visibility.Collapsed;
                MastersButton.Visibility = Visibility.Collapsed;

            }
            context = new prac_gotEntities();
            window.Visibility = Visibility.Collapsed;
            this.window = window;
        }

        private void ShowMasters(object sender, RoutedEventArgs e)
        {
            MastersFrame.Navigate(new MastersPage());
        }

        private void ShowClients(object sender, RoutedEventArgs e)
        {
            MastersFrame.Navigate(new ClientPage());
        }

        private void ShowRequest(object sender, RoutedEventArgs e)
        {
            MastersFrame.Navigate(new DevicePage());
        }

        private void ShowParts(object sender, RoutedEventArgs e)
        {
            MastersFrame.Navigate(new PartsPage());
        }

        private void ShowSvod(object sender, RoutedEventArgs e)
        {
            MastersFrame.Navigate(new SvodPage());
        }

        private void ClosedWindow(object sender, EventArgs e)
        {
            window.Close();
        }

        private void FirstDiagnostic(object sender, RoutedEventArgs e)
        {
            MastersFrame.Navigate(new DiagnosticResultPage(context));
        }
    }
}
