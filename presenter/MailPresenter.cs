using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.presenter
{
    class MailPresenter
    {
        IMailWindow mailWindow;

        public MailPresenter(IMailWindow mailWindow)
        {
            this.mailWindow = mailWindow;
        }

        public bool SendMail()
        {
            if (mailWindow.Subject.Length == 0)
            {
                mailWindow.Status = "Subject is empty";
                return false;
            }
            if (mailWindow.MailContent.Length == 0)
            {
                mailWindow.Status = "Content is empty";
                return false;
            }
            List<CheckInDto> checkInDtos = (List<CheckInDto>)mailWindow.EmailData;
            foreach(CheckInDto checkInDto in checkInDtos)
            {
                try
                {
                    DataEncryption dataEncryption = new DataEncryption(checkInDto.EventAttendeesID.ToString(),null);
                    QRModuleLib.QRModule.CreateQRCode(dataEncryption.OutputCode, checkInDto.EventAttendeesID + ".png", mailWindow.EventId);
                    EmailLibrary.Email.SendEMail(Properties.Resources.email, Properties.Resources.password, checkInDto.Email, mailWindow.Subject, mailWindow.MailContent, mailWindow.EventId + "/" + checkInDto.EventAttendeesID + ".png");
                }
                catch
                {
                    mailWindow.Status = "Something email address is not exits";
                    return false;
                }
               
            }
            EventDao eventDao = new EventDao();
            eventDao.MakeConnection(Properties.Resources.strConnection);
            eventDao.UpdateStatus(int.Parse(mailWindow.EventId), "sended mail");
            return true;
        }
    }
}
