namespace Mc2.CrudTest.Presentation.Client.ServiceModel
{
    public interface IUserAuthService
    {
        Task Login(string token);
        Task Logout();
    }
}
