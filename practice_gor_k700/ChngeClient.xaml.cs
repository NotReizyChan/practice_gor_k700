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
    /// Логика взаимодействия для ChngeClient.xaml
    /// </summary>
    public partial class ChngeClient : Page
    {
        prac_gotEntities context;
        public ChngeClient()
        {
            InitializeComponent();
            //context = cont;
        }

        Client clin;

        private void SaveClient(object sender, RoutedEventArgs e)
        {
            context.Client.Find(clin.Num).name = namebox.Text;
            context.Client.Find(clin.Num).serialPass = Convert.ToInt32(Serbox.Text);
            context.Client.Find(clin.Num).numberPas = Convert.ToInt32(Numpassbox.Text);
            context.Client.Find(clin.Num).phone = Convert.ToDecimal(Phonebox.Text);
            context.SaveChanges();
            NavigationService.Navigate(new MastersPage());
        }
    }
}
