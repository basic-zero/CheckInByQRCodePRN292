using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CheckInByQRCode.view
{
    interface ICheckInWindow
    {
        string Status { get; set; }
        Object MemberInEventData { get; set; }
        IEnumerable MemberInEventShow { get; set; }
        int EventID { get; set; }
        ImageSource ImageSource { get; set; }
        Object SelectedCheckInItem { get; set; }
    }
}
