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
    /// Interaction logic for DetailMemberWindow.xaml
    /// </summary>
    public partial class DetailMemberWindow : Window, IDetailMemberWindow
    {
        private int id;
        public string Email { get => txtEmail.Text; set => txtEmail.Text=value; }
        public string Other { get => txtOther.Text; set => txtOther.Text=value; }
        public string Status { get => txtStatus.Text; set => txtStatus.Text=value; }
        public string DataName { get => txtName.Text; set => txtName.Text=value; }
        public int Id { get => id; set => id=value; }

        public DetailMemberWindow(string action)
        {
            InitializeComponent();
            txtAction.Text = action;
            btnAcepct.Content = action.Split(' ')[0];
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
            this.Close();
        }

        private void btnAcepct_Click(object sender, RoutedEventArgs e)
        {
            if(txtAction.Text.Equals("Add member in group"))
            {
                DetailMemberPresenter detailMemberPresenter = new DetailMemberPresenter(this);
                if (detailMemberPresenter.AddMemberInGroup())
                {
                    this.Close();
                }
            }
            if (txtAction.Text.Equals("Update member in group"))
            {
                DetailMemberPresenter detailMemberPresenter = new DetailMemberPresenter(this);
                if (detailMemberPresenter.UpdateMemberInGroup())
                {
                    this.Close();
                }
            }

            if (txtAction.Text.Equals("Add member in event"))
            {
                DetailMemberPresenter detailMemberPresenter = new DetailMemberPresenter(this);
                if (detailMemberPresenter.AddMemberInEvent())
                {
                    this.Close();
                }
            }

            if (txtAction.Text.Equals("Update member in event"))
            {
                DetailMemberPresenter detailMemberPresenter = new DetailMemberPresenter(this);
                if (detailMemberPresenter.UpdateMemberInEvent())
                {
                    this.Close();
                }
            }
        }
    }
}
