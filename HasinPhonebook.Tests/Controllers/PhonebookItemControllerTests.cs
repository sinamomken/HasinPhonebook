using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using HasinPhonebook.Controllers;
using HasinPhonebook.Dtos;
using HasinPhonebook.Entities;
using HasinPhonebook.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasinPhonebook.Tests.Controllers
{
    public class PhonebookItemControllerTests
    {
        private readonly IPhonebookItemRepository _phonebookItemRepository;
        private readonly IPhonebookRepository _phonebookRepository;
        private readonly IMapper _mapper;
        public PhonebookItemControllerTests()
        {
            _phonebookItemRepository = A.Fake<IPhonebookItemRepository>();
            _phonebookRepository = A.Fake<IPhonebookRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void PhonebookItemController_GetPhonebookItems_ReturnOk()
        {
            // Arrange
            var phonebookItems = A.Fake<List<PhonebookItemDto>>();
            var phonebookItemList = A.Fake<List<PhonebookItemDto>>();
            A.CallTo(() => _mapper.Map<List<PhonebookItemDto>>(phonebookItems)).Returns(phonebookItemList);
            var controller = new PhonebookItemController(_phonebookItemRepository, _phonebookRepository, _mapper);

            // Act
            var result = controller.GetPhonebookItems();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void PhonebookItemController_CreatePhonebookItem_ReturnOk()
        {
            // Arrange
            long phonebookId = 1;
            var phonebookItem = A.Fake<PhonebookItem>();
            var phonebookItemDtoToCreate = A.Fake<PhonebookItemDto>();
            var phonebooks = A.Fake<List<PhonebookItemDto>>();
            var phonebookList = A.Fake<List<PhonebookItemDto>>();
            A.CallTo(() => _mapper.Map<PhonebookItem>(phonebookItemDtoToCreate))
                .Returns(phonebookItem);
            A.CallTo(() => _phonebookItemRepository.CreatePhonebookItem(phonebookId, phonebookItem))
                .Returns(true);
            var controller = new PhonebookItemController(_phonebookItemRepository, _phonebookRepository, _mapper);

            // Act
            var result = controller.CreatePhonebookItem(phonebookId, phonebookItemDtoToCreate);

            // Assert
            result.Should().NotBeNull();
        }
    }
}
