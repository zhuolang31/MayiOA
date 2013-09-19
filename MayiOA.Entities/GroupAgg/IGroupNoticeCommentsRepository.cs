using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayiOA.Entities.Data;


namespace MayiOA.Entities.GroupAgg
{
    public interface IGroupNoticeCommentsRepository
    {
        IEnumerable<GroupNoticeComments> GetCommentsByNoticeID(int noticeid);

        bool SaveComment(GroupNoticeComments comment);

        bool DeleteComment(GroupNoticeComments comment);
    }
}
