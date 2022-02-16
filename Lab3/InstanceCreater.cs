using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class InstanceCreater
    {
        public IPlayer CreatePlayer(String playerName)
        {
            return new Player(playerName, CreateWinChecker(), GetWinTracker());
        }

        public IWinChecker CreateWinChecker()
        {
            return new WinChecker(GetWinTracker());
        }

        public IWinTracker GetWinTracker()
        {
            return WinTracker.GetInstance();
        }
    }
}
