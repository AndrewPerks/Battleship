using System;

namespace BattleshipModellingPractice.Objects.Games
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game()
        {
            Player1 = new Player("Andrew");
            Player2 = new Player("Enemy");

            Player1.PlaceShips();
            Player2.PlaceShips();

            Player1.OutputBoards();
            Player2.OutputBoards();
        }

        public void PlayRound()
        {
            //Each exchange of shots is called a Round.
            //One round = Player 1 fires a shot, then Player 2 fires a shot.

            //Console.WriteLine("Where would you like to shoot along?");
            //var along = int.Parse(Console.ReadLine());
            //Console.WriteLine("Where would you like to shoot down?");
            //var down = int.Parse(Console.ReadLine());
            //var coordinates = new Boards.Coordinates(along, down);

            var coordinates = Player1.FireShot();

            var result = Player2.ProcessShot(coordinates);
            Player1.ProcessShotResult(coordinates, result);

            if (!Player2.HasLost) //If player 2 already lost, we can't let them take another turn.
            {
                coordinates = Player2.FireShot();
                result = Player1.ProcessShot(coordinates);
                Player2.ProcessShotResult(coordinates, result);
            }
        }

        public void PlayToEnd()
        {
            while (!Player1.HasLost && !Player2.HasLost)
            {
                PlayRound();
            }

            Player1.OutputBoards();
            Player2.OutputBoards();

            if (Player1.HasLost)
            {
                Console.WriteLine(Player2.Name + " has won the game!");
            }
            else if (Player2.HasLost)
            {
                Console.WriteLine(Player1.Name + " has won the game!");
            }
        }
    }
}
