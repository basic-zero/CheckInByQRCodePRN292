using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

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

        public void LoadMemberEvent()
        {
            CheckInDao checkInDao = new CheckInDao();
            checkInDao.MakeConnection(Properties.Resources.strConnection);
            memberWindow.DefaulData = checkInDao.ReadData(memberWindow.Id, memberWindow.Search);
            List<dynamic> checkInShowList = new List<dynamic>();
            int count = 1;
            foreach (CheckInDto checkInDto in checkInDao.ReadData(memberWindow.Id, memberWindow.Search))
            {
                checkInShowList.Add(new { NO = count, Name = checkInDto.Name, Email = checkInDto.Email, Other = checkInDto.Other });
                count++;
            }
            memberWindow.ShowData = checkInShowList;
        }


        public void RemoveEventAttendees()
        {
            EventAttendeesDao eventAttendeesDao = new EventAttendeesDao();
            eventAttendeesDao.MakeConnection(Properties.Resources.strConnection);
            List<EventAttendeesDto> eventAttendeesDtos = (List<EventAttendeesDto>)memberWindow.DefaulData;
            eventAttendeesDao.DeleteById(eventAttendeesDtos[memberWindow.SelectedIndex].Id);
        }

        public void RemoveCheckIn()
        {
            CheckInDao checkInDao = new CheckInDao();
            checkInDao.MakeConnection(Properties.Resources.strConnection);
            List<CheckInDto> checkInDtos = (List<CheckInDto>)memberWindow.DefaulData;
            checkInDao.DeleteById(checkInDtos[memberWindow.SelectedIndex].EventAttendeesID);
        }

        public void ShowAddEventAttendeesDialog()
        {
            DetailMemberWindow detailMemberWindow = new DetailMemberWindow("Add member in group");
            detailMemberWindow.Id = memberWindow.Id;
            detailMemberWindow.ShowDialog();
        }

        public void ShowAddCheckInDialog()
        {
            DetailMemberWindow detailMemberWindow = new DetailMemberWindow("Add member in event");
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

        public void ShowUpdateCheckInDialog()
        {
            DetailMemberWindow detailMemberWindow = new DetailMemberWindow("Update member in event");
            List<CheckInDto> checkInDtos = (List<CheckInDto>)memberWindow.DefaulData;
            detailMemberWindow.Id = checkInDtos[memberWindow.SelectedIndex].EventAttendeesID;
            detailMemberWindow.DataName = checkInDtos[memberWindow.SelectedIndex].Name;
            detailMemberWindow.Email = checkInDtos[memberWindow.SelectedIndex].Email;
            detailMemberWindow.Other = checkInDtos[memberWindow.SelectedIndex].Other;
            detailMemberWindow.ShowDialog();
        }

        public bool ShowMailDialog()
        {
            List<CheckInDto> checkInDtos = (List<CheckInDto>)memberWindow.DefaulData;
            if (checkInDtos.Count > 0)
            {
                MailWindow mailWindow = new MailWindow();
                mailWindow.EmailData = memberWindow.DefaulData;
                mailWindow.EventId = memberWindow.Id.ToString();
                return (bool)mailWindow.ShowDialog();
            }
            return false;
        }

        public void ImportDataFromExcel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
            if ((bool)openFileDialog.ShowDialog())
            {
                try
                {
                    ExcelConnection.ExcelConnect excelConnect = new ExcelConnection.ExcelConnect();
                    List<EventAttendeesDtoExcel> eventAttendeesDtoExcels = excelConnect.ImportExcel<EventAttendeesDtoExcel>(openFileDialog.FileName);
                    EventAttendeesDao eventAttendeesDao = new EventAttendeesDao();
                    eventAttendeesDao.MakeConnection(Properties.Resources.strConnection);
                    foreach (EventAttendeesDtoExcel eventAttendeesDtoExcel in eventAttendeesDtoExcels)
                    {
                        EventAttendeesDto eventAttendeesDto = new EventAttendeesDto();
                        eventAttendeesDto.Name = eventAttendeesDtoExcel.Name;
                        eventAttendeesDto.Email = eventAttendeesDtoExcel.Email;
                        eventAttendeesDto.Other = eventAttendeesDtoExcel.Other;
                        eventAttendeesDto.GroupID = memberWindow.Id;
                        eventAttendeesDao.Create(eventAttendeesDto);
                    }
                }
               catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }
    }
}
