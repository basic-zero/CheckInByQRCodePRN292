using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace CheckInByQRCode.view
{
    interface IMainWindow
    {
        IEnumerable DataEvent { get; set; }
        IEnumerable DataGroup { get; set; }
        IEnumerable DataOldEvent { get; set; }

        int SelectIndexEvent { get; set; }
        int SelectIndexGroup { get; set; }
        int SelectIndexOldEvent { get; set; }

        string SearchEvent { get; set; }
        string SearchGroup { get; set; }
        string SearchOldEvent { get; set; }

        Visibility Hidden { set; }
        object EventData { get; set; }
        object GroupData { get; set; }
        object OldEventData { get; set; }

        int TabIndexOfMenu { get; set; }
    }
}
