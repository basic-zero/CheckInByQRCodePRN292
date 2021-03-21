using CheckInByQRCode.view;
using DatabaseAss.dao;
using DatabaseAss.dto;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
