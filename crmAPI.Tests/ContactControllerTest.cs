using crmAPI.Controllers;
using crmAPI.Models;
using crmAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace Tests
{
    public class ContactsControllerTests
    {
        [Fact]
        public void GetContactById_ReturnsOk_WhenContactExists()
        {
            //Arranging
            var mockContactService = new Mock<IContactService>();
            var expectedCompany = new Company
            {
                Id = 1,
                Name = "IQYI",
                Industry = "TV",
                WebSite = "iqyi.com",
                Contacts =[],

            };
            var expectedContact = new Contact
            {
                Id = 1,
                FirstName = "Yi",
                LastName = "Cheng",
                Email = "chengyi@email.com",
                Phone = "11912345678",
                CompanyId = 1,
                Company = expectedCompany

            };
            mockContactService.Setup(service => service.GetContactById(1)).Returns(expectedContact);
            var controller = new ContactsController(mockContactService.Object);

            //Acting
            var result = controller.GetContactById(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualContact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(expectedContact.Id, actualContact.Id);
            Assert.Equal(expectedContact.FirstName, actualContact.FirstName);
        }
        

    }


}