using BusinessLogic.Interfaces;
using DAL.Interfaces;

namespace BusinessLogic.Concrete
{
    public class AdminManager:IAdminManager
    {
        private readonly ICommentDal _commentDal;
        private readonly ITopicDal _topicDal;
        private readonly IUserDal _userDal;
           
        public AdminManager(ICommentDal commentDal, ITopicDal topicDal, IUserDal userDal)
        {
            _commentDal = commentDal;
            _topicDal = topicDal;
            _userDal = userDal;
        }



    }
}
