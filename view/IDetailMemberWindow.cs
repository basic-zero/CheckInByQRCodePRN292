using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.view
{
    interface IDetailMemberWindow
    {
        string DataName { get; set; }
        string Email { get; set; }
        string Other { get; set; }
        string Status { get; set; }
        int Id { get; set; }
    }
}
