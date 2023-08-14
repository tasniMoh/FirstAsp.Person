using AutoMapper;
using FirstAspPerson.IRepository;
using FirstAspPerson.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Imagecontroller : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PersonController> _logger;
        private readonly IMapper _mapper;
        public Imagecontroller(IUnitOfWork unitOfWork, ILogger<PersonController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> GetImages()
        {

            try
            {
                var images = await _unitOfWork.Images.GetAll();
                var results = _mapper.Map<IList<ImageDTO>>(images);
                return Ok(results);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(GetImages)}");
                return StatusCode(500, "Internal Server Error ,Please Try Again Later.");

            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetImage(int id)
        {

            try
            {
                var image = await _unitOfWork.Images.Get(q => q.Id == id, new List<string> { "Person" });
                var result = _mapper.Map<ImageDTO>(image);
                return Ok(image);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Something went wrong in the {nameof(GetImage)}");
                return StatusCode(500, "Internal Server Error ,Please Try Again Later.");

            }

        }

    }
}
