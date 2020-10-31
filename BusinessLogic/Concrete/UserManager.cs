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
        protected UserDal userDal;
        protected TopicDal topicDal;
        protected CommentDal commentDal;

        protected UserDTO currentUser;
        public UserManager(UserDTO user)
        {
            userDal = new UserDal(user.Email);
            topicDal = new TopicDal(user.Email);
            commentDal = new CommentDal(user.Email);
        }
        public abstract void Find(string str);
        //public abstract List<(long ID, string FullName, string Title, string Text)> GetAll();

       
        public  List<(long ID, string FullName, string Title, string Text)> GetAll()
        {
            var topics = topicDal.GetAll();


            return GetJoinAll(topics);
        }
        public virtual void PrintSorted()
        {
            
        }
        //public abstract List<(long ID, string FullName, string Title, string Text)> GetJoinAll(List<TopicDTO> topics);

        public List<(long ID, string FullName, string Title, string Text)> GetJoinAll(List<TopicDTO> topics)
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
        public virtual void AddUser()
        {
          
        }
    }
}
