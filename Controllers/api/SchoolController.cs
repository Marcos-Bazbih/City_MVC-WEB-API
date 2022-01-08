using City_MVC_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace City_MVC_WEB_API.Controllers.api
{
    public class SchoolController : ApiController
    {
        static string stringConnection = "Data Source=LENOVO-MARCOS;Initial Catalog=CityDb;Integrated Security=True;Pooling=False";
        DataClasses1DataContext CityDataContext = new DataClasses1DataContext(stringConnection);



        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(CityDataContext.Schools.ToList());
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(CityDataContext.Schools.First((school) => school.Id == id));
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] School value)
        {
            try
            {
                CityDataContext.Schools.InsertOnSubmit(value);
                CityDataContext.SubmitChanges();
                return Ok("school added");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody] School value)
        {
            try
            {
                School updated = CityDataContext.Schools.First(school => school.Id == id);
                if (updated != null)
                {
                    updated.Name = value.Name;
                    updated.Street = value.Street;
                    updated.IsPublic = value.IsPublic;
                    updated.NumberOfStudents = value.NumberOfStudents;
                    
                    CityDataContext.SubmitChanges();
                    return Ok("School updated");
                }
                return Ok("Error - No School found");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                CityDataContext.Schools.DeleteOnSubmit(CityDataContext.Schools.First(school => school.Id == id));
                CityDataContext.SubmitChanges();
                return Ok("School deleted");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}