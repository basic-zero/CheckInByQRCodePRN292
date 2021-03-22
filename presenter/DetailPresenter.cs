using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CheckInByQRCode.presenter
{
    class DetailPresenter
    {
        IDetailWindow detailWindow;

        public DetailPresenter(IDetailWindow detailWindow)
        {
            this.detailWindow = detailWindow;
        }

        public bool UpdateEvent()
        {
            if (detailWindow.DetailName.Length == 0)
            {
                detailWindow.Status = "Event name is empty";
                return false;
            }
            EventDao eventDao = new EventDao();
            eventDao.MakeConnection(Properties.Resources.strConnection);
            EventDto eventDto = new EventDto();
            eventDto.Name = detailWindow.DetailName;
            eventDto.Description = detailWindow.Desciption;
            eventDto.Id = detailWindow.Id;
            return eventDao.Update(eventDto);
        }


        public bool UpdateGroup()
        {
            if (detailWindow.DetailName.Length == 0)
            {
                detailWindow.Status = "Group name is empty";
                return false;
            }
            GroupDao groupDao = new GroupDao();
            groupDao.MakeConnection(Properties.Resources.strConnection);
            GroupDto groupDto = new GroupDto();
            groupDto.Name = detailWindow.DetailName;
            groupDto.Description = detailWindow.Desciption;
            groupDto.Id = detailWindow.Id;
            return groupDao.Update(groupDto);
        }

        public bool AddGroup()
        {
            if (detailWindow.DetailName.Length == 0)
            {
                detailWindow.Status = "Group name is empty";
                return false;
            }
            GroupDao groupDao = new GroupDao();
            groupDao.MakeConnection(Properties.Resources.strConnection);
            GroupDto groupDto = new GroupDto();
            groupDto.Name = detailWindow.DetailName;
            groupDto.Description = detailWindow.Desciption;
            groupDto.UserID = ((App)Application.Current).UserName;
            return groupDao.Create(groupDto);
        }
    }
}
