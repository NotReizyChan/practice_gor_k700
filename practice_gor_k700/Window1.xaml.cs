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
using System.Windows.Shapes;

namespace practice_gor_k700
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        prac_gotEntities context;
        public Window1()
        {
            InitializeComponent();
            context = new prac_gotEntities();
            //NameOfWorker = context.Worker.ToList().Find(FIO);
        }

        private void Watch(object sender, RoutedEventArgs e)
        {

        }
    }
}
