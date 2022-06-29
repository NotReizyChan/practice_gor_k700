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
    /// Логика взаимодействия для DevicePage.xaml
    /// </summary>
    public partial class DevicePage : Page
    {
        prac_gotEntities context;
        public DevicePage()
        {
            InitializeComponent();
            context = new prac_gotEntities();
            DeviceGrid.ItemsSource = context.Device.ToList();
            var typeList = context.Type.ToList();
            typeList.Insert(0, new Type() { Title = "Все", id = 0 });
             
            EquipTypebox.ItemsSource = typeList;
        }

        public void Refresher()
        {
            var list = context.Device.ToList();
            if (EquipTypebox.SelectedIndex > 0)
            {
                Type pos = EquipTypebox.SelectedItem as Type;
                list = list.Where(x => x.Type1 == pos).ToList();
            }
            if (!string.IsNullOrWhiteSpace(Equipbox.Text))
            {
                list = list.Where(x => x.model.ToLower().Contains(Equipbox.Text.ToLower())).ToList();
            }
            DeviceGrid.ItemsSource = list;
        }

        private void EquipboxChanged(object sender, TextChangedEventArgs e)
        {
            Refresher();
        }

        private void ChangingType(object sender, SelectionChangedEventArgs e)
        {
            Refresher();
        }

        private void AddDevice(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDevicePage(context));
        }
    }
}
