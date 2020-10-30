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
        public abstract void Find(string str);
        public abstract void PrintAll();
        public virtual void PrintSorted()
        {
            
        }
        public virtual  void PrintJoinAll(List<TopicDTO> topics)
        {
         
        }
        public virtual void AddUser()
        {
          
        }
    }
}
