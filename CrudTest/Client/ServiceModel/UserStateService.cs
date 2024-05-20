using Shared.Helper;
using System.Security.Claims;

namespace Mc2.CrudTest.Presentation.Client.ServiceModel
{
    public class UserStateService
    {
        private UserStateData _user { get; set; }
        
        public UserStateData GetUserInfo()
        {
            return _user;
        }
        public void SetUserInfo(IEnumerable<Claim> claims)
        {
            if (claims != null || claims.Count() == 0)
                return;
            _user = new UserStateData
            {
                Email = claims.Where(t => t.Type == ClaimTypes.Email).Select(t => t.Value).FirstOrDefault(),
                RoleName = claims.Where(t => t.Type == ClaimTypes.Role).Select(t => t.Value).FirstOrDefault(),
                FirstName = claims.Where(t => t.Type == "Name").Select(t => t.Value).FirstOrDefault(),
                LastName = claims.Where(t => t.Type == "LastName").Select(t => t.Value).FirstOrDefault(),
            };
        }

    }
}
