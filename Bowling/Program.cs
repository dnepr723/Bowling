﻿// See https://aka.ms/new-console-template for more information
using Bowling;

Game game = new Game();

// Example game rolls mathing example in the document
int[] rolls = { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };
foreach (int roll in rolls)
{
    Console.WriteLine("Roll: " + roll);
    game.Roll(roll);
}
