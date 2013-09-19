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
    public class GroupRepository : GenericRepository, IGroupRepository
    {
        public GroupRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<Groups> GetGroupsByUserID(int userid)
        {
            return this.GetQuery<Groups>().Where(x=>x.CreateUserID == userid);
        }

        public Groups GetGroupByID(int groupid)
        {
            return this.GetQuery<Groups>().First(x => x.GroupID == groupid);
        }

        public bool SaveGroup(Groups group)
        {
            if (group.GroupID > 0)
            {
                this.Update(group);
            }
            else
            {
                this.Add(group);
            }

            this.UnitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteGroup(Groups group)
        {
            this.Delete(group);

            this.UnitOfWork.SaveChanges();

            return true;
        }
    }
}