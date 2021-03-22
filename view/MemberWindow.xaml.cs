using CheckInByQRCode.presenter;
using System;
using System.Collections;
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
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window, IMemberWindow
    {
        private object defaulData;
        private int id;
        public IEnumerable ShowData { get => gvData.ItemsSource; set => gvData.ItemsSource=value; }
        public object DefaulData { get => defaulData; set => defaulData = value; }
        public string Search { get => txtSearch.Text; set => txtSearch.Text=value; }
        public int Id { get => id; set => id = value; }
        public int SelectedIndex { get => gvData.SelectedIndex; set => gvData.SelectedIndex=value; }

        public MemberWindow(string action)
        {
            InitializeComponent();
            txtAction.Text = action;
            if(action.Equals("Group member"))
            {
                btnProcess.Visibility = Visibility.Hidden;
            }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (txtAction.Text.Equals("Group member"))
            {
                MemberPresenter memberPresenter = new MemberPresenter(this);
                memberPresenter.LoadMemberGroup();
            }
        }

        private void gvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnShowDeleteDialog.IsEnabled = gvData.SelectedIndex >= 0;
            btnUpdate.IsEnabled = gvData.SelectedIndex >= 0;
            btnProcess.IsEnabled = gvData.SelectedIndex >= 0;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtAction.Text.Equals("Group member"))
            {
                MemberPresenter memberPresenter = new MemberPresenter(this);
                memberPresenter.RemoveEventAttendees();
                memberPresenter.LoadMemberGroup();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAction.Text.Equals("Group member"))
            {
                MemberPresenter memberPresenter = new MemberPresenter(this);
                memberPresenter.LoadMemberGroup();
            }
        }
    }
}
