using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MY7W.Application;

namespace ResponseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserServiceTest()
        {
            UserInfoService userInfoService = new UserInfoService();
            var temp=userInfoService.ExecuteQuertAll();

        }
    }
}
