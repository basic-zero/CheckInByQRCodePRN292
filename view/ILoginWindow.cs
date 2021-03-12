using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.view
{
    interface ILoginWindow
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Fullname { get; set; }
        string Email { get; set;}
        int TabIndex { get; set; }
    }
}
