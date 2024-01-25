using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginWhiteSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly UserContext _userContext;
        public MainWindow()
        {
            InitializeComponent();
            _userContext = new UserContext("AppData");
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void mimi_btn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void log_btn_Click(object sender, RoutedEventArgs e)
        {
            string username = txt_box.Text;
            string password = pass_box.Password;

            var user = _userContext.Users.FirstOrDefault(t => t.UserFullname == username && t.UserPassword == password);
            if(user != null) {
                
                MainWindow main = new MainWindow();
                main.Show();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}

