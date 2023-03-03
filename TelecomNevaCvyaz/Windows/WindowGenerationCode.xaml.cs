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

namespace TelecomNevaCvyaz
{
    /// <summary>
    /// Логика взаимодействия для WindowGenerationCode.xaml
    /// </summary>
    public partial class WindowGenerationCode : Window
    {
        public WindowGenerationCode()
        {
            InitializeComponent();

            string letters = "qwertyuioplkjhgfdsazxcvbnm";
            string lettersLow = "ASDFGHJKLZXCVBNMQWERTYUIOP";
            string spec = "!@#$%^&*()_+";
            string numbers = "0123456789";

            string randomCode = "";

            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                if(i % 2 == 0)
                randomCode += letters[rnd.Next(lettersLow.Length)];
                else
                
                    randomCode += lettersLow[rnd.Next(27)];           
            }
            for (int i = 0; i < 2; i++)
            {
                randomCode += numbers[rnd.Next(10)];
            }

            randomCode += spec[rnd.Next(11)];

            tbGeneratedCode.Text = randomCode;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Classes.GlobalValues.code = tbGeneratedCode.Text;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
