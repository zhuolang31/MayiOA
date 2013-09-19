using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MayiOA.Entities.Data;
using MayiOA.Entities.UserAgg;
using MayiOA.Entities;
using MayiOA.Core.Infrastructure;

namespace MayiOA.Web.Models
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }

        public Users GetUserByUserName(string userName)
        {
            return this.GetQuery<Users>().First(x => x.Username == userName);
        }

        public Users GetUserByUserID(int userid)
        {
            return this.GetQuery<Users>().First(x => x.UserID == userid);
        }

        public IEnumerable<Users> SearchUsersByName(int clientid, string fullName)
        {
            return this.GetQuery<Users>().Where(x =>x.ClientID == clientid && x.FullName.Contains(fullName));
        }

        public bool ValidateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool SaveUser(Users user)
        {
            if (user.UserID > 0)
            {
                this.Update(user);
            }
            else
            {
                this.Add(user);
            }

            this.UnitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteUser(Users user)
        {
            this.Delete(user);

            this.UnitOfWork.SaveChanges();

            return true;
        }
    }   
}