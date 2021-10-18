using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using new_project.Models;
using System.Data.Entity;

namespace new_project.Controllers
{
    public class ValuesController : ApiController
    {
        private Model1 db = new Model1();


        ////GET api/values/5
        [HttpGet]
        [Route("~/api/MyEntityData")]
        public IEnumerable<MyEntity> MyEntityData()
        {
            var data = db.MyEntities;
            return data;
        }
        [HttpGet]
        [Route("~/api/mycity")]
        public IHttpActionResult Getmycity()
        {
            var data = db.Mycities;
            return Ok(data);
        }

        /// <summary>
        /// /////////
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/MyEntityTryData")]
        public IHttpActionResult MyEntityTryData()
        {
            try
            {
                var data = db.MyEntities;
                return Ok(data);
            } catch (Exception ex) {

                CustomRuspons error = new CustomRuspons() { stutus = "hhhh", code = 404, msg = ex.Message };

                return Ok(error);
        }
        }

        // POST api/values
        [HttpPost]
        [Route("~/api/PostEntityData")]
        public IHttpActionResult PostEntityData( MyEntity ent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.MyEntities.Add(ent);
                    db.SaveChanges();

                }
                return Ok(ent);

            }
            catch (Exception ex)
            {

                CustomRuspons error = new CustomRuspons() { stutus = "hhhh", code = 404, msg = ex.Message };

                return Ok(error);
            }
        }

        // PUT api/values/5
        [HttpPut]
        [Route("~/api/putEntityData")]
        public IHttpActionResult putEntityData(MyEntity ent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ent).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return Ok(ent);

            }
            catch (Exception ex)
            {

                CustomRuspons error = new CustomRuspons() { stutus = "hhhh", code = 404, msg = ex.Message };

                return Ok(error);
            }
        }
        // DELETE api/values/5
        // PUT api/values/5
        [HttpDelete]
        [Route("~/api/DeleteEntityData/{id}")]
        public IHttpActionResult DeleteEntityData(int id)
        {
            try
            {
                var Data = db.MyEntities.Find(id);
                db.MyEntities.Remove(Data);
                db.SaveChanges();

                
                return Ok(Data);

            }
            catch (Exception ex)
            {

                CustomRuspons error = new CustomRuspons() { stutus = "hhhh", code = 404, msg = ex.Message };

                return Ok(error);
            }
        }
    }
}
