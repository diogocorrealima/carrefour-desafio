using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SalesAPI.Application;
using SalesAPI.Application.ViewModels;
using SalesAPI.Domain.Core;
using SalesAPI.Domain.Entities;
using SalesAPI.Domain.Interfaces;
using SalesAPI.Services.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SalesAPI.UnitTests
{
    public class SallesControllerTests
    {
        private readonly Mock<ISalesAppService> _salesAppService;
        private readonly Mock<ISalesRepository> _salesRepository;
        private readonly Mock<ILogger<SalesController>> _logger;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IMapper> _mapper;
        private readonly SalesController _salesController;

        public SallesControllerTests()
        {
            _salesAppService = new Mock<ISalesAppService>();
            _salesRepository = new Mock<ISalesRepository>();
            _logger = new Mock<ILogger<SalesController>>();
            _mediator = new Mock<IMediator>();
            _mapper = new Mock<IMapper>();

            _salesController = new SalesController(
                _logger.Object,
                _salesAppService.Object
                );
        }

        [Fact]
        public async Task GetSalesAsync_EmptySalesRepository_ReturnOk()
        {
            // Arrange
             _salesRepository.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<Sales>());
             _salesAppService.Setup(s => s.GetAll()).ReturnsAsync(new List<SalesListViewModel>());
            

            // Act
            var result = await _salesController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
