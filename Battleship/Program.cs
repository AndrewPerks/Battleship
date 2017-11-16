using Battleship.Objects.Games;
using Battleship.Objects.Windows;
using System;

namespace Battleship
{

    class Program
    {

        static void Main(string[] args)
        {
            Window window = new Window();
            window.Maximise();

            Console.WriteLine("Press enter to begin!");
            Console.ReadLine();

            Game game1 = new Game();
            game1.PlayToEnd();
            if(!game1.Player1.HasLost)
            {
                Console.WriteLine("You Win!");
            }          
            else
            {
                Console.WriteLine("You Lose!");
            }
                        
            Console.ReadLine();
           
        }
    }
}
