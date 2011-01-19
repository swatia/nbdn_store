namespace nothinbutdotnetstore.presentation
{
    public interface IEditProfileDetail
    {
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Initials { get; set; }
        string LastName { get; set; }
        string MiddleInitial { get; set; }
        string UserName { get; set; }
    }
}