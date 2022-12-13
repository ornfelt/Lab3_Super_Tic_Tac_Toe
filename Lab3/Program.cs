using System;

namespace Lab3
{
    // Main class that takes an input argument, or uses the standard input
    // @author: Jonas Örnfelt
    class Program
    {
        static void Main(string[] args)
        {
            String input = "";
            if (args.Length == 0)
            {
                Console.WriteLine("No input from argument. Using standard input.");
                // Use original inputs from assignment
                input = "NW.CC, NC.CC,NW.NW, NE.CC, NW.SE, CE.CC, CW.CC, SE.CC, CW.NW, CC.CC, CW.SE, CC.NW, CC.SE, CE.NW, SW.CC, CE.SE, SW.NW, SE.SE, SW.SE";

                // Examples of invalid inputs 
                // Depth 1
                //input = "NW,NC,CW,CC,SW";
                //input = "NW.CC, NC.CC,NW.NW, NE.CC, NW.SE, CE.CG, CW.CC";
                //input = "adasdasda";
                //input = "NW.CC, NC.CC,NW.NW, NE.CC, NW.SE, CE.C, CW.CC, SE.CC, CW.NW, CC.CC, CW.SE, CC.NW, CC.SE, CE.NW, SW.CC, CE.SE, SW.NW, SE.SE, SW.SE";
                //input = "NW.CC, NC.CC,NW.NWE, NE.CC, NW.SE, CE.CCG, CW.CC, SE.CC, CW.NW, CC.CC, CW.SE, CC.NW, CC.SE, CE.NW, SW.CC, CE.SE, SW.NW, SE.SE, SW.SE";

            }
            else
            {
                input = args[0];
            }

            GameStarter gameStarter = new GameStarter(input);
            gameStarter.StartGame();
        }
    }
}
