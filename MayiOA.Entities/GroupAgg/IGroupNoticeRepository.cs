using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayiOA.Entities.Data;

namespace MayiOA.Entities.GroupAgg
{
    public interface IGroupNoticeRepository
    {
        GroupNotice GetNoticeByGroupID(int groupid);

        bool SaveNotice(GroupNotice notice);

        bool DeleteNotice(GroupNotice notice);
    }
}
