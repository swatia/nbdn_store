using System;
using nothinbutdotnetstore.presentation.stubs;

namespace nothinbutdotnetstore.presentation
{
    public class EditProfilePresenter
    {
        EditProfileView view;
        UserStore user_store;
        UserManager user_manager;

        public EditProfilePresenter(EditProfileView view):this(view,
            new StubUserStore(), null)
        {
        }

        public EditProfilePresenter(EditProfileView view, UserStore user_store, UserManager user_manager)
        {
            this.view = view;
            this.user_store = user_store;
            this.user_manager = user_manager;
        }

        public void initialize()
        {
            if (view.IsPostBack) return;

            var the_current_user_details = user_store.get_the_current_user_details();
            update_view_using(the_current_user_details);

        }

        void update_view_using(EditProfileDetail the_current_user_details)
        {
            view.FirstName = the_current_user_details.FirstName;
        }

        public void save()
        {
            var details = user_store.get_the_current_user_details();
            details.FirstName = view.FirstName;
            user_manager.save(details);
        }
    }
}