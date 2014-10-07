namespace Bowling
{
    public class Game
    {
        
        private int[] rolls = new int[21];
        private int currentroll = 0;

        public void Roll(int pins)
        {
            rolls[currentroll] = pins;
            currentroll++;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += 10 + StrikeBonus(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(roll);
                    roll += 2;
                }
            }
            return score;
        }

        private int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }

        private int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }

        private int SumOfBallsInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }
    }
}