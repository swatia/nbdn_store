namespace nothinbutdotnetstore.presentation
{
    public interface EditProfileView : IEditProfileDetail
    {
        bool IsPostBack { get; }
    }
}