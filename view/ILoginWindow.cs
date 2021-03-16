using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CheckInByQRCode.view
{
    interface ILoginWindow
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Fullname { get; set; }
        string RePassword { get; set;}
        string Status { get; set; }
        string StatusSignUp { get; set; }
        int TabIndex { get; set; }
        Visibility Hidden { set; }
    }
}
