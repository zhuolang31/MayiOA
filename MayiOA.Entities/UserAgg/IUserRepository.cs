using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayiOA.Entities.Data;

namespace MayiOA.Entities.UserAgg
{
    public interface IUserRepository
    {
        Users GetUserByUserName(string userName);

        Users GetUserByUserID(int userid);

        IEnumerable<Users> SearchUsersByName(int clientid, string fullName); 

        bool ValidateUser(string userName, string password);

        bool SaveUser(Users user);

        bool DeleteUser(Users user);

    }
}
