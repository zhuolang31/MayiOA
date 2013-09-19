using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayiOA.Entities.Data;

namespace MayiOA.Entities.GroupAgg
{
    public interface IGroupUserRepository
    {
        IEnumerable<GroupUsers> GetGroupUsers(int groupid);

        GroupUsers GetGroupUser(int groupid, int userid);

        bool SaveGroupUser(GroupUsers groupUser);

        bool DeleteGroupUser(GroupUsers groupUser);
    }
}
