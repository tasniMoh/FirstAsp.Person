using AutoMapper;
using FirstAspPerson.IRepository;
using FirstAspPerson.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PersonController> _logger;
        private readonly IMapper _mapper;

        public PersonController(IUnitOfWork unitOfWork, ILogger<PersonController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetPersons()
        {

            try
            {
                var persons = await _unitOfWork.Persons.GetAll();
                var results = _mapper.Map<IList<PersonDTO>>(persons);
                return Ok(results);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(GetPersons)}");
                return StatusCode(500, "Internal Server Error ,Please Try Again Later.");

            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetPerson(int id)
        {

            try
            {
                var person = await _unitOfWork.Persons.Get(q=>q.NationalCode==id,new List<string> { "Images"});
                var result = _mapper.Map<PersonDTO>(person);
                return Ok(person);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(GetPerson)}");
                return StatusCode(500, "Internal Server Error ,Please Try Again Later.");

            }

        }
    }
}











