using System;
using System.Windows.Forms;
using nothinbutdotnetstore.presentation;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form,EditProfileView
    {
        public Form1()
        {
            InitializeComponent();
            new EditProfilePresenter(this).initialize();
        }

        public bool IsPostBack
        {
            get { return false; }
        }

        public void display(EditProfileDetail current_user_details)
        {
            ux_first_name.Text = current_user_details.FirstName;
        }
    }
}