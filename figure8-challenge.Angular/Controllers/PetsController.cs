using Figure8Challenge.Core.LogicImplementations;
using Figure8Challenge.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace PetsAlone.Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly Figure8ChallengeContext _petsDbContext;
        public PetsController(Figure8ChallengeContext petsDbContext)
        {
            _petsDbContext = petsDbContext;
        }

        [HttpGet("all")]
        public object GetAll()
        {
            var petsService = new PetsService();
            var result = petsService.GetAll(_petsDbContext);
            return result;
        }

        [HttpGet("getpets/{petType}")]
        public  object GetFilterPets(int petType)
        {
            try
            {
                PetSearchField model = new PetSearchField()
                {
                    PetType = petType,
                };
                var petsService = new PetsService();
                var result = petsService.GetPetListBySearchField(_petsDbContext, model);
                return result;
            }
            catch (System.Exception ex)
            {

                return BadRequest("Error Occurred");
            }
        }

        [HttpPost("create")]
        public object GetFilterPets([FromBody] My_Pet_Class model)
        {
            try
            {
                var petsService = new PetsService();
                var result = petsService.CreatePets(_petsDbContext, model);
                return result;
            }
            catch (System.Exception ex)
            {

                return BadRequest("Error Occurred");
            }
        }


    }
}