using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.presenter
{
    class DetailMemberPresenter
    {
        IDetailMemberWindow detailMemberWindow;

        public DetailMemberPresenter(IDetailMemberWindow detailMemberWindow)
        {
            this.detailMemberWindow = detailMemberWindow;
        }

        public bool AddMemberInGroup()
        {
            if (detailMemberWindow.DataName.Length == 0)
            {
                detailMemberWindow.Status = "Member name is empty";
                return false;
            }
            if (!IsValidEmail(detailMemberWindow.Email))
            {
                detailMemberWindow.Status = "Email invalidate";
                return false;
            }
            EventAttendeesDao eventAttendeesDao = new EventAttendeesDao();
            eventAttendeesDao.MakeConnection(Properties.Resources.strConnection);
            EventAttendeesDto eventAttendeesDto = new EventAttendeesDto();
            eventAttendeesDto.Name = detailMemberWindow.DataName;
            eventAttendeesDto.Email = detailMemberWindow.Email;
            eventAttendeesDto.Other = detailMemberWindow.Other;
            eventAttendeesDto.GroupID = detailMemberWindow.Id;
            return eventAttendeesDao.Create(eventAttendeesDto);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateMemberInGroup()
        {
            if (detailMemberWindow.DataName.Length == 0)
            {
                detailMemberWindow.Status = "Member name is empty";
                return false;
            }
            if (!IsValidEmail(detailMemberWindow.Email))
            {
                detailMemberWindow.Status = "Email invalidate";
                return false;
            }
            EventAttendeesDao eventAttendeesDao = new EventAttendeesDao();
            eventAttendeesDao.MakeConnection(Properties.Resources.strConnection);
            EventAttendeesDto eventAttendeesDto = new EventAttendeesDto();
            eventAttendeesDto.Name = detailMemberWindow.DataName;
            eventAttendeesDto.Email = detailMemberWindow.Email;
            eventAttendeesDto.Other = detailMemberWindow.Other;
            eventAttendeesDto.Id = detailMemberWindow.Id;
            return eventAttendeesDao.Update(eventAttendeesDto);
        }

        public bool AddMemberInEvent()
        {
            if (detailMemberWindow.DataName.Length == 0)
            {
                detailMemberWindow.Status = "Member name is empty";
                return false;
            }
            if (!IsValidEmail(detailMemberWindow.Email))
            {
                detailMemberWindow.Status = "Email invalidate";
                return false;
            }
            CheckInDao checkInDao = new CheckInDao();
            checkInDao.MakeConnection(Properties.Resources.strConnection);
            CheckInDto checkInDto = new CheckInDto();
            checkInDto.Name = detailMemberWindow.DataName;
            checkInDto.Email = detailMemberWindow.Email;
            checkInDto.Other = detailMemberWindow.Other;
            checkInDto.EventID = detailMemberWindow.Id;
            return checkInDao.Create(checkInDto);
        }

        public bool UpdateMemberInEvent()
        {
            if (detailMemberWindow.DataName.Length == 0)
            {
                detailMemberWindow.Status = "Member name is empty";
                return false;
            }
            if (!IsValidEmail(detailMemberWindow.Email))
            {
                detailMemberWindow.Status = "Email invalidate";
                return false;
            }
            CheckInDao checkInDao = new CheckInDao();
            checkInDao.MakeConnection(Properties.Resources.strConnection);
            CheckInDto checkInDto = new CheckInDto();
            checkInDto.Name = detailMemberWindow.DataName;
            checkInDto.Email = detailMemberWindow.Email;
            checkInDto.Other = detailMemberWindow.Other;
            checkInDto.EventAttendeesID = detailMemberWindow.Id;
            return checkInDao.Update(checkInDto);
        }
    }
}
