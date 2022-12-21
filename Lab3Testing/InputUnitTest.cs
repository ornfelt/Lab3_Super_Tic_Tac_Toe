using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab3;

namespace Lab3Testing
{
    [TestClass]
    public class InputUnitTest
    {

        // When testing, comment this in GameLoopState:
        //instanceCreater.GetResultVisualizer().VisualizePlays(finalValidPlays, HasDepthOne);
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
            WinTracker.GetInstance().ResetTracker();
        }

        [TestMethod]
        public void TestGameWithValidRandomInput()
        {
            // Arrange
            String input = "CC.SE,CC.NC,CC.CE,CC.NW,CC.NE,CC.SC,CC.SW,CC.CC,CC.CW,NW.SC,NW.NC,NW.NE,NW.CC,NW.NW,NW.SW,NW.CE,NW.CW,NW.SE,CE.NC,CE.CE,CE.CC,CE.SE,CE.SC,CE.CW,CE.NE,CE.NW,CE.SW,NE.NC,NE.CC,NE.CE,NE.SC,NE.NE,NE.SE,NE.NW,NE.CW,NE.SW,SE.NC,SE.CC,SE.SC,SE.SE,SE.CW,SE.SW,SE.NE,SE.NW,SE.CE,CW.CC,CW.SC,CW.CE,CW.SW,CW.NE,CW.NC,CW.SE,CW.CW,CW.NW,SW.CC,SW.CE,SW.NE,SW.NC,SW.SE,SW.CW,SW.SC,SW.NW,SW.SW,NC.CW,NC.NC,NC.SC,NC.SW,NC.NE,NC.CE,NC.SE,NC.CC,NC.NW,SC.NE,SC.NC,SC.SW,SC.CW,SC.SC,SC.CC,SC.SE,SC.CE,SC.NW";
            // Act
            GameStarter gameStarter = new GameStarter(input);
            gameStarter.StartGame();
            // Assert
            String endResult = WinTracker.GetInstance().GetEndResult();
            Assert.AreEqual("1.3, 0.3", endResult);
            WinTracker.GetInstance().ResetTracker();
        }

        [TestMethod]
        public void TestGameWithValidInputDepthOne()
        {
            // Arrange
            String input = "NW,NC,CW,CC,SW";
            // Act
            GameStarter gameStarter = new GameStarter(input);
            gameStarter.StartGame();
            // Assert
            String endResult = WinTracker.GetInstance().GetEndResult();
            Assert.AreEqual("1, 0", endResult);
            WinTracker.GetInstance().ResetTracker();
        }

        [TestMethod]
        public void TestGameWithInvalid()
        {
            // Arrange
            // CG is bad char so this should fail
            String input = "NW.CC, NC.CC,NW.NW, NE.CC, NW.SE, CE.CG, CW.CC";
            // Act
            GameStarter gameStarter = new GameStarter(input);
            gameStarter.StartGame();
            // Assert
            Assert.AreEqual(WinTracker.GetInstance().GetEndResult(), null);
            WinTracker.GetInstance().ResetTracker();
        }
    }
}
