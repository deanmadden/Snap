using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Snap program.");
            Game game = new Game();
            bool result = game.Play();

            if (result)
            {
                Console.WriteLine("Snap program finished successfully.");
            }
            else
            {
                Console.WriteLine("Snap program failed!");
            }

            Console.ReadLine();
        }
    }
}
