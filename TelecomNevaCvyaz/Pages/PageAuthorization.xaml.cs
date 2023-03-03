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
using System.Windows.Threading;

namespace TelecomNevaCvyaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {

        private int time = 10;
        private DispatcherTimer timer;

        bool btnEnterIsActive;

        public PageAuthorization()
        {
            InitializeComponent();

            btnEnterIsActive = true;

            if (Classes.GlobalValues.nomer != null)
            {
                tbNumber.Text = Classes.GlobalValues.nomer;
                passBox.Password = Classes.GlobalValues.password;
                tbCode.Focus();
            }
            else
            {
                tbNumber.Focus();
            }

            if(Classes.GlobalValues.code != null)
            {
                timerStart();
            }

        }

      

        private void tbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (tbNumber.Text == "" || tbNumber.Text == " ")
                {
                    MessageBox.Show("Введите номер", "Нет данных", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }

                var user = Classes.Base.EM.USER.FirstOrDefault(x => x.USER_LOGIN == tbNumber.Text);
                if(user == null)
                {
                    MessageBox.Show("Не можем найти этот номер", "Нет данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    passBox.Focus();
                }

             
            }
        }

     

        private void passBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (tbNumber.Text == "" || tbNumber.Text == " ")
                {
                    MessageBox.Show("Введите пароль", "Нет данных", MessageBoxButton.OK, MessageBoxImage.Hand);                
                    return;
                }
                if (passBox.Password == "" || passBox.Password == " ")
                {
                    MessageBox.Show("Введите пароль", "Нет данных", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }

                var user = Classes.Base.EM.USER.FirstOrDefault(x => x.USER_PASSWORD== passBox.Password);
                if (user == null)
                {
                    MessageBox.Show("Пароль не подходит. Попробуйте ещё", "Неверный пароль", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                


                WindowGenerationCode windowGenerationCode = new WindowGenerationCode();
                windowGenerationCode.Show();

                Classes.GlobalValues.nomer = tbNumber.Text;
                Classes.GlobalValues.password = passBox.Password;

                Application.Current.MainWindow.Close();


            }
        }

        private void timerStart()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time == 0)
            {
                timer.Stop();
                MessageBox.Show("Вы не успели ввести код. Нажмите на кнопку со стрелками, чтобы перезапросить код", "Неверный код", MessageBoxButton.OK, MessageBoxImage.Warning);
                btnEnterIsActive = false;
            }
            else
            {
                time--;
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {

            if(Classes.GlobalValues.code == null)
            {
                return;
            }


            WindowGenerationCode windowGenerationCode = new WindowGenerationCode();
            windowGenerationCode.Show();

            Classes.GlobalValues.nomer = tbNumber.Text;
            Classes.GlobalValues.password = passBox.Password;



            foreach (Window w in App.Current.Windows)
            {
                if (w != windowGenerationCode)
                    w.Close();
            }

        }

       

        private void tbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnEnterIsActive)
            {
                if (e.Key == Key.Enter)
                {
                    enter();
                }
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if(Classes.GlobalValues.code == null)
            {
                return;
            }

            if (btnEnterIsActive)
            {
                enter();
            }
            
        }

        private void enter()
        {
            if (Classes.GlobalValues.code == tbCode.Text)
            {
                timer.Stop();

                var user = Classes.Base.EM.USER.FirstOrDefault(x => x.USER_PASSWORD == passBox.Password);
                var userType = Classes.Base.EM.USER_TYPE.FirstOrDefault(x => x.USER_TYPE_ID == user.USER_TYPE_ID);


                MessageBox.Show("Добрый день. Вы вошли как " + userType.USER_TYPE1, "Вход в систему", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Вы ввели не тот код. Нажмите на кнопку со стрелками, чтобы перезапросить ", "Нет данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbCode.Text = "";

                btnEnterIsActive = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbNumber.Text = "";
            passBox.Password = "";
            tbCode.Text = "";

            tbNumber.Focus();

        }
    }
}
