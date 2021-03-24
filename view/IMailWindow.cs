using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInByQRCode.view
{
    interface IMailWindow
    {
        string Subject { get; set; }
        string MailContent { get; set; }
        object EmailData { get; set; }
        string Status { get; set; }
        string EventId { get; set; }
    }
}
