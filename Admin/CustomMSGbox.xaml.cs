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
using System.Windows.Forms;

namespace Admin
{
    /// <summary>
    /// Логика взаимодействия для CustomMSGbox.xaml
    /// </summary>
    public partial class CustomMSGbox : Window
    {
        public CustomMSGbox()
        {
            InitializeComponent();
        }
        static CustomMSGbox cMSGbox;
        static DialogResult result = System.Windows.Forms.DialogResult.No;
        public enum MsgButtons
        {
            Ок,
            Нет,
            Да,
            Отмена
        }
        public enum MsgTitle
        {
            Ошибка,
            Инфо,
            Внимание,
            Вопрос
        }
        public static DialogResult Show(string message, MsgTitle title, MsgButtons btnOk, MsgButtons btnNo)
        {
            cMSGbox = new CustomMSGbox();
            cMSGbox.txtMsg.Text = message;
            cMSGbox.btnOk.Content = cMSGbox.GetMessageButton(btnOk);
            cMSGbox.btnNo.Content = cMSGbox.GetMessageButton(btnNo);
            cMSGbox.TitleName.Text = cMSGbox.GetTitle(title);

            switch (title)
            {
                case MsgTitle.Ошибка:
                    cMSGbox.iconMsg.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
                    cMSGbox.iconMsg.Foreground = (Brush)new BrushConverter().ConvertFrom("#F0403A");
                    cMSGbox.btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MsgTitle.Инфо:
                    cMSGbox.iconMsg.Kind = MaterialDesignThemes.Wpf.PackIconKind.Information;
                    cMSGbox.iconMsg.Foreground = (Brush)new BrushConverter().ConvertFrom("#FAF844");
                    cMSGbox.btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MsgTitle.Внимание:
                    cMSGbox.iconMsg.Kind = MaterialDesignThemes.Wpf.PackIconKind.Warning;
                    cMSGbox.iconMsg.Foreground = (Brush)new BrushConverter().ConvertFrom("#40A1F5");
                    break;
                case MsgTitle.Вопрос:
                    cMSGbox.iconMsg.Kind = MaterialDesignThemes.Wpf.PackIconKind.QuestionMark;
                    cMSGbox.iconMsg.Foreground = (Brush)new BrushConverter().ConvertFrom("#ffffff");
                    break;
            }
            cMSGbox.ShowDialog();
            return result;
        }
        public string GetTitle(MsgTitle value)
        {
            return Enum.GetName(typeof(MsgTitle), value);
        }

        public string GetMessageButton(MsgButtons value)
        {
            return Enum.GetName(typeof(MsgButtons), value);
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.No;
            Close();
        }

        private void GridDrag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.Yes;
            Close();
        }
    }
}
