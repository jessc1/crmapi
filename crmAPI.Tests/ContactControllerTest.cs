using crmAPI.Controllers;
using crmAPI.Models;
using crmAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace Tests
{
    public class ContactsControllerTests
    {
        private readonly Mock<IContactService> _mockContactService;
        private readonly ContactsController _controller;
        public ContactsControllerTests()
        {
            _mockContactService = new Mock<IContactService>();
            _controller = new ContactsController(_mockContactService.Object);
            
        }
        [Fact]
        public void GetContactById_ReturnsOk_WhenContactExists()
        {
            //Arranging
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
            _mockContactService.Setup(s=> s.GetContactById(1)).Returns(expectedContact);
            var controller = new ContactsController(_mockContactService.Object);

            //Acting
            var result = controller.GetContactById(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualContact = Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(expectedContact.Id, actualContact.Id);
            Assert.Equal(expectedContact.FirstName, actualContact.FirstName);
        }
        [Fact]
        public void GetContactById_ReturnsNotFound_ForInvalidId()
        {
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(s => s.GetContactById(8)).Returns((Contact)null);
            var controller = new ContactsController(mockContactService.Object);
            var result = controller.GetContactById(8);
            Assert.IsType<NotFoundResult>(result.Result);
        }
        [Fact]
        public void GetContacts_ReturnsOk()
        {
            var mockContactService = new Mock<IContactService>();
            var controller = new ContactsController(mockContactService.Object);
            var expectedCompany = new Company
            {
                Id = 1,
                Name = "IQYI",
                Industry = "TV",
                WebSite = "iqyi.com",
                Contacts =[],

            };
            var contacts = new List<Contact>()
            {
               new () { Id = 1,
                FirstName = "Yi",
                LastName = "Cheng",
                Email = "chengyi@email.com",
                Phone = "11912345678",
                CompanyId = 1,
                Company = expectedCompany

                },
             
                new() { Id = 2,
                FirstName = "Yuning",
                LastName = "Liu",
                Email = "yuning@email.com",
                Phone = "11912345678",
                CompanyId = 1,
                Company = expectedCompany
                }
               

            };
            
            mockContactService.Setup(s => s.GetContacts()).Returns(contacts);
            var result = controller.GetContacts();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<ICollection<Contact>>(okResult.Value);
            Assert.Equal(2, model.Count);
            //mockContactService.Verify(s => s.GetContacts(), Times.Once());
            
        }
        [Fact]
        public void CreateContact_ReturnsCreatedAction_Contact()
        {
            var expectedCompany = new Company
            {
                Id = 1,
                Name = "IQYI",
                Industry = "TV",
                WebSite = "iqyi.com",
                Contacts =[],

            };
            var contact = new Contact
            {
                FirstName = "Yi",
                LastName = "Cheng",
                Email = "chengyi@email.com",
                Phone = "11912345678",
                CompanyId = 1,
                Company = expectedCompany

            };
         
            _mockContactService.Setup(s => s.AddContact(contact));

            var result = _controller.CreateContact(contact);
            Assert.IsType<NoContentResult>(result.Result);
           // _mockContactService.Verify(s => s.AddContact(contact));
           
            
        }
        

    }


    }

