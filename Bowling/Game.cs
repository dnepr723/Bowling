using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private List<int> rolls;
        private int currentRoll;
        private int currentFrame;

        public Game()
        {
            rolls = new List<int>();
            currentRoll = 0;
            currentFrame = 0;
        }

        // Record the number of pins knocked down
        public void Roll(int pins)
        {
            if (pins < 0 || pins > 10)
                throw new ArgumentException("Pin number must be between 0 and 10.");

            // The last (tenth) frame (before counting the current roll 9*2=18, normal: 18+2=20, max 3 rolls in 10: 18+3=21)
            if (currentRoll > 20)
            {
                if (IsSpare(rolls.Count-2) || IsStrike(rolls.Count - 1) || IsStrike(rolls.Count-2)) //checking if we had spares or strikes in frame 10
                {                  
                    rolls.Add(pins);            
                }
                else
                {
                    // No more rolls allowed
                    throw new InvalidOperationException("No more rolls allowed.");
                }
            }
            else
            {
                rolls.Add(pins);
                if (pins==10) //move to the next frame
                {
                    currentRoll++;
                }
            }
            Console.WriteLine("Roll in game: " + currentRoll);
            currentRoll++;
        }

        // Calculate the total score of the game
        public int Score()
        {

            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex)) // Strike
                {
                    score += 10 + StrikeBonus(rollIndex);
                    rollIndex++;
                }
                else if (IsSpare(rollIndex)) // Spare
                {
                    score += 10 + SpareBonus(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += FrameSum(rollIndex);
                    rollIndex += 2;
                }
            }

            return score;
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        private int StrikeBonus(int rollIndex) //it is unclear from the document if strike bonus is the next 2 rolls or the next frame (in case of next frame strike. Assume next 2 rolls
        {
            return rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private int SpareBonus(int rollIndex)
        {
            return rolls[rollIndex + 2];
        }

        private int FrameSum(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }
    }

}
