using CheckInByQRCode.view;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.presenter
{
    class LoginPresenter
    {
        ILoginWindow loginWindow;

        public LoginPresenter(ILoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;
        }

        public void ChangeTab()
        {
            if (loginWindow.TabIndex == 0) { loginWindow.TabIndex = 1; } else loginWindow.TabIndex = 0;
        }
    }
}
