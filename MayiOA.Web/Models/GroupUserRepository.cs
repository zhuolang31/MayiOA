using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MayiOA.Entities.Data;
using MayiOA.Entities.GroupAgg;
using MayiOA.Entities;
using MayiOA.Core.Infrastructure;
using System.Data.Entity;

namespace MayiOA.Web.Models
{
    public class GroupUserRepository : GenericRepository, IGroupUserRepository
    {
        public GroupUserRepository(DbContext context)
            : base(context)
        {
        }

        public bool SaveGroupUser(GroupUsers groupUser)
        {
            if (this.FindOne<GroupUsers>(x=> x.UserID == groupUser.UserID && x.GroupID == groupUser.GroupID) != null)
            {
                this.Update(groupUser);
            }
            else
            {
                this.Add(groupUser);
            }

            this.UnitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteGroupUser(GroupUsers groupUser)
        {
            this.Delete(groupUser);

            this.UnitOfWork.SaveChanges();

            return true;
        }

        public IEnumerable<GroupUsers> GetGroupUsers(int groupid)
        {
            return this.GetQuery<GroupUsers>().Where(x => x.GroupID == groupid);
        }


        public GroupUsers GetGroupUser(int groupid, int userid)
        {
            return this.FindOne<GroupUsers>(x => x.GroupID == groupid && x.UserID == userid);
        }
    }
}