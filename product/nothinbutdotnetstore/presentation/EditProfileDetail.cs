namespace nothinbutdotnetstore.presentation
{
    public class EditProfileDetail : IEditProfileDetail
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }

        public string MiddleInitial { get; set; }

        public string UserName { get; set; }
    }
}