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
    /// Interaction logic for AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window, IAddEventWindow
    {
        private object groupData;
        public string EventName { get => txtEventName.Text; set => txtEventName.Text=value; }
        public string Desciption { get => txtDesciption.Text; set => txtDesciption.Text= value; }
        public IEnumerable Group { get => lsbGroup.ItemsSource; set => lsbGroup.ItemsSource= value; }
        public string Status { get => txtStatus.Text; set => txtStatus.Text = value; }
        public object GroupData { get => groupData; set => groupData = value; }
        public AddEventWindow()
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

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            AddEventPresenter addEventPresenter = new AddEventPresenter(this);
            if (addEventPresenter.AddEvent())
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddEventPresenter addEventPresenter = new AddEventPresenter(this);
            addEventPresenter.LoadGroup();
        }
    }
}
