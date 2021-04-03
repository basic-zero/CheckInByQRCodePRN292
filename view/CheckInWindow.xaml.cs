using CheckInByQRCode.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebCamSharp;
using System.Timers;
namespace CheckInByQRCode.view
{
    /// <summary>
    /// Interaction logic for CheckInWindow.xaml
    /// </summary>
    public partial class CheckInWindow : Window,ICheckInWindow
    {
        private Object memberInEventData;
        private int eventID;
        public BitmapImage _image;
        public string Status { get => txtStatus.Text; set => txtStatus.Text=value; }
        public object MemberInEventData { get => memberInEventData; set => memberInEventData=value; }
        public IEnumerable MemberInEventShow { get => lbMember.ItemsSource; set => lbMember.ItemsSource=value; }
        public int EventID { get => eventID; set => eventID=value; }
        public ImageSource ImageSource { get => _image; set => _image= (BitmapImage)value; }
        public object SelectedCheckInItem { get => lbMember.SelectedItem; set => lbMember.SelectedItem=value; }

        public CheckInWindow()
        {
            InitializeComponent();
            
        }

        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void btnMinimize_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckInPresenter checkInPresenter = new CheckInPresenter(this);
            checkInPresenter.LoadMemberEvent();
            WebCam.StreamCapture del = StreamDelegateCallback;
            var cam = new WebCam(streamDelegate: del);
            
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            CheckInPresenter checkInPresenter = new CheckInPresenter(this);
            checkInPresenter.SubmitCheckIn();
            this.DialogResult = true;
            this.Close();
        }


        public void StreamDelegateCallback(MemoryStream ms)
        {
            Dispatcher.BeginInvoke(
                new ThreadStart(() =>
                {
                    _image = new BitmapImage();
                    _image.BeginInit();
                    ms.Seek(0, SeekOrigin.Begin);
                    _image.StreamSource = ms;
                    _image.EndInit();
                   imgMainStream.Source = _image;
                }

            ));
        }

        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            CheckInPresenter checkInPresenter = new CheckInPresenter(this);
            checkInPresenter.CheckIn();
        }
    }

}
