﻿using ray_trasing;

namespace ray_trasing
{
    public class Program
    {
        // Entry point of the program
        static void Main(string[] args)
        {
            // Creates game object and disposes of it after leaving the scope
            using (Game game = new Game(1280, 720))
            {
                // running the game
                game.Run();
            }
        }
    }
}