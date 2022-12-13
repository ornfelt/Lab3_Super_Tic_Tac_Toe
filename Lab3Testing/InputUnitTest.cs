using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab3;

namespace Lab3Testing
{
    [TestClass]
    public class InputUnitTest
    {
        [TestMethod]
        public void TestGameWithValidInput()
        {
            // Arrange
            String input = "NW.CC, NC.CC,NW.NW, NE.CC, NW.SE, CE.CC, CW.CC, SE.CC, CW.NW, CC.CC, CW.SE, CC.NW, CC.SE, CE.NW, SW.CC, CE.SE, SW.NW, SE.SE, SW.SE";
            // Act
            GameStarter gameStarter = new GameStarter(input);
            gameStarter.StartGame();
            // Assert
            String endResult = WinTracker.GetInstance().GetEndResult();
            Assert.AreEqual("1.3, 0.1", endResult);
        }
    }
}
