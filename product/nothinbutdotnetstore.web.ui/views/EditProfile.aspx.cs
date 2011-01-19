using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using nothinbutdotnetstore.presentation;

namespace nothinbutdotnetstore.web.ui.views
{
    public partial class EditProfile : Page, EditProfileView
    {
        protected TextBox txtEmailAddress;
        protected TextBox txtFirstName;
        EditProfilePresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new EditProfilePresenter(this);
            if (!Page.IsPostBack)
            {
                presenter.initialize();
            }
        }

        public void display(EditProfileDetail currentuser)
        {
                txtEmailAddress.Text = currentuser.EmailAddress;
                txtFirstName.Text = currentuser.FirstName;
        }

//        protected void btnSave_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                updateUser();
//
//                panMsg.Visible = true;
//                panMsg.CssClass = "infoMsg";
//                litMsg.Text = "Your user profile has been updated.";
//            }
//            catch (Exception ex)
//            {
//                panMsg.Visible = true;
//                panMsg.CssClass = "errorMsg";
//                litMsg.Text = "A problem has occurred while attempting to update your profile:<br>" + ex;
//            }
//        }
//
//        void updateUser()
//        {
//            var currentuser = ((IUser) (Session["userobject"]));
//            currentuser.EmailAddress = txtEmailAddress.Text;
//            currentuser.FirstName = txtFirstName.Text;
//            currentuser.Initials = txtInitials.Text;
//            currentuser.LastName = txtLastName.Text;
//            currentuser.MiddleInitial = txtMiddleInitial.Text;
//            currentuser.UserName = txtUsername.Text;
//            if (txtPassword.Text.Trim() != "")
//            {
//                currentuser.Password = txtPassword.Text;
//            }
//            currentuser.UpdatedBy = currentuser.UserName;
//            UserManager.UpdateUser(currentuser);
//        }
    }
}