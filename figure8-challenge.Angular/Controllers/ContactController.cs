using Figure8Challenge.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetsAlone.Core;

namespace Figure8Challenge.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly Figure8ChallengeContext _dbContext;
        private readonly IContactDetails _contactDetails;
        public ContactController(Figure8ChallengeContext dbContext, IContactDetails contactDetails)
        {
            _dbContext = dbContext;
            _contactDetails = contactDetails;

        }

        [HttpGet("contacts")]
        public object GetAllContact()
        {
            try
            {
                var result = _contactDetails.GetAllContact(_dbContext);
                return result;
            }
            catch (System.Exception ex)
            {
                return BadRequest("Error Occurred");
            }
        }

        [HttpGet("contact/{id:long}")]
        public object GetContact(long Id)
        {
            try
            {
                var result = _contactDetails.GetContactById(_dbContext, Id);
                return result;
            }
            catch (System.Exception ex)
            {
                return BadRequest("Error Occurred");
            }
        }

        [HttpPost("create")]
        public object CreateContact([FromBody] ContactDetails model)
        {
            try
            {
                var result = _contactDetails.CreateContact(_dbContext, model);
                return result;
            }
            catch (System.Exception ex)
            {
                return BadRequest("Error Occurred");
            }
        }

        [HttpPut("update/{id:long}")]
        public object UpdateContact([FromBody] ContactDetails model, long Id)
        {
            try
            {
                var result = _contactDetails.UpdateContact(_dbContext, model, Id);
                return result;
            }
            catch (System.Exception ex)
            {
                return BadRequest("Error Occurred");
            }
        }


        [HttpDelete("delete/{id:long}")]
        public object DeleteContact( long Id)
        {
            try
            {
                var result = _contactDetails.DeleteContact(_dbContext, Id);
                return result;
            }
            catch (System.Exception ex)
            {
                return BadRequest("Error Occurred");
            }
        }
    }

}
