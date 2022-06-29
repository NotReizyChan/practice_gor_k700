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
    /// Логика взаимодействия для PartsPage.xaml
    /// </summary>
    public partial class PartsPage : Page
    {
        prac_gotEntities contex;
        public PartsPage()
        {
            InitializeComponent();
            contex = new prac_gotEntities();
            var titlePaarts = contex.Types.ToList();
            titlePaarts.Insert(0, new Types() { title = "все" });
            partsListView.ItemsSource = contex.Types.ToList(); 
            partsBox.ItemsSource = titlePaarts;
        }

        private void ComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            Types Types11 = partsBox.SelectedItem as Types;
            if (partsBox.SelectedIndex != 0)
            {
                partsListView.ItemsSource = contex.Types.ToList().Where(x => x.title == Types11.title).ToList();
            }
            else
            {
                partsListView.ItemsSource = contex.Types.ToList();
            }
        }

        private void ClickedPlate(object sender, MouseButtonEventArgs e)
        {
            Types types = (sender as Grid).DataContext as Types;
            NavigationService.Navigate(new PartsInfoClick(contex, types
                ));
        }
    }
}
