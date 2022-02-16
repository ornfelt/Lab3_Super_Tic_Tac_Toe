using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    // Singleton class that keeps track of winners
    // Class that keeps track of winners
    public sealed class WinTracker : IWinTracker
    {
        // A dictionary that will contain wins
        private Dictionary<string, string> boardWinsDict;
        // List that will hold values of the winning small boards when a player wins the super board
        private List<String> winningBoards;
        private static WinTracker instance = null;
        private String[] boardNames = { "nw", "nc", "ne", "cw", "cc", "ce", "sw", "sc", "se" };
        private String endResult;

        // Public constructor that gets the current instance or creates a new one
        public static WinTracker GetInstance()
        {
            if (instance == null)
            {
                instance = new WinTracker();
            }
            return instance;
        }

        // Private constructor
        private WinTracker()
        {
            // Init values for dictionary
            boardWinsDict = new Dictionary<string, string>();
            winningBoards = new List<String>();

            foreach (String boardString in boardNames)
            {
                boardWinsDict.Add(boardString, string.Empty);
            }
        }

        // Fetch the winningBoards list
        public List<String> GetWinningBoards()
        {
            return winningBoards;
        }

        // Add winning boards for the player that wins the super board
        public void AddWinningBoards(String wins)
        {
            String[] winsSplit = wins.Split(",");
            foreach (string win in winsSplit)
            {
                winningBoards.Add(win.ToUpper());
            }
        }

        // Add new win to dictionary
        public void AddWinToDict(String board, String playerName)
        {
            boardWinsDict[board] = playerName;
            Console.WriteLine();
            foreach (KeyValuePair<string, string> bwd in boardWinsDict)
            {
                //Console.WriteLine("Key = {0}, Value = {1}", bwd.Key, bwd.Value);
            }
        }

        // Public method for fetching the winsDict
        public Dictionary<string, string> GetWinsDict()
        {
            return boardWinsDict;
        }

        // Return true if the board has a winner
        public bool HasWonSmallBoard(String board)
        {
            return (boardWinsDict[board] == String.Empty ? false : true);
        }

        // Get the end result
        public string GetEndResult()
        {
            return endResult;
        }

        // Set the end result
        public void SetEndResult(String res)
        {
            endResult = res;
        }
    }
}
