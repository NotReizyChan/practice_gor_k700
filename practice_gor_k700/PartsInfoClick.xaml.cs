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
    /// Логика взаимодействия для PartsInfoClick.xaml
    /// </summary>
    public partial class PartsInfoClick : Page
    {
        prac_gotEntities context;
        public PartsInfoClick(prac_gotEntities context, Types types)
        {
            InitializeComponent();
            this.context = context;
            InfoGrid.ItemsSource = context.DevicePart.ToList().Where(x=> x.id == types.id).ToList();
        }
    }
}
