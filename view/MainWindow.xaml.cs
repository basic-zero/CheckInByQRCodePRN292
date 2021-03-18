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
        private DataTable eventTable = null;
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
        public DataTable EventTable { get => eventTable; set => eventTable= value; }

        public MainWindow()
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
        }

        private void txtSearchEvent_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainPresenter mainPresenter = new MainPresenter(this);
            mainPresenter.SearchEvent();
        }
    }
}
