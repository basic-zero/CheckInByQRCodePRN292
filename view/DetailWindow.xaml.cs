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
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window, IDetailWindow
    {
        private int id;
        public DetailWindow(string action)
        {
            InitializeComponent();
            txtAction.Text = action;
            if(action.Split(' ')[0].Equals("Add"))
            {
                btnAcepct.Content = "Add";
            }
            else
            {
                btnAcepct.Content = "Update";
            }
        }

        public string DetailName { get => txtName.Text; set => txtName.Text=value; }
        public string Desciption { get => txtDesciption.Text; set => txtDesciption.Text=value; }
        public string Action { get => txtAction.Text; set => txtAction.Text = value; }
        public string Status { get => txtStatus.Text; set => txtStatus.Text= value; }
        public int Id { get => id; set => id = value; }

        private void btnClose_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }


        private void btnAcepct_Click(object sender, RoutedEventArgs e)
        {
            if(txtAction.Text.Equals("Update event"))
            {
                DetailPresenter detailPresenter = new DetailPresenter(this);
                if(detailPresenter.UpdateEvent())
                {
                    this.Close();
                }
                return;
            }
            if (txtAction.Text.Equals("Add group"))
            {
                DetailPresenter detailPresenter = new DetailPresenter(this);
                if (detailPresenter.AddGroup())
                {
                    this.Close();
                }
                return;
            }
            if (txtAction.Text.Equals("Update group"))
            {
                DetailPresenter detailPresenter = new DetailPresenter(this);
                if (detailPresenter.UpdateGroup())
                {
                    this.Close();
                }
                return;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
