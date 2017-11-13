using Battleship.Objects.Games;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Regex_rejects_three_characters_for_player_input()
        {
            Game gameClass = new Game();

            string testInput = "A11";

            bool isValid = gameClass.isCoordinatesValid(testInput);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Regex_rejects_letters_after_J_alphabetically()
        {
            Game gameClass = new Game();

            string testInput = "K1";

            bool isValid = gameClass.isCoordinatesValid(testInput);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Regex_accepts_letter_followed_by_number()
        {
            Game gameClass = new Game();

            string testInput = "C7";

            bool isValid = gameClass.isCoordinatesValid(testInput);

            Assert.IsTrue(isValid);
        }

    }
}
