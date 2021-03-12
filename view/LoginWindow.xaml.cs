using CheckInByQRCode.presenter;
using CheckInByQRCode.view;
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

namespace CheckInByQRCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, ILoginWindow
    {
        private bool drag = false; // determine if we should be moving the form
        private Point startPoint = new Point(0, 0); // also for the moving

        public string UserName { get { if (tcMainTab.SelectedIndex == 0) { return txtUserName.Text; } else { return txtUserNameSignUp.Text; }  }  set { if (tcMainTab.SelectedIndex == 0) { txtUserName.Text = value; } else { txtUserNameSignUp.Text = value; } } }
        public string Password { get { if (tcMainTab.SelectedIndex == 0) { return txtPassword.Password; } else { return txtPasswordSignUp.Password; } } set { if (tcMainTab.SelectedIndex == 0) { txtPassword.Password = value; } else { txtPasswordSignUp.Password = value; } } }
        public string Fullname { get => txtFullnameSignUp.Text; set => txtFullnameSignUp.Text=value; }
        public string Email { get => txtEmailSignUp.Text; set =>txtEmailSignUp.Text=value; }
        public int TabIndex { get => tcMainTab.SelectedIndex; set=> tcMainTab.SelectedIndex= value; }
        public LoginWindow()
        {
            InitializeComponent();

        }


        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void btnMinimize_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnGotoSignUp_Click(object sender, RoutedEventArgs e)
        {
            LoginPresenter loginPresenter = new LoginPresenter(this);
            loginPresenter.ChangeTab();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSignInWithGoogle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
        