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

namespace TelecomNevaCvyaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          

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
                if (passBox.Password == "" || passBox.Password == " ")
                {
                    MessageBox.Show("Введите пароль", "Нет данных", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }


                WindowGenerationCode windowGenerationCode = new WindowGenerationCode();
                windowGenerationCode.Show();
                Application.Current.MainWindow.Close();
            }
        }

        private void passBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (tbNumber.Text == "" || tbNumber.Text == " ")
                {
                    MessageBox.Show("Введите номер", "Нет данных", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                if (passBox.Password == "" || passBox.Password == " ")
                {
                    MessageBox.Show("Введите пароль", "Нет данных", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }


                WindowGenerationCode windowGenerationCode = new WindowGenerationCode();
                windowGenerationCode.Show();
                Application.Current.MainWindow.Close();
            }
        }
    }
}
