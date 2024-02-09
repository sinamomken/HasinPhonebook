using AutoMapper;
using HasinPhonebook.Dtos;
using HasinPhonebook.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HasinPhonebook.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PhonebookController : Controller
    {
        private readonly IPhonebookRepository _phonebookRepository;
        private readonly IMapper _mapper;

        public PhonebookController(IPhonebookRepository phonebookRepository, IMapper mapper)
        {
            this._phonebookRepository = phonebookRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PhonebookDto>))]
        public IActionResult GetPhonebooks()
        {
            var phonebookDtos = _mapper.Map<List<PhonebookDto>>(_phonebookRepository.GetAll());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(phonebookDtos);
        }
    }
}
