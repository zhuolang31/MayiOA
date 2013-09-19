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
    public class GroupNoticeRepository : GenericRepository , IGroupNoticeRepository
    {
        public GroupNoticeRepository(DbContext context)
            : base(context)
        {
        }

        public GroupNotice GetNoticeByGroupID(int groupid)
        {
            return this.Single<GroupNotice>(x => x.GroupID == groupid && x.SoftDelete == false);
        }

        public bool SaveNotice(GroupNotice notice)
        {
            if (notice.GroupNoticeID > 0)
            {
                this.Update(notice);
            }
            else
            {
                this.Add(notice);
            }

            this.UnitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteNotice(GroupNotice notice)
        {
            this.Delete(notice);

            this.UnitOfWork.SaveChanges();

            return true;
        }
    }
}