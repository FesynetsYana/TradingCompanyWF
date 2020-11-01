using System;
using DTO;
using DAL.Concrete;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AdminManager : UserManager
    {

        public AdminManager(UserDTO user) : base(user)
        {
            addRemovePermitions = true;
        }

        public override bool AddUser(string title_, string text_, string comment_)
        {
            TopicDTO topic = new TopicDTO();

            topic.UsersID = currentUser.IDUser;

            topic.Title = title_;
            topic.Text = text_;

            CommentDTO comment = new CommentDTO();

            comment.CommentText = comment_;
            comment.UsersID = currentUser.IDUser;
            comment.CommentTime = DateTime.Now;

            commentDal.Add(comment);

            var comms = commentDal.Find(comment.CommentText);

            topic.CommentID = comms[0].ID;
            topicDal.Add(topic);
            return true;
        }
        public override long RemoveUser(long id)
        {
            return topicDal.Delete(id);
        }

    }
}
