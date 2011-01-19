namespace nothinbutdotnetstore.presentation.stubs
{
    public class StubUserStore : UserStore
    {
        public StubUserStore(EditProfileDetail details)
        {
            this.details = details;
        }

        public StubUserStore() : this(create_a_fake_user())
        {
        }

        EditProfileDetail details;

        static EditProfileDetail create_a_fake_user()
        {
            return new EditProfileDetail
            {
                EmailAddress = "blah@hotmail.com",
                FirstName = "JP",
                LastName = "Boodhoo"
            };
        }

        public bool received_a_call { get; set; }

        public EditProfileDetail get_the_current_user_details()
        {
            received_a_call = true;
            return details;
        }
    }
}