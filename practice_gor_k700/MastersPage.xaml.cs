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
    /// Логика взаимодействия для MastersPage.xaml
    /// </summary>
    public partial class MastersPage : Page
    {
        prac_gotEntities context;
        public MastersPage()
        {
            InitializeComponent();
            context = new prac_gotEntities();
            MastersGrid.ItemsSource = context.Worker.ToList();
            var posList= context.Position.ToList();
            posList.Insert(0, new Position() { title = "Все", id = 0});
            MasterStatbox.ItemsSource = posList; 
        }

        public void Refresher()
        {
            var list = context.Worker.ToList();
            if (MasterStatbox.SelectedIndex > 0)
            {
                Position pos = MasterStatbox.SelectedItem as Position;
                list= list.Where(x => x.Position1 == pos).ToList();
            }
            if(!string.IsNullOrWhiteSpace(MasterFIObox.Text))
            {
                list = list.Where(x => x.FIO.ToLower().Contains(MasterFIObox.Text.ToLower())).ToList();
            }
            MastersGrid.ItemsSource = list;
        }

        private void ChangingPosition(object sender, SelectionChangedEventArgs e)
        {
            Refresher();
        }

        private void FIOchanged(object sender, TextChangedEventArgs e)
        {
            Refresher();
        }

        private void AddMaster(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddMaster(context));
        }

        private void EditMaster(object sender, RoutedEventArgs e)
        {
            Worker worker = MastersGrid.SelectedItem as Worker;
            NavigationService.Navigate(new AddMaster(context, worker));
        }

        private void DeleteMaster(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res =MessageBox.Show ("Вы уверены, что хотите удалить данного мастера?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Worker worker= MastersGrid.SelectedItem as Worker;
                    context.Worker.Remove(worker);
                    context.SaveChanges();
                    NavigationService.Navigate(new MastersPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
    }
}
