using MediatR;
using Moq;
using SalesAPI.Domain.CommandHandlers;
using SalesAPI.Domain.Commands;
using SalesAPI.Domain.Core;
using SalesAPI.Domain.Entities;
using SalesAPI.Domain.Interfaces;

namespace SalesAPI.UnitTests
{

    public class SalesCommandHandlerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ISalesRepository> _salesRepository;
        private readonly SalesCommandHandler _imageCommandHandler;

        public SalesCommandHandlerTests()
        {
            _mediator = new Mock<IMediator>();
            _salesRepository = new Mock<ISalesRepository>();

            _imageCommandHandler = new SalesCommandHandler(
                _salesRepository.Object);


        }

        [Fact]
        public async Task HandlerRegisterSalesCommand_Success_TotalValue()
        {
            // Arrange
            var command = new RegisterSalesCommand(1000, new List<Product>() { new Product(Guid.NewGuid().ToString(), 100.0, 10) });
            var entity = new Sales(Guid.NewGuid().ToString(), new List<Product>() { new Product(Guid.NewGuid().ToString(), 100.0, 10) });

            _mediator
                .Setup(s => s.Send(command, It.IsAny<CancellationToken>()));

            _salesRepository
                .Setup(s => s.Add(entity));
            _salesRepository.Setup(s => s.Find(sale => sale.Id == entity.Id)).Returns(new List<Sales>() { entity });

            // Act
            await _imageCommandHandler.Handle(command, new CancellationToken());

            // Assert

            Assert.True(entity.TotalValue == 1000);

            Assert.True(_salesRepository.Object.Find(sale => sale.Id == entity.Id).Any());

        }
    }
}
