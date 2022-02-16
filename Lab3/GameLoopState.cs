﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab3
{
    class GameLoopState : State
    {
        // Set that contains total plays in the game (hashset since they should be unique and have fast lookups)
        private HashSet<String> totalPlays;
        private IPlayer playerOne, playerTwo;
        private int totalPlaysCount = 0;
        private string playerOneName, playerTwoName;
        private IWinChecker wc;
        // Bool that determines what player the new play should be added to
        private bool addToPlayerOne;
        private bool superBoardWon;
        private String value;
        private String boardPos;
        // GameStarter handles the state of the game. The state is changed in the game loop method below
        private GameStarter gameStarter;
        private InstanceCreater instanceCreater;

        // Starting method for GameLoop
        public override void HandleGameState (String input, GameStarter gameStarter)
        {
            // Init values
            this.gameStarter = gameStarter;
            InitValues();
            // Parse input
            input = String.Concat(input.Where(c => !Char.IsWhiteSpace(c)));
            String[] inputSplit = input.ToLower().Split(",");

            foreach (String play in inputSplit)
            {
                // Only add plays that haven't been done before
                if (!HasBeenPlayed(play)) totalPlays.Add(play);
            }
            // Start the game loop
            LoopGame();
        }

        // Initialize essential variables
        private void InitValues()
        {
            // Instance of InstanceCreater
            instanceCreater = new InstanceCreater();
            wc = instanceCreater.CreateWinChecker();
            // Player names
            playerOneName = "p1";
            playerTwoName = "p2";
            // Initialize set of all plays in the game and objects of new players
            playerOne = instanceCreater.CreatePlayer(playerOneName);
            playerTwo = instanceCreater.CreatePlayer(playerTwoName);
            totalPlays = new HashSet<String>();
            addToPlayerOne = true;
            superBoardWon = false;
        }

        // This method contains the main loop of the game
        private void LoopGame()
        {
            // Enqueue values to player 1 and 2 respectively and check for wins
            List<String> totalPlaysList = totalPlays.ToList();
            totalPlaysCount = totalPlays.Count();
            // Keep track of valid plays
            int validPlays = 0;

            for (int i = 0; (i < totalPlaysCount && !superBoardWon); i++)
            {
                value = totalPlaysList[i];
                boardPos = value.Split(".")[0];

                if (addToPlayerOne)
                {
                    // Check if new play can be played on small board (the small board shouldn't have a winner already)
                    if (playerOne.CanBeAdded(boardPos))
                    {
                        // Toggle addToPlayerOne so that next value is added to p2
                        addToPlayerOne = !addToPlayerOne;
                        HandleNewPlay(value, playerOne);
                        validPlays++;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't add: " + value + " to player. addToPlayer set to: " + addToPlayerOne);
                    }
                }
                else
                {
                    if (playerTwo.CanBeAdded(boardPos))
                    {
                        addToPlayerOne = !addToPlayerOne;
                        HandleNewPlay(value, playerTwo);
                        validPlays++;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't add: " + value + " to player. addToPlayer set to: " + addToPlayerOne);
                    }
                }
                if (validPlays == 80)
                {
                    // No more plays can be made, change state to game over and break loop
                    gameStarter.ChangeState("tie", new GameOverState());
                    break;
                }
            }
            // If this part is reached, the game in unfinished
            if (!superBoardWon) gameStarter.ChangeState("unfinished", new GameOverState());
        }

        // Handle the new play
        private void HandleNewPlay(string value, IPlayer player)
        {
            bool newWin = player.HasWonBoard(value);
            String playerName = player.GetPlayerName();
            // If the player wins a small board run, check if that player has won the super board
            if (newWin)
            {
                Console.WriteLine("Player: " + playerName + " won a board with: " + value);
                superBoardWon = wc.HasWonSuperBoard(playerName);
                Console.WriteLine(playerName + " has won super board: " + superBoardWon);
                if (superBoardWon)
                {
                    player.PrintEndResults();
                    // Change state to game over state
                    gameStarter.ChangeState(playerName, new GameOverState());
                }
            }
        }

        // Check if value exists in the totalPlaysQueue
        private bool HasBeenPlayed(String value)
        {
            if (totalPlays.Contains(value)) Console.WriteLine("HasBeenPlayed: " + value);
            return (totalPlays.Contains(value));
        }
    }
}