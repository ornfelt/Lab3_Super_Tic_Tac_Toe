using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class BoardComposite : IPlayingBoard
    {
        // List of different playingBoards
        private List<IPlayingBoard> playingBoards = new List<IPlayingBoard>();
        private string name;

        // Public constructor
        public BoardComposite(String name)
        {
            // The name of the composite will simply be the same as the player name
            this.name = name;
        }

        // Add new playing board to set of playingBoards
        public void AddPlayingBoard(IPlayingBoard playingBoard)
        {
            playingBoards.Add(playingBoard);
        }

        // Add value to the correct board and return it
        public HashSet<String> GetUpdatedBoardSet(String value)
        {
            String[] newPlaySplit = value.Split(".");
            String boardPos = newPlaySplit[0];
            String boardPlay = newPlaySplit[1];

            // Add value to the correct board
            foreach (var board in playingBoards)
            {
                if (board.GetName() == boardPos) return board.GetUpdatedBoardSet(boardPlay);
            }

            return null;
        }

        // Get name
        public string GetName()
        {
            return name;
        }
    }
}
