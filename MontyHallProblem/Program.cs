/*
 * Bill Nicholson
 * Modified by 
 * nicholdw@ucmail.uc.edu
 * Simulate the Monty Hall problem to show that switching doors increases the player's chance of winning.
 * https://www.scientificamerican.com/article/the-3-door-monty-hall-problem/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblem {
    class MontyHallProblem {
        static void Main(string[] args) {
            Simulate();
        }
        public static void Simulate() {
            int TOTAL_GAMES = 100000;
            Random r = new Random();
            int[] doors = new int[3];
            int playerWins = 0;
            int totalGames = 0;
            // Simulate the player not changing doors after one door is revealed
            for (int i = 0; i < TOTAL_GAMES; i++) {
                InitDoors(doors);
                int playerChoice = 0;
                int prizeIdx = 0;

                // Put the prize behind a door and let the player choose a door. They may be the same door.
                playerChoice = r.Next(3);
                prizeIdx = r.Next(3);

                // At this point the player has a 1 in 3 chance of being right.
                if (playerChoice == prizeIdx) {
                    playerWins++;
                }
                totalGames++;
            }
            double winningPercentage;
            winningPercentage = (double)playerWins / totalGames;
            Console.WriteLine("The player did not change doors after a losing door was revealed. " 
                             + totalGames 
                             + " games were played, " 
                             + winningPercentage * 100 
                             + " winning percentage");
            // Simulate the player changing doors after one door is revealed
            totalGames = 0;
            playerWins = 0;
            for (int i = 0; i < TOTAL_GAMES; i++) {
                InitDoors(doors);
                int playerChoice = 0;
                int prizeIdx = 0;

                // Put the prize behind a door and let the player choose a door. They may be the same door.
                playerChoice = r.Next(3);
                prizeIdx = r.Next(3);
                // Now the player changes doors to the only door that is not the players original choice and not the door that was revealed
                int doorRevealed = 0;
                for (doorRevealed = 0; doorRevealed < 3; doorRevealed++) {
                    if (doorRevealed != playerChoice && doorRevealed != prizeIdx) { break; }      // We found the door that will be revealed. 
                }
                int newPlayerChoice = 0;
                for (newPlayerChoice = 0; newPlayerChoice < 3; newPlayerChoice++) {
                    if (newPlayerChoice != playerChoice && newPlayerChoice != doorRevealed) { break; }      // We found the door that the player will switch to. 
                }
                playerChoice = newPlayerChoice;
                // At this point the player has a 2 in 3 chance of being right.
                if (playerChoice == prizeIdx) {
                    playerWins++;
                }
                totalGames++;
            }
            winningPercentage = (double)playerWins / totalGames;
            Console.WriteLine("The player DID change doors after a losing door was revealed. "
                             + totalGames
                             + " games played, "
                             + winningPercentage * 100
                             + " winning percentage");
        }
        private static void InitDoors(int[] doors) {
            Random r = new Random();
            for (int i = 0; i < doors.Length; i++) {
                doors[i] = r.Next(3);
            }
        }
    }
}
