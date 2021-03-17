using CheckInByQRCode.view;
using DatabaseAss.dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.presenter
{
    class LoginPresenter
    {
        ILoginWindow loginWindow;

        public LoginPresenter(ILoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;
            loginWindow.Status = "";
            loginWindow.StatusSignUp = "";
        }

        public void ChangeTab()
        {
            if (loginWindow.TabIndex == 0) { loginWindow.TabIndex = 1; } else loginWindow.TabIndex = 0;
        }

        public bool Login()
        {
            if(loginWindow.UserName.Length==0)
            {
                loginWindow.Status = "Username is empty";
                return false;
            }
            if (loginWindow.UserName.Length <= 7 || loginWindow.UserName.Length > 50)
            {
                loginWindow.Status = "Username have lenght from 8 to 50";
                return false;
            }
            if (loginWindow.Password.Length == 0)
            {
                loginWindow.Status = "Password is empty";
                return false;
            }
            if (loginWindow.Password.Length <= 7 || loginWindow.UserName.Length > 30)
            {
                loginWindow.Status = "Password have lenght from 8 to 30";
                return false;
            }
            UserDao userDao = new UserDao();
            userDao.MakeConnection(Properties.Resources.strConnection);
            string name = userDao.CheckLogin(loginWindow.UserName, loginWindow.Password);
            if (name.Length!=0)
            {
                MainWindow mainWindow = new MainWindow(loginWindow.UserName);
                IMainWindow main = mainWindow;
                main.FullName = name;
                loginWindow.Hidden = System.Windows.Visibility.Hidden;
                mainWindow.ShowDialog();
                return true;
            }
            loginWindow.Status = "Account not exist";
            return false;
        }

        
    }
}
