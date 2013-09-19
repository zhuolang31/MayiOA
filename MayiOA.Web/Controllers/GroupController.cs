using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MayiOA.Entities.Data;
using MayiOA.Entities.GroupAgg;
using MayiOA.Web.Models;

namespace MayiOA.Web.Controllers
{
    public class GroupController : ApiController
    {
        private MayiOAEntities db = new MayiOAEntities();

        private IGroupRepository repository;

        public GroupController()
        {
            repository = new GroupRepository(db);
        }

        // GET api/Group?userid=
        public IEnumerable<Groups> GetGroups(int userid)
        {
            return repository.GetGroupsByUserID(userid);
        }

        // GET api/Group/5
        public Groups GetGroup(int id)
        {
            Groups groups = repository.GetGroupByID(id);
            if (groups == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return groups;
        }

        // PUT api/Group/5
        public HttpResponseMessage PutGroups(int id, Groups groups)
        {
            if (ModelState.IsValid && id == groups.GroupID)
            {
                try
                {
                    repository.SaveGroup(groups);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Group
        public HttpResponseMessage PostGroups(Groups groups)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGroup(groups);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, groups);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = groups.GroupID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Group/5
        public HttpResponseMessage DeleteGroups(int id)
        {
            Groups group = repository.GetGroupByID(id);
            try
            {
                repository.DeleteGroup(group);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, group);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}