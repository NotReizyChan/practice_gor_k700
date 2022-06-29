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
    /// Логика взаимодействия для AddDevicePage.xaml
    /// </summary>
    public partial class AddDevicePage : Page
    {
        prac_gotEntities context;
        public AddDevicePage(prac_gotEntities cont)
        {
            InitializeComponent();
            context = cont;
            FioOfMaster.ItemsSource = context.Worker.ToList();
            FioOfClient.ItemsSource = context.Client.ToList();
            TypeOfDevice.ItemsSource = context.Type.ToList();
        }

        private void SaveReq(object sender, RoutedEventArgs e)
        {
            Device device = new Device()
            {
                id = Convert.ToInt32(NumberOfDevice.Text),
                type = (TypeOfDevice.SelectedItem as Type).id,
                model = ModelOfDevice.Text,
                damage = DamageOfDevice.Text,
                complaint = ComplaintOfDevice.Text,
                master = (FioOfMaster.SelectedItem as Worker).tabNum,
                client= (FioOfClient.SelectedItem as Client).Num,
            };
            context.Device.Add(device);
            context.SaveChanges();
            NavigationService.Navigate(new DevicePage());
        }
    }
}
