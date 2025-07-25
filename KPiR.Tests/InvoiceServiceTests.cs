using AutoMapper;
using EasyKPiR.Application.DTOs;
using EasyKPiR.Application.Interfaces;
using EasyKPiR.Domain.Entities;
using EasyKPiR.Infrastructure.Data;
using EasyKPiR.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace KPiR.Tests
    {
    public class InvoiceServiceTests
        {
        private readonly ApplicationDbContext _db;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IBusinessOwnerService> _ownerServiceMock;

        private readonly List<Invoice> _fakeInvoices = new()
        {
            new Invoice {
                Id = 1,
                Number = "FV/01/2024",
                Date = new DateTime(2024, 1, 15),
                SellerName = "Firma A",
                SellerNIP = "1234567890",
                BuyerName = "Firma B",
                BuyerNIP = "9876543210",
                AmountNet = 100,
                AmountVat = 23
            },
            new Invoice {
                Id = 2,
                Number = "FV/02/2024",
                Date = new DateTime(2024, 1, 20),
                SellerName = "Firma B",
                SellerNIP = "9876543210",
                BuyerName = "Firma A",
                BuyerNIP = "1234567890",
                AmountNet = 200,
                AmountVat = 46
            }
        };

        public InvoiceServiceTests()
            {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _db = new ApplicationDbContext(options);
            _db.Invoices.AddRange(_fakeInvoices);
            _db.SaveChanges();

            _mapperMock = new Mock<IMapper>();
            _ownerServiceMock = new Mock<IBusinessOwnerService>();
            }

        [Fact]
        public async Task GetAllAsync_ShouldReturnCorrectDtoTypes()
            {
            // Arrange
            var owner = new BusinessOwner { NIP = "1234567890" };
            _ownerServiceMock.Setup(s => s.GetCurrentAsync()).ReturnsAsync(owner);

            _mapperMock.Setup(m => m.Map<InvoiceDto>(It.IsAny<Invoice>()))
                .Returns<Invoice>(i => new InvoiceDto
                    {
                    Id = i.Id,
                    IssueDate = i.Date,
                    SellerNIP = i.SellerNIP,
                    BuyerNIP = i.BuyerNIP,
                    AmountNet = i.AmountNet,
                    AmountVat = i.AmountVat,
                    AmountGross = i.AmountNet + i.AmountVat
                    });

            var service = new InvoiceService(_db, _mapperMock.Object, _ownerServiceMock.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, r => r.Type == "Przychód");
            Assert.Contains(result, r => r.Type == "Koszt");
            }

        [Fact]
        public async Task GetByIdAsync_ReturnsInvoiceDto_WhenExists()
            {
            // Arrange
            var owner = new BusinessOwner { NIP = "1234567890" };
            var invoice = _fakeInvoices.First();

            _ownerServiceMock.Setup(s => s.GetCurrentAsync()).ReturnsAsync(owner);

            _mapperMock.Setup(m => m.Map<InvoiceDto>(invoice))
                .Returns(new InvoiceDto
                    {
                    Id = invoice.Id,
                    IssueDate = invoice.Date,
                    SellerNIP = invoice.SellerNIP,
                    BuyerNIP = invoice.BuyerNIP,
                    AmountNet = invoice.AmountNet,
                    AmountVat = invoice.AmountVat,
                    AmountGross = invoice.AmountGross
                    });

            var service = new InvoiceService(_db, _mapperMock.Object, _ownerServiceMock.Object);

            // Act
            var result = await service.GetByIdAsync(invoice.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(invoice.Id, result!.Id);
            }

        [Fact]
        public async Task CreateAsync_AddsInvoice_ReturnsNewId()
            {
            // Arrange
            var dto = new InvoiceDto
                {
                Id = 10,
                IssueDate = DateTime.Now,
                SellerNIP = "123",
                BuyerNIP = "456",
                AmountNet = 100,
                AmountVat = 23
                };

            var invoice = new Invoice
                {
                Id = 10,
                Date = dto.IssueDate,
                SellerNIP = dto.SellerNIP,
                BuyerNIP = dto.BuyerNIP,
                AmountNet = dto.AmountNet,
                AmountVat = dto.AmountVat,
                SellerName = "Firma X",
                BuyerName = "Firma Y",
                Number = "FV/2024/10"
                };

            _mapperMock.Setup(m => m.Map<Invoice>(dto)).Returns(invoice);

            var service = new InvoiceService(_db, _mapperMock.Object, _ownerServiceMock.Object);

            // Act
            var result = await service.CreateAsync(dto);

            // Assert
            Assert.Equal(10, result);
            }

        [Fact]
        public async Task DeleteAsync_DeletesInvoice_ReturnsTrue()
            {
            // Arrange
            var invoice = _fakeInvoices.First();

            var service = new InvoiceService(_db, _mapperMock.Object, _ownerServiceMock.Object);

            // Act
            var result = await service.DeleteAsync(invoice.Id);

            // Assert
            Assert.True(result);
            }

        [Fact]
        public async Task UpdateAsync_UpdatesInvoice_ReturnsTrue()
            {
            // Arrange
            var dto = new InvoiceDto
                {
                Id = 1,
                IssueDate = DateTime.Now,
                SellerNIP = "123",
                BuyerNIP = "456",
                AmountNet = 100,
                AmountVat = 23
                };
            var invoice = _db.Invoices.First();

            _mapperMock.Setup(m => m.Map(dto, invoice)).Verifiable();

            var service = new InvoiceService(_db, _mapperMock.Object, _ownerServiceMock.Object);

            // Act
            var result = await service.UpdateAsync(invoice.Id, dto);

            // Assert
            Assert.True(result);
            _mapperMock.Verify(m => m.Map(dto, invoice), Times.Once);
            }
        }
    }
