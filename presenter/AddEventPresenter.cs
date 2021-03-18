using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CheckInByQRCode.presenter
{
    class AddEventPresenter
    {
        IAddEventWindow addEventWindow;

        public AddEventPresenter(IAddEventWindow addEventWindow)
        {
            this.addEventWindow = addEventWindow;
        }

        public bool AddEvent()
        {
            if (addEventWindow.EventName.Length == 0)
            {
                addEventWindow.Status = "Event name is empty";
                return false;
            }
            if (addEventWindow.EventName.Length > 50)
            {
                addEventWindow.Status = "Event name have lenght lower than 50";
                return false;
            }
            EventDao eventDao = new EventDao();
            eventDao.MakeConnection(Properties.Resources.strConnection);
            return eventDao.Create(new EventDto(addEventWindow.EventName, addEventWindow.Desciption,"", ((App)Application.Current).UserName));
        }

    }
}
