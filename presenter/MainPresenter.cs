using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
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
            mainWindow.EventData = eventDao.ReadData(((App)Application.Current).UserName, mainWindow.SearchEvent);
            List<dynamic> eventShowList = new List<dynamic>();
            int count = 1;
            foreach(EventDto eventDto in eventDao.ReadData(((App)Application.Current).UserName, mainWindow.SearchEvent))
            {
                eventShowList.Add(new { NO=count, Name= eventDto.Name, Description= eventDto.Description});
                count++;
            }
            mainWindow.DataEvent = eventShowList;
        }

        public void RemoveEvent()
        {
                EventDao eventDao = new EventDao();
                eventDao.MakeConnection(Properties.Resources.strConnection);
                List<EventDto> events = (List<EventDto>)mainWindow.EventData;
                eventDao.DeleteById(events[mainWindow.SelectIndexEvent].Id);
        }

    }
}
