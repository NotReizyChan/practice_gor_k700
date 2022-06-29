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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        prac_gotEntities context;
        public AddClient(prac_gotEntities cont)
        {
            InitializeComponent();
            context = cont;
        }

        private void SaveNewClient(object sender, RoutedEventArgs e)
        {
            Client client = new Client()
            {
                Num = Convert.ToInt32(TabBox.Text),
                name = NameBox.Text,
                serialPass = Convert.ToInt32(SerialBox.Text),
                numberPas = Convert.ToInt32(NumberBox.Text),
                phone = Convert.ToDecimal(PhoneNumberBox.Text)
            };
            context.Client.Add(client);
            context.SaveChanges();
            NavigationService.Navigate(new ClientPage());
        }
    }
}
