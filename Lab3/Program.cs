using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "NW.CC,    NC.CC,NW.NW, NE.CC, NW.SE,NW.SE, CE.CC, CW.CC, SE.CC, CW.NW, CC.CC, CW.SE, CC.NW, CC.SE, CE.NW, SW.CC, CE.SE,\n" + 
                "   NW.NE, SW.NW, NW.CE, SE.SE,  SW.SE   ";
            // Standard input
            //String input = "NW.CC, NC.CC,NW.NW, NE.CC, NW.SE, CE.CC, CW.CC, SE.CC, CW.NW, CC.CC, CW.SE, CC.NW, CC.SE, CE.NW, SW.CC, CE.SE, SW.NW, SE.SE, SW.SE";
            //input = "SE.CC, SE.SW, SE.CW, SE.CE,SE.NW, SE.SC,SE.NC, SE.SE, CC.CC, CE.SE,CC.CE";

            GameStarter gameStarter = new GameStarter(input);
            gameStarter.StartGame();
        }
    }
}
