using CheckInByQRCode.view;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CheckInByQRCode.presenter
{
    class MainPresenter
    {
        IMainWindow mainWindow;

        public MainPresenter(IMainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Logout()
        {
            LoginWindow loginWindow = new LoginWindow();
            mainWindow.Hidden = Visibility.Hidden;
            loginWindow.ShowDialog();
        }

        public void ShowAddEvent()
        {
            AddEventWindow addEventWindow = new AddEventWindow();
            addEventWindow.ShowDialog();
        }

    }
}
