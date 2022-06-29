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
    /// Логика взаимодействия для DiagnosticResultPage.xaml
    /// </summary>
    public partial class DiagnosticResultPage : Page
    {
        prac_gotEntities context;
        public DiagnosticResultPage(prac_gotEntities cont)
        {
            InitializeComponent();
            context = cont;
            DeviceNameDiagnostic.ItemsSource = context.Device.ToList();
        }

        private void saveDiagnostic(object sender, RoutedEventArgs e)
        {

            FirstDiagnostic firstDiagnostic = new FirstDiagnostic()
            {
                idDiagnostic = Convert.ToInt32(IdDiagnostic.Text),
                device = (DeviceNameDiagnostic.SelectedItem as Device).id,
                description = CommentBox.Text,
            };
            context.FirstDiagnostic.Add(firstDiagnostic);
            context.SaveChanges();
        }
    }
}
