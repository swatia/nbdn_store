namespace nothinbutdotnetstore.presentation.stubs
{
    public class StubUserStore : UserStore
    {
        EditProfileDetail details;

        public StubUserStore() : this(create_a_fake_user())
        {
        }

        static EditProfileDetail create_a_fake_user()
        {
            return new EditProfileDetail
            {
                EmailAddress = "blah@hotmail.com",
                FirstName = "JP",
                LastName = "Boodhoo"
            };
        }

        public StubUserStore(EditProfileDetail details)
        {
            this.details = details;
        }

        public bool received_a_call { get; set; }

        public EditProfileDetail get_the_current_user_details()
        {
            received_a_call = true;
            return details;
        }
    }
}