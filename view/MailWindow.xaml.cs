using CheckInByQRCode.presenter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CheckInByQRCode.view
{
    /// <summary>
    /// Interaction logic for MailWindow.xaml
    /// </summary>
    public partial class MailWindow : Window, IMailWindow
    {
        private object emailData;
        private string eventId;
        public string Subject { get => txtSubject.Text; set => txtSubject.Text=value; }
        string IMailWindow.MailContent { get => txtContent.Text; set => txtContent.Text=value; }
        public object EmailData { get => emailData; set => emailData= value; }
        public string EventId { get => eventId; set => eventId=value; }
        public string Status { get => txtStatus.Text; set => txtStatus.Text=value; }

        public MailWindow()
        {
            InitializeComponent();
        }

        private void btnClose_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnAcepct_Click(object sender, RoutedEventArgs e)
        {
            pbrSendMail.Visibility = Visibility.Visible;
            txtContent.IsEnabled = false;
            txtSubject.IsEnabled = false;
            btnAcepct.IsEnabled = false;
            btnCancel.IsEnabled = false;
            MailPresenter mailPresenter = new MailPresenter(this);
            if (mailPresenter.SendMail())
            {
                this.DialogResult = true;
                this.Close();
            }
            txtContent.IsEnabled = true;
            txtSubject.IsEnabled = true;
            btnAcepct.IsEnabled = true;
            btnCancel.IsEnabled = true;
            pbrSendMail.Visibility = Visibility.Hidden;
        }
    }
}
