using CheckInByQRCode.view;
using DatabaseAss.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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

        public void LoadEvent()
        {
            EventDao eventDao = new EventDao();
            eventDao.MakeConnection(Properties.Resources.strConnection);
            mainWindow.EventTable = eventDao.ReadData(((App)Application.Current).UserName);
            DataTable dataTable = eventDao.ReadData(((App)Application.Current).UserName);
            dataTable.Columns.RemoveAt(0);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                object[] newRow = {i+1, dataTable.Rows[i].ItemArray.GetValue(1), dataTable.Rows[i].ItemArray.GetValue(2) };
                dataTable.Rows[i].ItemArray = newRow;
            }
            mainWindow.DataEvent = (System.Collections.IEnumerable)dataTable.DefaultView;
        }

        public void SearchEvent()
        {
            DataTable dataTable = mainWindow.EventTable;
            dataTable.DefaultView.RowFilter = "name like '%" + mainWindow.SearchEvent+"%'";
            dataTable =((DataView) mainWindow.DataEvent).Table;
            dataTable.DefaultView.RowFilter = "name like '%" + mainWindow.SearchEvent + "%'";
        }

    }
}
