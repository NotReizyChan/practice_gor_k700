using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindow window;
        int tries = 0;
        prac_gotEntities context;
        public MainWindow()
        {
            InitializeComponent();
            DownLoadPicturesForParts();
            passShow.IsEnabled = false;
            context = new prac_gotEntities();
        }

        private void EnterInSys(object sender, RoutedEventArgs e)
        {
            try
            {
                int tabNam = Convert.ToInt32(LoginWorker.Text);
                string pass = PasswordWorker.Text;


                Worker worker = context.Worker.ToList().Find(x => x.tabNum == tabNam);
                if (worker == null)
                {
                    LoginWorker.Background = new SolidColorBrush(Colors.Red);
                    PasswordWorker.Background = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Для входа нужно заполнить обе строки!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (worker.password.Equals(pass))
                    {
                        LoginWorker.Background = new SolidColorBrush(Colors.Green);
                        PasswordWorker.Background = new SolidColorBrush(Colors.Green);
                        MessageBox.Show("Пароль верный! Выполняется вход!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window1 window1 = new Window1(worker,this );
                        window1.Show();
                    }
                    else
                        if (tries == 3)
                    {
                        passShow.IsEnabled = true;
                    }
                    else
                    {
                        PasswordWorker.Background = new SolidColorBrush(Colors.Red);
                        MessageBox.Show("Неправильно введен пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        tries++;
                    }

                }
            }
            catch (FormatException)
            {
                LoginWorker.Background = new SolidColorBrush(Colors.Red);
                PasswordWorker.Background = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Неверно введен логин!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        public void DownLoadPicturesForParts()
        {

            prac_gotEntities context = new prac_gotEntities();
            List<DevicePart> deviceParts = context.DevicePart.ToList();
            foreach (var item in deviceParts)
            {
                item.image = File.ReadAllBytes(@"D:\kekw\" + item.id + ".jpg");
                context.SaveChanges();
            }

        }

        private void showPass(object sender, RoutedEventArgs e)
        {
            prac_gotEntities context = new prac_gotEntities();
            Worker worker = context.Worker.Find(Convert.ToInt32 (LoginWorker.Text));
            if (tries == 3)
            {
                MessageBox.Show("Ваш пароль - "+ Convert.ToString( worker.password));
            }
        }
    }
}
