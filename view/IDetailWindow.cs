using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.view
{
    interface IDetailWindow
    {
        string DetailName { get; set; }

        string Desciption { get; set; }

        string Action { get; set; }

        string Status { get; set; }

        int Id { get; set; }
    }
}
