using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using nothinbutdotnetstore.presentation;

namespace nothinbutdotnetstore.web.ui.views
{
    public partial class OurEditProfile : Page, EditProfileView
    {
        protected Button ux_save;
        EditProfilePresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            hookup_event_handlers();
            presenter = new EditProfilePresenter(this);
            presenter.initialize();
        }

        void hookup_event_handlers()
        {
            ux_save.Click += delegate { presenter.save(); };
        }

        public string EmailAddress
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }

        public string Initials
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string LastName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string MiddleInitial
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string UserName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}