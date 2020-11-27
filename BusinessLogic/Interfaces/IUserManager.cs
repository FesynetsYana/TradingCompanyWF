using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserManager
    {
        List<UserDTO> GetAll();
        List<UserDTO> Find(string fullName);
        List<UserDTO> GetSort(string column = "FullName");
        UserDTO Add(UserDTO user);//changed
        void Delete(int id);
    }
}
