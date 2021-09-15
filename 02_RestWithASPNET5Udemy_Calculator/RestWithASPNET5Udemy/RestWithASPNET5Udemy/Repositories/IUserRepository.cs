using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Model;

namespace RestWithASPNET5Udemy.Repositories
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User RefreshUserInfo(User user);
    }
}
 