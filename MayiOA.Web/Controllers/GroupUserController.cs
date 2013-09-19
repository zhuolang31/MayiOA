using MayiOA.Entities.Data;
using MayiOA.Entities.GroupAgg;
using MayiOA.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MayiOA.Web.Controllers
{
    public class GroupUserController : ApiController
    {
        private MayiOAEntities db = new MayiOAEntities();

        private IGroupUserRepository repository;

        public GroupUserController()
        {
            repository = new GroupUserRepository(db);
        }

        //GET api/GroupUser
        public IEnumerable<GroupUsers> GetGroupUsers(int groupid)
        {
            return repository.GetGroupUsers(groupid);
        }

        // POST api/GroupUser
        public HttpResponseMessage PostUsers(GroupUsers groupUser)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGroupUser(groupUser);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, groupUser);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = groupUser.UserID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        //Delete api/GroupUser?groupid=&userid=
        public HttpResponseMessage DeleteGroupUser(int groupid, int userid)
        {
            GroupUsers groupUser = repository.GetGroupUser(groupid,userid);
            try
            {
                repository.DeleteGroupUser(groupUser);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, groupUser);
        }

    }
}
