using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.presenter
{
    class MemberPresenter
    {
        IMemberWindow memberWindow;

        public MemberPresenter(IMemberWindow memberWindow)
        {
            this.memberWindow = memberWindow;
        }

        public void LoadMemberGroup()
        {
            EventAttendeesDao eventAttendeesDao = new EventAttendeesDao();
            eventAttendeesDao.MakeConnection(Properties.Resources.strConnection);
            memberWindow.DefaulData = eventAttendeesDao.ReadData(memberWindow.Id, memberWindow.Search);
            List<dynamic> eventAttendeesShowList = new List<dynamic>();
            int count = 1;
            foreach (EventAttendeesDto eventAttendeesDto in eventAttendeesDao.ReadData(memberWindow.Id, memberWindow.Search))
            {
                eventAttendeesShowList.Add(new { NO = count, Name = eventAttendeesDto.Name, Email = eventAttendeesDto.Email, Other= eventAttendeesDto.Other });
                count++;
            }
            memberWindow.ShowData = eventAttendeesShowList;
        }

        public void RemoveEventAttendees()
        {
            EventAttendeesDao eventAttendeesDao = new EventAttendeesDao();
            eventAttendeesDao.MakeConnection(Properties.Resources.strConnection);
            List<EventAttendeesDto> eventAttendeesDtos = (List<EventAttendeesDto>)memberWindow.DefaulData;
            eventAttendeesDao.DeleteById(eventAttendeesDtos[memberWindow.SelectedIndex].Id);
        }

        public void ShowAddEventAttendeesDialog()
        {
            DetailMemberWindow detailMemberWindow = new DetailMemberWindow("Add member in group");
            detailMemberWindow.Id = memberWindow.Id;
            detailMemberWindow.ShowDialog();
        }

        public void ShowUpdateEventAttendeesDialog()
        {
            DetailMemberWindow detailMemberWindow = new DetailMemberWindow("Update member in group");
            List<EventAttendeesDto> eventAttendeesDtos = (List<EventAttendeesDto>)memberWindow.DefaulData;
            detailMemberWindow.Id = eventAttendeesDtos[memberWindow.SelectedIndex].Id;
            detailMemberWindow.DataName = eventAttendeesDtos[memberWindow.SelectedIndex].Name;
            detailMemberWindow.Email = eventAttendeesDtos[memberWindow.SelectedIndex].Email;
            detailMemberWindow.Other = eventAttendeesDtos[memberWindow.SelectedIndex].Other;
            detailMemberWindow.ShowDialog();
        }
    }
}
