using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

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
                ((App)Application.Current).FullName = name;
                ((App)Application.Current).UserName = loginWindow.UserName;
                MainWindow mainWindow = new MainWindow();
                loginWindow.Hidden = System.Windows.Visibility.Hidden;
                mainWindow.ShowDialog();
                return true;
            }
            loginWindow.Status = "Account not exist";
            return false;
        }

        public bool AddUser()
        {
            if (loginWindow.Fullname.Length == 0)
            {
                loginWindow.StatusSignUp = "Fullname is empty";
                return false;
            }
            if (loginWindow.UserName.Length == 0)
            {
                loginWindow.StatusSignUp = "Username is empty";
                return false;
            }
            if (loginWindow.UserName.Length <= 7 || loginWindow.UserName.Length > 50)
            {
                loginWindow.StatusSignUp = "Username have length from 8 to 50";
                return false;
            }
            if (loginWindow.Password.Length == 0)
            {
                loginWindow.StatusSignUp = "Password is empty";
                return false;
            }
            if (loginWindow.Password.Length <= 7 || loginWindow.UserName.Length > 30)
            {
                loginWindow.StatusSignUp = "Password have length from 8 to 30";
                return false;
            }
            if (!loginWindow.RePassword.Equals(loginWindow.Password))
            {
                loginWindow.StatusSignUp = "Confirm password fail";
                return false;
            }
            UserDao userDao = new UserDao();
            userDao.MakeConnection(Properties.Resources.strConnection);
            UserDto user = new UserDto(loginWindow.Fullname, loginWindow.UserName, loginWindow.Password);
            if (userDao.Create(user))
            {
                ((App)Application.Current).FullName = loginWindow.Fullname;
                ((App)Application.Current).UserName = loginWindow.UserName;
                MainWindow mainWindow = new MainWindow();
                loginWindow.Hidden = System.Windows.Visibility.Hidden;
                mainWindow.ShowDialog();
                return true;
            }
            loginWindow.Status = "Account is exist";
            return false;
        }
    }
}
