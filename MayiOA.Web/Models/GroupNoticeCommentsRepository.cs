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
    public class GroupNoticeCommentsRepository : GenericRepository , IGroupNoticeCommentsRepository
    {
        public GroupNoticeCommentsRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<GroupNoticeComments> GetCommentsByNoticeID(int noticeid)
        {
            return this.GetQuery<GroupNoticeComments>(x => x.NoticeCommentID == noticeid);
        }

        public bool SaveComment(GroupNoticeComments comment)
        {
            if (comment.NoticeCommentID > 0)
            {
                this.Update(comment);
            }
            else
            {
                this.Add(comment);
            }

            this.UnitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteComment(GroupNoticeComments comment)
        {
            this.Delete(comment);

            this.UnitOfWork.SaveChanges();

            return true;
        }
    }
}