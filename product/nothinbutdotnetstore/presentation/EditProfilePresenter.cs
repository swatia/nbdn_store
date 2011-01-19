using nothinbutdotnetstore.presentation.stubs;

namespace nothinbutdotnetstore.presentation
{
    public class EditProfilePresenter
    {
        EditProfileView view;
        UserStore user_store;

        public EditProfilePresenter(EditProfileView view):this(view,
            new StubUserStore())
        {
        }

        public EditProfilePresenter(EditProfileView view, UserStore user_store)
        {
            this.view = view;
            this.user_store = user_store;
        }

        public void initialize()
        {
            var the_current_user_details = user_store.get_the_current_user_details();
            view.display(the_current_user_details);
        }
    }
}