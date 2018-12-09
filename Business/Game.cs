using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Starting point for playing a game
    /// </summary>
    public class Game
    {
        public bool Play()
        {
            Console.WriteLine("Playing a game of Snap!");

            Referee referee = new Referee();

            bool res = referee.SetupGame();

            if (res)
            {
                res = referee.StartGame();
            }            

            return res;
        }
    }
}
