using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.view
{
    interface IMemberWindow
    {
        IEnumerable ShowData { get; set; }
        object DefaulData { get; set;  }
        string Search { get; set; }
        int Id { get; set; }
        int SelectedIndex { get; set; }
    }
}
