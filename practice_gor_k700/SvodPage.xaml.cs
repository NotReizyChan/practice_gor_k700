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
    /// Логика взаимодействия для SvodPage.xaml
    /// </summary>
    public partial class SvodPage : Page
    {
        public SvodPage()
        {
            InitializeComponent();
            List<Device> devicelist;
            using (prac_gotEntities context = new prac_gotEntities())
            {
                devicelist = context.Device.ToList();

                var list = devicelist.Select(x => new
                {
                    Device = x.model,
                    Client = x.Client1.name,
                    Worker = x.Worker.FIO
                }
                ).ToList();
                //var endlist = list.Join(devicelist ,x => x.)

                datagridSvod.ItemsSource = list;
            }
        }
    }
}
