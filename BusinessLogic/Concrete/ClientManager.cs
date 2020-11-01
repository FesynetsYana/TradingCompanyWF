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
    public class ClientManager : UserManager
    {
        public ClientManager(UserDTO user) : base(user) 
        {
            addRemovePermitions = false;
        }
            
        public override bool AddUser(string title_, string text_, string comment_)
        {
            return false;
        }
        public override long RemoveUser(long id)
        {
            return -1;
        }
    }
}
