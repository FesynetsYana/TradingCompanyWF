using System;
using BusinessLogic.Concrete;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTests
{
    [TestClass]
    public class UserManagerTests
    {

        private string connectionString = "Data Source=localhost;Initial Catalog=ManagerNews;Integrated Security=True";
        string login = "1";

        [TestMethod]
        public void FindTopic()
        {
            UserDTO user = new UserDTO();
            user.Email = connectionString;
            user.Login = login;
            user.Password = login;

            UserManager um = new AdminManager(user);
            var gl = um.Find("Title");

            Assert.IsTrue(gl.Count == 0 || gl[0].ID != -1);

        }

        [TestMethod]
        public void GetAllTopic()
        {
            UserDTO user = new UserDTO();
            user.Email = connectionString;
            user.Login = login;
            user.Password = login;
            UserManager um = new AdminManager(user);

            var gl = um.GetAll();

            Assert.IsTrue(gl.Count == 0 || gl[0].ID != -1);
        }

      [TestMethod]
        public void AddTopic()
        {
            UserDTO user = new UserDTO();
            user.Email = connectionString;
            user.Login = login;
            user.Password = login;
            user.IDUser = -1;
            UserManager um = new AdminManager(user);

            TopicDal a = new TopicDal(connectionString);
            TopicDTO top = new TopicDTO();
            top.ID = -1;
            top.Title = "Title";
            top.Text = "text";
            top.CommentID = 99999999;
            var res = um.AddTopic("Topic", "Text", "Comm");
            Assert.IsTrue(res);
        }

        [TestMethod]

        public void DeleteTopic()
        {
            UserDTO user = new UserDTO();
            user.Email = connectionString;
            user.Login = login;
            user.Password = login;
            user.IDUser = -1;
            UserManager um = new AdminManager(user);

            var res = um.DeleteTopic(3);
            Assert.IsTrue(res != -1);


        }
    }
}
