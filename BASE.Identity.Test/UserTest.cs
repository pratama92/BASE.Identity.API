using BASE.Identity.Repository.Models;
using BASE.Identity.Repository.Repositories;
using BASE.Identity.Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Xml;
namespace BASE.Identity.Test
{
    public class Tests
    {
        private UserService _userService;

        [SetUp]
        public void Setup()
        {            
            var data = new List<User>
            {
                new User { UserName = "username1", Email= "email@example.com", Password= "password1" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<User>(data.Provider));
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.As<IAsyncEnumerable<User>>().Setup(m => m.GetAsyncEnumerator(default)).Returns(new TestAsyncEnumerator<User>(data.GetEnumerator()));


            var mockContext = new Mock<DataBaseContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            _userService = new UserService(mockContext.Object);
        }


        [Test]
        public async Task GetAllUsersTest()
        {
            var serviceTest = await _userService.GetUsers();

            if (serviceTest != null)
            {
                if (serviceTest.Count > 0)
                {
                    Assert.Pass();
                }
            }

            Assert.Fail();
        }

        [Test]
        public async Task GetUserByUserNameIfExistTest()
        {
            var userName = "username1";
            var serviceTest = await _userService.GetUserByUserName(userName);

            if (serviceTest != null)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public async Task GetUserByUserNameIfNotExistTest()
        {
            var userName = "userxname1";
            var serviceTest = await _userService.GetUserByUserName(userName);

            if (serviceTest == null)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }


        [TearDown]
        public async Task TearDown()
        {

        }

    }
}
