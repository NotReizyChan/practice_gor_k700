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

namespace practice_gor_k700
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        prac_gotEntities context;
        public ClientPage()
        {
            InitializeComponent();
            context = new prac_gotEntities();
            ClientGrid.ItemsSource = context.Client.ToList();
        }

        public void Refresher()
        {
            var list = context.Client.ToList();
            if (!string.IsNullOrWhiteSpace(Clientbox.Text))
            {
                list = list.Where(x => x.name.ToLower().Contains(Clientbox.Text.ToLower())).ToList();
            }
            ClientGrid.ItemsSource = list;
        }

        private void EditClients(object sender, RoutedEventArgs e)
        {
            Client client = ClientGrid.SelectedItem as Client;
            NavigationService.Navigate(new ChngeClient());
        }

        private void Namechanged(object sender, TextChangedEventArgs e)
        {
            Refresher();
        }
    }
}
