using NUnit.Framework;

namespace Bowling
{

    [TestFixture]
    public class BowlingGameTests
    {
        private Game g;

        [SetUp]
        public void Initiala()
        {
            g = new Game();
        }
        [Test]
        public void GutterGameTest()
        {
            RollMany(20, 0);
            Assert.That(g.Score(), Is.EqualTo(0));
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        [Test]
        public void AllOnesTest()
        {
           
           RollMany(20, 1);
            Assert.That(g.Score(), Is.EqualTo(20));
        }
        [Test]
        public void OneSpareTest()
        {
           RollSpare();
            g.Roll(3);
           RollMany(17, 0);
           Assert.That(g.Score(), Is.EqualTo(16));
        }

        [Test]
        public void OneStrikeTest()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.That(g.Score(), Is.EqualTo(24));
        }

        [Test]
        public void PerfectGame()
        {
          
           RollMany(12, 10);
           Assert.That(g.Score(), Is.EqualTo(300));
        }
        [Test]
        public void StrikeSpare()
        {
          RollStrike();
            g.Roll(3);
            g.Roll(4);
           
          RollSpare();
            g.Roll(8);
           RollMany(13, 0);
           Assert.That(g.Score(), Is.EqualTo(50));
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
