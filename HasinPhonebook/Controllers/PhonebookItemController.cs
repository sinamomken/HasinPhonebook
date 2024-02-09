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
        private readonly IMapper _mapper;

        public PhonebookItemController(IPhonebookItemRepository phonebookItemRepository, IMapper mapper)
        {
            this._phonebookItemRepository = phonebookItemRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PhonebookItemDto>))]
        public IActionResult getPhonebookItems()
        {
            var phonebookItemDtos = _mapper.Map<List<PhonebookItemDto>>(_phonebookItemRepository.GetAll());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(phonebookItemDtos);
        }

        [HttpGet("{itemId}")]
        [ProducesResponseType(200, Type = typeof(PhonebookItemDto))]
        [ProducesResponseType(400)]
        public IActionResult getPhonebookItemById(int itemId)
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
        public IActionResult getPhonebookItemByTag(string tag)
        {
            var phonebookItem = _phonebookItemRepository.GetByItemTag(tag);
            if(phonebookItem == default(PhonebookItem))
                return NotFound();
            var phonebookItemDto = _mapper.Map<PhonebookItemDto>(phonebookItem);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(phonebookItemDto);
        }
    }
}
