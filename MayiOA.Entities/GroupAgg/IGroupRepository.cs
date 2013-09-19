using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayiOA.Entities.Data;

namespace MayiOA.Entities.GroupAgg
{
    public interface IGroupRepository
    {
        IEnumerable<Groups> GetGroupsByUserID(int userid);

        Groups GetGroupByID(int groupid);

        bool SaveGroup(Groups group);

        bool DeleteGroup(Groups group);
    }
}
