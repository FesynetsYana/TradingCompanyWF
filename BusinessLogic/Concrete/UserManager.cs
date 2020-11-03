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
    abstract public class UserManager
    {
        public bool addRemovePermitions { set; get; }

        protected UserDal userDal;
        protected TopicDal topicDal;
        protected CommentDal commentDal;

        protected UserDTO currentUser;
        public UserManager(UserDTO user)
        {
            currentUser = user;
            userDal = new UserDal(user.Email);
            topicDal = new TopicDal(user.Email);
            commentDal = new CommentDal(user.Email);
        }
        public List<(long ID, string FullName, string Title, string Text)> Find(string str)
        {
            return GetJoinAll(topicDal.Find(str));
        }


        public  List<(long ID, string FullName, string Title, string Text)> GetAll()
        {
            var topics = topicDal.GetAll();


            return GetJoinAll(topics);
        }

        protected List<(long ID, string FullName, string Title, string Text)> GetJoinAll(List<TopicDTO> topics)
        {
            var users = userDal.GetAll();
            var comments = commentDal.GetAll();

            var res = from ts in topics
                      join us in users on ts.UsersID equals us.IDUser
                      join cs in comments on ts.CommentID equals cs.ID
                      select new { ID = ts.ID, FullName = us.FullName, Title = ts.Title, Text = ts.Text, Comment = cs.CommentText };
            List<(long ID, string FullName, string Title, string Text)> ls = new List<(long ID, string FullName, string Title, string Text)>();
            foreach (var i in res)
            {
                Console.WriteLine($"{i.ID} {i.FullName} \nTitle: {i.Title} \nText: {i.Text}");
                ls.Add((i.ID, i.FullName, i.Title, i.Text));
            }

            return ls;
        }
        public abstract bool AddTopic(string title_, string text_, string comment_);
        public abstract long DeleteTopic(long id);
    }
}
