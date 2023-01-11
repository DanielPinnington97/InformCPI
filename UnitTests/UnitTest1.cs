using InformCPISolution.Controllers;
using InformCPISolution.Data;
using InformCPISolution.Domain.Contacts.Repository;
using InformCPISolution.Domain.Contacts.Services;
using InformCPISolution.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [Test]
        public void TestDetailsViewData()
        {
            // Arrange
            var repository = new ContactRepository();
            var contact = new ContactModel
            {
                ID = 1,
                Name = "David Bowie",
                Email = "ZiggyStardust@spaceodity.com",
                PhoneNumber = "07854852584"
            };

            // Act
            var result = repository.GetContact(1);

            // Assert
            Assert.AreEqual(contact, result.Result);
        }
    }
}