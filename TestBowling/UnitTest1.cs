using Bowling;
using NUnit.Framework;

namespace TestBowling
{
   

    [TestFixture]
    public class GameTests
    {
        [Test]
        public void TestTotallyBadGame()
        {
            Game game = new Game();
            RollTest(game, 20, 0);
            Assert.AreEqual(0, game.Score());
        }

        [Test]
        public void TestAllOnes()
        {
            Game game = new Game();
            RollTest(game, 20, 1);
            Assert.AreEqual(20, game.Score());
        }

        [Test]
        public void TestOneSpare()
        {
            Game game = new Game();
            RollSpare(game);
            game.Roll(3); // next roll after the spare
            RollTest(game, 17, 0);
            Assert.AreEqual(16, game.Score()); // 10 +3 + 3 bonus
        }

        [Test]
        public void TestOneStrike()
        {
            Game game = new Game();
            game.Roll(10); // strike
            game.Roll(3);
            game.Roll(4);
            RollTest(game, 16, 0);
            Assert.AreEqual(24, game.Score()); // 10 + 3 + 4 +3 + 4
        }

        [Test]
        public void TestPerfectGame()
        {
            Game game = new Game();
            RollTest(game, 12, 10); // 12 strikes
            Assert.AreEqual(300, game.Score()); // (10+10+10) * 9 + 10*2 + 10
        }

        [Test]
        public void TestSpareInLastFrame()
        {
            Game game = new Game();
            RollTest(game, 18, 0); // 9 frames with no points
            game.Roll(5);
            game.Roll(5); // spare in last frame
            game.Roll(7); // bonus roll
            Assert.AreEqual(17, game.Score()); // 5 + 5 + 7
        }

        [Test]
        public void TestStrikeInLastFrame()
        {
            Game game = new Game();
            RollTest(game, 18, 0); // 9 frames with no points
            game.Roll(10); // strike in last frame
            game.Roll(5);
            game.Roll(3); // bonus rolls
            Assert.AreEqual(18, game.Score()); // 10 + 5 + 3
        }

        private void RollTest(Game game, int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        private void RollSpare(Game game)
        {
            game.Roll(5);
            game.Roll(5);
        }
    }

}