using CheckInByQRCode.presenter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IMainWindow
    {
        private object eventData = null;
        private object groupData = null;
        private object oldEventData = null;
        public bool EventHasSelect { get => gvEvent.SelectedIndex >= 0; }
        public int SelectIndexEvent { get => gvEvent.SelectedIndex; set => gvEvent.SelectedIndex=value; }
        public int SelectIndexGroup { get => gvGroup.SelectedIndex; set => gvGroup.SelectedIndex=value; }
        public int SelectIndexOldEvent { get => gvOldEvent.SelectedIndex; set => gvOldEvent.SelectedIndex=value; }
        public string SearchEvent { get => txtSearchEvent.Text; set => txtSearchEvent.Text=value; }
        public string SearchGroup { get => txtSearchGroup.Text; set => txtSearchGroup.Text=value; }
        public string SearchOldEvent { get => txtSearchOldEvent.Text; set => txtSearchOldEvent.Text=value; }
        public IEnumerable DataEvent { get => gvEvent.ItemsSource; set => gvEvent.ItemsSource=value; }
        public IEnumerable DataGroup { get => gvGroup.ItemsSource; set => gvGroup.ItemsSource=value; }
        public IEnumerable DataOldEvent { get => gvOldEvent.ItemsSource; set => gvOldEvent.ItemsSource=value; }
        public Visibility Hidden { set => this.Visibility=value; }
        public object EventData { get => eventData; set => eventData=value; }
        public object GroupData { get => groupData; set => groupData=value; }
        public object OldEventData { get => oldEventData; set => oldEventData=value; }
        public int TabIndexOfMenu { get => tcMainTab.SelectedIndex; set => tcMainTab.SelectedIndex=value; }

        public MainWindow()
        {
            InitializeComponent();
            txtTitle.Text = "Check in by QR code - " + ((App)Application.Current).FullName;
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
            this.Close();
        }

        private void btnLogout_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.Logout();
            this.Close();
        }



        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.ShowAddEvent();
            mainPresenter.LoadEvent();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.LoadEvent();
            mainPresenter.LoadGroup();
            mainPresenter.LoadOldEvent();
        }

        private void txtSearchEvent_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.LoadEvent();
        }

        private void btnDeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.RemoveEvent();
            mainPresenter.LoadEvent();
        }

        private void gvEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnShowDeleteDialogEvent.IsEnabled = gvEvent.SelectedIndex >= 0;
            btnUpdateEvent.IsEnabled = gvEvent.SelectedIndex >= 0;
            btnProcessEvent.IsEnabled = gvEvent.SelectedIndex >= 0;
        }

        private void btnUpdateEvent_Click(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.ShowUpdateEvent();
            mainPresenter.LoadEvent();
        }

        private void gvGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnShowDeleteDialogGroup.IsEnabled = gvGroup.SelectedIndex >= 0;
            btnUpdateGroup.IsEnabled = gvGroup.SelectedIndex >= 0;
            btnProcessGroup.IsEnabled = gvGroup.SelectedIndex >= 0;
        }

        private void btnDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.RemoveGroup();
            mainPresenter.LoadGroup();
        }

        private void txtSearchGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.LoadGroup();
        }

        private void btnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.ShowAddGroup();
            mainPresenter.LoadGroup();
        }

        private void btnUpdateGroup_Click(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.ShowUpdateGroup();
            mainPresenter.LoadGroup();
        }

        private void btnProcessGroup_Click(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.ShowMemberInGroupDialog();
        }

        private void btnProcessEvent_Click(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.ShowProcessEvent();
            mainPresenter.LoadEvent();
        }

        private void btnExportReport_Click(object sender, RoutedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
           
            mainPresenter.ExportReportToExcel();
        }

        private void txtSearchOldEvent_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.LoadOldEvent();
        }

        private void gvOldEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnExportReport.IsEnabled = gvOldEvent.SelectedIndex >= 0;
        }

    }
}
