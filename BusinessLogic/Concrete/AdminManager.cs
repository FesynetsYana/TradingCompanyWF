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
    public class AdminManager: UserManager
    {
        public AdminManager(UserDTO user) : base(user)
        {

        }
        public override void Find(string str)
        {
            GetJoinAll(base.topicDal.Find(str));
        }
        //public  override List<(long ID, string FullName, string Title, string Text)> GetAll()
        //{
        //    var topics = topicDal.GetAll();
                  

        //    return GetJoinAll(topics);
        //}
        public override void PrintSorted()
        { 
            var topics = topicDal.GetSort();
            GetJoinAll(topics);
        }
       // public override List<(long ID, string FullName, string Title, string Text)> GetJoinAll(List<TopicDTO> topics)
       //{
       //     var users = userDal.GetAll();
       //     var comments = commentDal.GetAll();

       //     var res = from ts in topics
       //               join us in users on ts.UsersID equals us.IDUser
       //               join cs in comments on ts.CommentID equals cs.ID
       //               select new { ID = ts.ID, FullName = us.FullName, Title = ts.Title, Text = ts.Text, Comment = cs.CommentText };
       //     List<(long ID, string FullName, string Title, string Text)> ls = new List<(long ID, string FullName, string Title, string Text)>();
       //     foreach (var i in res)
       //     {
       //         Console.WriteLine($"{i.ID} {i.FullName} \nTitle: {i.Title} \nText: {i.Text}");
       //         ls.Add((i.ID, i.FullName, i.Title, i.Text));
       //     }

       //     return ls;
       // }
        public override void AddUser()
        {
            TopicDTO topic = new TopicDTO();

            topic.UsersID = currentUser.IDUser; 

            Console.Write("Please enter Title: ");
            topic.Title = Console.ReadLine().ToString();

            Console.Write("Please enter Text:");
            topic.Text = Console.ReadLine().ToString();

            CommentDTO comment = new CommentDTO();

            Console.Write("Please enter Comment:");
            comment.CommentText = Console.ReadLine().ToString();
            comment.UsersID = currentUser.IDUser;
            comment.CommentTime = DateTime.Now;

            commentDal.Add(comment);

            var comms = commentDal.Find(comment.CommentText);
            if (comms.Count == 0)
            {
                Console.WriteLine("error!");
            }
            else
            {
                topic.CommentID = comms[0].ID;
                Console.WriteLine(topic.CommentID.ToString());
                topicDal.Add(topic);
            }
        }
    }
}
