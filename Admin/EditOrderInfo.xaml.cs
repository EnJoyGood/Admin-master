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

namespace Admin
{
    /// <summary>
    /// Логика взаимодействия для EditOrderInfo.xaml
    /// </summary>
    public partial class EditOrderInfo : Window
    {
        static EditOrderInfo newWin;
        static string result;
        public EditOrderInfo()
        {
            InitializeComponent();
        }
        public static string Show(int x)
        {
            newWin = new EditOrderInfo();
            if (x == 1)
            {
                newWin.GroupTrack.Visibility = Visibility.Visible;
            }
            else if (x == 2)
            {
                newWin.GroupStatus.Visibility = Visibility.Visible;
            }
            newWin.ShowDialog();
            return result;
        }

        private void btnOne(object sender, RoutedEventArgs e)
        {
            result = "Новый";
            Close();
        }

        private void btnTwo(object sender, RoutedEventArgs e)
        {
            result = "Ждёт отправления";
            Close();
        }

        private void btnThree(object sender, RoutedEventArgs e)
        {
            result = "Отправлен";
            Close();
        }

        private void btnFour(object sender, RoutedEventArgs e)
        {
            result = "Получите на почте";
            Close();
        }

        private void editNum(object sender, RoutedEventArgs e)
        {
            result = txtTrack.Text;
            Close();
        }
    }
}
