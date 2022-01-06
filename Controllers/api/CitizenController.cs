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
    public class CitizenController : ApiController
    {
        static string stringConnection = "Data Source=LENOVO-MARCOS;Initial Catalog=CityDb;Integrated Security=True;Pooling=False";
        DataClasses1DataContext CityDataContext = new DataClasses1DataContext(stringConnection);

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(CityDataContext.Citizens.ToList());
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
                return Ok(CityDataContext.Citizens.First((citizen) => citizen.Id == id));
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
        public IHttpActionResult Post([FromBody] Citizen value)
        {
            try
            {
                CityDataContext.Citizens.InsertOnSubmit(value);
                CityDataContext.SubmitChanges();
                return Ok("citizen added to city");
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
        public IHttpActionResult Put(int id, [FromBody] Citizen value)
        {
            try
            {
                Citizen updatedCitizen = CityDataContext.Citizens.First(citizen => citizen.Id == id);

                if (updatedCitizen != null)
                {
                    updatedCitizen.FirstName = value.FirstName;
                    updatedCitizen.LastName = value.LastName;
                    updatedCitizen.Birthday = value.Birthday;
                    updatedCitizen.Address = value.Address;
                    updatedCitizen.Seniority = value.Seniority;

                    CityDataContext.SubmitChanges();
                    return Ok("citizen updated");
                }
                return Ok("error - no citizen found");
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
                CityDataContext.Citizens.DeleteOnSubmit(CityDataContext.Citizens.First((citizen) => citizen.Id == id));
                CityDataContext.SubmitChanges();
                return Ok("citizen deleted");
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