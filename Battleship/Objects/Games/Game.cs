﻿using System;
using System.Text.RegularExpressions;

namespace Battleship.Objects.Games
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
            //Player2.OutputBoards();
        }

        public void PlayRound()
        {
            //Each exchange of shots is called a Round.
            //One round = Player 1 fires a shot, then Player 2 fires a shot.
            Console.WriteLine("Write firing coordinates");
            string coords = Console.ReadLine();

            if (!IsCoordinateValid(coords))
            {
                Console.WriteLine("Input is not valid - Must match the format i.e. A5");
                PlayRound();
            }

            var firstChar = getCharacter(coords, 0);
            var secondChar = getCharacter(coords, 1);

            var along = getCharacterPostionInAlphabet(firstChar);
            var down = int.Parse(secondChar);
            var coordinates = new Boards.Coordinates(along, down);


            //Console.WriteLine(Player1.Name + " already picked those coordinates");

            var result = Player2.ProcessShot(coordinates);
            Player1.ProcessShotResult(coordinates, result);

            if (!Player2.HasLost) //If player 2 already lost, we can't let them take another turn.
            {
                coordinates = Player2.FireShot();
                result = Player1.ProcessShot(coordinates);
                Player2.ProcessShotResult(coordinates, result);
            }

            Player1.OutputBoards();
        }

        private int getCharacterPostionInAlphabet(string letter)
        {
            char c = Convert.ToChar(letter);
            //you may use lower case character.
            int index = char.ToUpper(c) - 64; //index == 1 
            return index;
        }

        private string getCharacter(string coordinates, int position)
        {
            return coordinates[position].ToString();
        }

        public bool IsCoordinateValid(string coords)
        {
            string pat = "^[A-J][0-9]?$|^[a-j][0-9]?$";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            var isValid = r.IsMatch(coords);
            return isValid;
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
