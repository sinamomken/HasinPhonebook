using AutoMapper;
using HasinPhonebook.Dtos;
using HasinPhonebook.Entities;
using HasinPhonebook.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HasinPhonebook.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PhonebookItemController : Controller
    {
        private readonly IPhonebookItemRepository _phonebookItemRepository;
        private readonly IPhonebookRepository _phonebookRepository;
        private readonly IMapper _mapper;

        public PhonebookItemController(IPhonebookItemRepository phonebookItemRepository, IPhonebookRepository phonebookRepository,
            IMapper mapper)
        {
            this._phonebookItemRepository = phonebookItemRepository;
            this._phonebookRepository = phonebookRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PhonebookItemDto>))]
        public IActionResult GetPhonebookItems()
        {
            var phonebookItemDtos = _mapper.Map<List<PhonebookItemDto>>(_phonebookItemRepository.GetAll());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(phonebookItemDtos);
        }

        [HttpGet("{itemId}")]
        [ProducesResponseType(200, Type = typeof(PhonebookItemDto))]
        [ProducesResponseType(400)]
        public IActionResult GetPhonebookItemById(long itemId)
        {
            if(!_phonebookItemRepository.ItemExists(itemId))
                return NotFound();
            var phonebookItemDto = _mapper.Map<PhonebookItemDto>(_phonebookItemRepository.GetById(itemId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(phonebookItemDto);
        }

        [HttpGet("byTag/{tag}")]
        [ProducesResponseType(200, Type = typeof(PhonebookItemDto))]
        [ProducesResponseType(400)]
        public IActionResult GetPhonebookItemByTag(string tag)
        {
            var phonebookItem = _phonebookItemRepository.GetByItemTag(tag);
            if(phonebookItem == default(PhonebookItem))
                return NotFound();
            var phonebookItemDto = _mapper.Map<PhonebookItemDto>(phonebookItem);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(phonebookItemDto);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePhonebookItem([FromQuery] long phonebookId, [FromBody] PhonebookItemDto phonebookItemDto)
        {
            if(phonebookItemDto==null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_phonebookRepository.Exists(phonebookId))
            {
                ModelState.AddModelError("", "Specified phonebook does not exist!");
                return NotFound(ModelState);
            }

            var phonebookItem = _mapper.Map<PhonebookItem>(phonebookItemDto);
            if(!_phonebookItemRepository.CreatePhonebookItem(phonebookId, phonebookItem))
            {
                ModelState.AddModelError("", "Could not save in database!");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created.");
        }

        [HttpPut("{itemId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePhonebookItem(long itemId, [FromBody] PhonebookItemDto phonebookItemDto) 
        {
            if (phonebookItemDto == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (itemId != phonebookItemDto.Id)
                return BadRequest(ModelState);

            if (!_phonebookItemRepository.ItemExists(itemId))
                return NotFound();

            var phonebookItem = _mapper.Map<PhonebookItem>(phonebookItemDto);
            if(!_phonebookItemRepository.UpdatePhonebookItem(phonebookItem))
            {
                ModelState.AddModelError("", "Could not save in database!");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{itemId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePhonebookItem(long itemId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_phonebookItemRepository.ItemExists(itemId))
                return NotFound();

            if (!_phonebookItemRepository.DeletePhonebookItem(itemId))
            {
                ModelState.AddModelError("", "Could not save in database!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
