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

        public void ShowAddGroup()
        {
            DetailWindow detailWindow = new DetailWindow("Add group");
            detailWindow.ShowDialog();
        }

        public void ShowUpdateEvent()
        {
            DetailWindow detailWindow = new DetailWindow("Update event");
            IDetailWindow detail = detailWindow;
            List<EventDto> events = (List<EventDto>)mainWindow.EventData;
            detail.DetailName = events[mainWindow.SelectIndexEvent].Name;
            detail.Desciption = events[mainWindow.SelectIndexEvent].Description;
            detail.Id = events[mainWindow.SelectIndexEvent].Id;
            detailWindow.ShowDialog();
        }

        public void ShowUpdateGroup()
        {
            DetailWindow detailWindow = new DetailWindow("Update group");
            IDetailWindow detail = detailWindow;
            List<GroupDto> groups = (List<GroupDto>)mainWindow.GroupData;
            detail.DetailName = groups[mainWindow.SelectIndexGroup].Name;
            detail.Desciption = groups[mainWindow.SelectIndexGroup].Description;
            detail.Id = groups[mainWindow.SelectIndexGroup].Id;
            detailWindow.ShowDialog();
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

        public void LoadGroup()
        {
            GroupDao groupDao = new GroupDao();
            groupDao.MakeConnection(Properties.Resources.strConnection);
            mainWindow.GroupData = groupDao.ReadData(((App)Application.Current).UserName, mainWindow.SearchGroup);
            List<dynamic> groupShowList = new List<dynamic>();
            int count = 1;
            foreach (GroupDto groupDto in groupDao.ReadData(((App)Application.Current).UserName, mainWindow.SearchGroup))
            {
                groupShowList.Add(new { NO = count, Name = groupDto.Name, Description = groupDto.Description });
                count++;
            }
            mainWindow.DataGroup = groupShowList;
        }

        public void RemoveEvent()
        {
                EventDao eventDao = new EventDao();
                eventDao.MakeConnection(Properties.Resources.strConnection);
                List<EventDto> events = (List<EventDto>)mainWindow.EventData;
                eventDao.DeleteById(events[mainWindow.SelectIndexEvent].Id);
        }

        public void RemoveGroup()
        {
            GroupDao groupDao = new GroupDao();
            groupDao.MakeConnection(Properties.Resources.strConnection);
            List<GroupDto> groups = (List<GroupDto>)mainWindow.GroupData;
            groupDao.DeleteById(groups[mainWindow.SelectIndexGroup].Id);
        }

        public void ShowMemberInGroupDialog()
        {
            MemberWindow memberWindow = new MemberWindow("Group member");
            IMemberWindow member = (IMemberWindow)memberWindow;
            List<GroupDto> groups = (List<GroupDto>)mainWindow.GroupData;
            member.Id = groups[mainWindow.SelectIndexGroup].Id;
            memberWindow.ShowDialog();
        }
        public void ShowMemberInEventDialog()
        {
            MemberWindow memberWindow = new MemberWindow("Event member");
            IMemberWindow member = (IMemberWindow)memberWindow;
            List<EventDto> events = (List<EventDto>)mainWindow.EventData;
            member.Id = events[mainWindow.SelectIndexEvent].Id;
            memberWindow.ShowDialog();
        }
    }
}
