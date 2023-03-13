using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

namespace Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient httpClient = new HttpClient();
        //MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btn_auth_Click(object sender, RoutedEventArgs e)
        {
            //if (tb_login.Text == "asd" && pb_pass.Password == "asd")
            //{
            //    var bw = new BasicWindow(); bw.Show();
            //    this.Close();
            //}

            if (Validation())
            {
                var user = new User()
                {
                    Login = loginBox.Text,
                    Password = passBox.Password,
                    Access = "Admin"
                };

                using var response = await httpClient.PostAsJsonAsync("https://localhost:7236/log/", user);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    user = await response.Content.ReadFromJsonAsync<User>();
                    if (user.Access == "Admin")
                    {
                        var bw = new BasicWindow(); bw.Show(); this.Close();
                        return;
                    }
                }
                CustomMSGbox.Show("Неверно введён логин или пароль!", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Отмена);
            }
        }

        bool Validation()
        {
            if (loginBox.Text.Length < 6 || passBox.Password.Length < 6)
            {
                CustomMSGbox.Show("Поля не могут быть пустыми или содержать меньше 6 символов", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Отмена);
                return false;
            }
            return true;
        }
    }
}
