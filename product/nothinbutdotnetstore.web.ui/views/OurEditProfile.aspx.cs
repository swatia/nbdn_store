using System;
using System.Web.UI;
using nothinbutdotnetstore.presentation;

namespace nothinbutdotnetstore.web.ui.views
{
    public partial class OurEditProfile : Page, EditProfileView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new EditProfilePresenter(this).initialize();
        }

        public void display(EditProfileDetail current_user_details)
        {
            txtFirstName.Text = current_user_details.FirstName;
        }
    }
}