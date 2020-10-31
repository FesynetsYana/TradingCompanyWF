//using System;
//using DTO;
//using DAL.Concrete;
//using DAL.Interfaces;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusinessLogic.Concrete
//{
//    public class ClientManager : UserManager
//    {
//        static private UserDal userDal;
//        static private TopicDal topicDal;
//        static private CommentDal commentDal;

//        static private UserDTO currentUser;
//        ////static uint TryCount = 3;
//        public override void Find(string str)
//        {
//            PrintJoinAll(topicDal.Find(str));
//        }
//        public override void PrintAll()
//        {
//            var topics = topicDal.GetAll();
//            PrintJoinAll(topics);
//        }
//        public override void PrintSorted()
//        {

//            var topics = topicDal.GetSort();
//            PrintJoinAll(topics);
//        }
//        public override void PrintJoinAll(List<TopicDTO> topics)
//        {
//            var users = userDal.GetAll();
//            var comments = commentDal.GetAll();

//            var res = from ts in topics
//                      join us in users on ts.UsersID equals us.IDUser
//                      join cs in comments on ts.CommentID equals cs.ID
//                      select new { ID = ts.ID, FullName = us.FullName, Title = ts.Title, Text = ts.Text, Comment = cs.CommentText };
//            foreach (var i in res)
//            {
//                Console.WriteLine($"{i.ID} {i.FullName} \nTitle: {i.Title} \nText: {i.Text}");
//            }
//        }
//        public override void AddUser()
//        {
//            TopicDTO topic = new TopicDTO();

//            topic.UsersID = currentUser.IDUser;

//            Console.Write("Please enter Title: ");
//            topic.Title = Console.ReadLine().ToString();

//            Console.Write("Please enter Text:");
//            topic.Text = Console.ReadLine().ToString();

//            CommentDTO comment = new CommentDTO();

//            Console.Write("Please enter Comment:");
//            comment.CommentText = Console.ReadLine().ToString();
//            comment.UsersID = currentUser.IDUser;
//            comment.CommentTime = DateTime.Now;

//            commentDal.Add(comment);

//            var comms = commentDal.Find(comment.CommentText);
//            if (comms.Count == 0)
//            {
//                Console.WriteLine("error!");
//            }
//            else
//            {

//                topic.CommentID = comms[0].ID;
//                Console.WriteLine(topic.CommentID.ToString());
//                topicDal.Add(topic);

//            }
//        }
//    }
//}
