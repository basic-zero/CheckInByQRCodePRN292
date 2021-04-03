using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace CheckInByQRCode.presenter
{
    class CheckInPresenter
    {
        ICheckInWindow checkInWindow;

        public CheckInPresenter(ICheckInWindow checkInWindow)
        {
            this.checkInWindow = checkInWindow;
        }

        public void LoadMemberEvent()
        {
            CheckInDao checkInDao = new CheckInDao();
            checkInDao.MakeConnection(Properties.Resources.strConnection);
            checkInWindow.MemberInEventData = checkInDao.ReadData(checkInWindow.EventID, "");
            List<CheckBox> checkInShowList = new List<CheckBox>();
            int count = 1;
            foreach (CheckInDto checkInDto in checkInDao.ReadData(checkInWindow.EventID, ""))
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = checkInDto.Name + " | " + checkInDto.Email;
                checkBox.IsChecked = checkInDto.Check;
                checkInShowList.Add(checkBox);
                count++;
            }
            checkInWindow.MemberInEventShow = checkInShowList;
        }
        
        public void SubmitCheckIn()
        {
            EventDao eventDao = new EventDao();
            eventDao.MakeConnection(Properties.Resources.strConnection);
            eventDao.UpdateStatus(checkInWindow.EventID, "checked in");
            CheckInDao checkInDao = new CheckInDao();
            checkInDao.MakeConnection(Properties.Resources.strConnection);
            List<CheckInDto> checkInDtos = (List<CheckInDto>)checkInWindow.MemberInEventData;
            List<CheckBox> checkBoxes = (List<CheckBox>)checkInWindow.MemberInEventShow;
            foreach (CheckInDto checkInDto in checkInDtos )
            {
                checkInDao.UpdateStatus(checkInDto.EventAttendeesID, (bool)checkBoxes[checkInDtos.IndexOf(checkInDto)].IsChecked);

            }

        }


        public void CheckIn()
        {
            BitmapSource srs = (BitmapSource)checkInWindow.ImageSource;
            Bitmap bitmap = null;
            if (srs != null)
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    BitmapEncoder enc = new BmpBitmapEncoder();

                    enc.Frames.Add(BitmapFrame.Create(srs));
                    enc.Save(outStream);
                    bitmap = new Bitmap(outStream);
                }
            }
            try
            {
                String content = QRModuleLib.QRModule.DecodeFromQRCode(bitmap);
                DataEncryption dataEncryption = new DataEncryption(null, content);
                content = dataEncryption.InputCode;
                if (content == null)
                {
                    checkInWindow.Status = "Waiting....";
                }
                else
                {
                    CheckInDao checkInDao = new CheckInDao();
                    checkInDao.MakeConnection(Properties.Resources.strConnection);
                    try
                    {
                        int id = int.Parse(content);
                        CheckInDto checkInDto = checkInDao.CheckInByAttendeesID(id);
                        if (checkInDto.Check)
                        {
                            checkInWindow.Status = "QR code is checked!";
                        }
                        else
                        {
                            checkInDao.UpdateStatus(id, true);
                            LoadMemberEvent();
                            checkInWindow.Status = checkInDto.Name;
                        }
                    }
                    catch
                    {
                        checkInWindow.Status = "QR code is not existed!";
                    }
                }

            }
            catch (NullReferenceException ex)
            {
                checkInWindow.Status = "Waiting";
            }

        }
    }
}
