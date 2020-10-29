using BusinessLogic.Interfaces;
using DAL.Interfaces;

namespace BusinessLogic.Concrete
{
    public class AuthManager: IAuthManager
    {
            private readonly IUserDal _userDal;
            public AuthManager(IUserDal userDal)
            {
                _userDal = userDal;
            }
            public bool Login(string username, string password)
            {
                return _userDal.Login(username, password);
            }
    }
}
