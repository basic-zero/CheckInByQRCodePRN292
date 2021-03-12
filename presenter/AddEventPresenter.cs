using CheckInByQRCode.view;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.presenter
{
    class AddEventPresenter
    {
        IAddEventWindow addEventWindow;

        public AddEventPresenter(IAddEventWindow addEventWindow)
        {
            this.addEventWindow = addEventWindow;
        }

    }
}
