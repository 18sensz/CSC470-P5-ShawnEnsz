using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P3_Code;

namespace UnitTestAppUserFakeRepository
{
    [TestClass]
    public class Login
    {
        [TestMethod]
        public void LoginWithCorrectCredentialsSuccess()
        {
            //Arrange
            const string USER_NAME = "18Sensz";
            const string PASSWORD = "pass";
            FakeAppUserRepository AppUserRepository = new FakeAppUserRepository();

            //Act  
            bool isLoggedIn = AppUserRepository.Login(USER_NAME, PASSWORD);

            //Assert
            Assert.IsTrue(isLoggedIn);
        }
        [TestMethod]
        public void LoginWithIncorrectCredentials()
        {
            //Arrange
            const string USER_NAME = "notuser";
            const string PASSWORD = "notpass";
            FakeAppUserRepository AppUserRepository = new FakeAppUserRepository();

            //Act  
            bool isLoggedIn = AppUserRepository.Login(USER_NAME, PASSWORD);

            //Assert
            Assert.IsFalse(isLoggedIn);
        }
    }
}
