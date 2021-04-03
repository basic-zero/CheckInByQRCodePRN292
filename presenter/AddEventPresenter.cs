using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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
                addEventWindow.Status = "Event name have length lower than 50";
                return false;
            }
            EventDao eventDao = new EventDao();
            eventDao.MakeConnection(Properties.Resources.strConnection);
            if(eventDao.Create(new EventDto(addEventWindow.EventName, addEventWindow.Desciption,"", ((App)Application.Current).UserName)))
            {
                List<CheckBox> groupShowList = (List<CheckBox>)addEventWindow.Group;
                int index = 0;
                foreach(CheckBox checkBox in groupShowList)
                {
                    if ((bool)checkBox.IsChecked)
                    {
                        EventAttendeesDao eventAttendeesDao = new EventAttendeesDao();
                        List<GroupDto> groupDtos = (List<GroupDto>)addEventWindow.GroupData;
                        eventAttendeesDao.MakeConnection(Properties.Resources.strConnection);
                        List<EventAttendeesDto> eventAttendeesDtos = eventAttendeesDao.ReadData(groupDtos[index].Id, "");
                        foreach(EventAttendeesDto eventAttendeesDto in eventAttendeesDtos)
                        {
                            CheckInDao checkInDao = new CheckInDao();
                            checkInDao.MakeConnection(Properties.Resources.strConnection);
                            CheckInDto checkInDto = new CheckInDto();
                            checkInDto.EventID = eventDao.GetLastId();
                            checkInDto.Name = eventAttendeesDto.Name;
                            checkInDto.Email = eventAttendeesDto.Email;
                            checkInDto.Other = eventAttendeesDto.Other;
                            checkInDao.Create(checkInDto);
                        }
                    }
                    index++;
                }
            }
            return true;
        }

        public void LoadGroup()
        {
            GroupDao groupDao = new GroupDao();
            groupDao.MakeConnection(Properties.Resources.strConnection);
            addEventWindow.GroupData = groupDao.LoadListGroupName(((App)Application.Current).UserName);
            List<CheckBox> groupShowList = new List<CheckBox>();
            int count = 1;
            foreach (GroupDto groupDto in groupDao.LoadListGroupName(((App)Application.Current).UserName))
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = count + " " + groupDto.Name; 
                groupShowList.Add(checkBox);
                count++;
            }
            addEventWindow.Group = groupShowList;
        }

    }
}
