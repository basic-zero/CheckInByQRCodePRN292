using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.view
{
    interface IAddEventWindow
    {
        string EventName { get; set; }

        string Desciption { get; set; }

        IEnumerable Group { get; set; }

        string Status { get; set; }

        object GroupData { get; set; }
    }
}
