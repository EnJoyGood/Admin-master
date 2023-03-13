using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Admin.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        HttpClient httpClient = new HttpClient();
        List<Order>? orders = new List<Order>();
        public OrderPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private async void LoadOrders() =>
            dg_order.ItemsSource = orders = await httpClient.GetFromJsonAsync<List<Order>>($"https://localhost:7236/order/");

        private async void TNumEdit(object sender, RoutedEventArgs e)
        {
            if (dg_order.SelectedItem != null)
            {
                var order = orders.FirstOrDefault(p => p.OrderId == (dg_order.SelectedItem as Order).OrderId);
                order.TrackNumber = EditOrderInfo.Show(1);
                await httpClient.PostAsJsonAsync($"https://localhost:7236/order/", order);
                searchTxt.Text = "";
                LoadOrders();
            }
            else
                CustomMSGbox.Show("Для изменения выберите заказ!", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);
        }

        private async void EditStat(object sender, RoutedEventArgs e)
        {
            if (dg_order.SelectedItem != null)
            {
                var order = orders.FirstOrDefault(p => p.OrderId == (dg_order.SelectedItem as Order).OrderId);
                order.Status = EditOrderInfo.Show(2);
                await httpClient.PostAsJsonAsync($"https://localhost:7236/order/", order);
                searchTxt.Text = "";
                LoadOrders();
            }
            else
                CustomMSGbox.Show("Для изменения выберите заказ!", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);
        }

        private async void DelOrder(object sender, RoutedEventArgs e)
        {
            if (dg_order.SelectedItem != null)
            {
                var order = orders.FirstOrDefault(p => p.OrderId == (dg_order.SelectedItem as Order).OrderId);
                await httpClient.DeleteAsync($"https://localhost:7236/order/{order.OrderId}");
                searchTxt.Text = "";
                LoadOrders();
            }
            else
                CustomMSGbox.Show("Для удалениея выберите заказ!", CustomMSGbox.MsgTitle.Ошибка, CustomMSGbox.MsgButtons.Ок, CustomMSGbox.MsgButtons.Нет);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchTxt.Text != "")
                dg_order.ItemsSource = orders.Where(p => p.OrderId == Convert.ToInt32(searchTxt.Text));
            else
                LoadOrders();
        }

        private void btn_cord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_delemp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cb_status_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ref_Click(object sender, RoutedEventArgs e)
        {
            LoadOrders();
        }
    }
}
