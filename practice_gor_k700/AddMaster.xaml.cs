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
    /// Логика взаимодействия для AddMaster.xaml
    /// </summary>
    public partial class AddMaster : Page
    {
        bool flag; //добавить - true, редактировать - false
        prac_gotEntities context;
        public AddMaster(prac_gotEntities cont)
        {
            InitializeComponent();
            context = cont;
            StatusMasbox.ItemsSource = context.Position.ToList();
            flag = true;
        }
         


        private void SaveMaster(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Worker worker = new Worker()
                {
                    tabNum = Convert.ToInt32(TABNOMbox.Text),
                    FIO = FIObox.Text,
                    position = (StatusMasbox.SelectedItem as Position).id,
                    oklad = Convert.ToDecimal(Okladbox.Text),
                    percentToRepair = Convert.ToDecimal(Percentbox.Text),
                    password = Passwordbox.Text,
                };
                context.Worker.Add(worker);
                context.SaveChanges();
                NavigationService.Navigate(new MastersPage());
            }
            else
            {
                context.Worker.Find(work.tabNum).FIO = FIObox.Text;
                context.Worker.Find(work.tabNum).position = (StatusMasbox.SelectedItem as Position).id;
                context.Worker.Find(work.tabNum).oklad = Convert.ToDecimal(Okladbox.Text);
                context.Worker.Find(work.tabNum).percentToRepair = Convert.ToDecimal(Percentbox.Text);
                context.Worker.Find(work.tabNum).password = Passwordbox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new MastersPage());
            }
        }

        Worker work;

        public AddMaster(prac_gotEntities cont, Worker worker)//контструктор редактирования 
        {
            InitializeComponent();
            context = cont;
            StatusMasbox.ItemsSource = context.Position.ToList();
            work = worker;
            TABNOMbox.Text = worker.tabNum.ToString();
            FIObox.Text = worker.FIO.ToString();
            StatusMasbox.SelectedItem = worker.position.ToString();
            Okladbox.Text = worker.oklad.ToString();
            Percentbox.Text = worker.percentToRepair.ToString();
            Passwordbox.Text = worker.password.ToString();
            flag = false;
        }
    }
}
