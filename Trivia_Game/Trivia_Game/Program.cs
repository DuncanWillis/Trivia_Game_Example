using System.Collections;
using System.Collections.Generic;

namespace Trivia_Game
{
    class Program
    { 

        static void Main(string[] args)
        {
            var consoleGameOutput = new ConsoleGameOutput();
            var gameInput = new ConsoleGameInput();
            var questionManager = new QuestionManager();
            var gameState = new GameState();

            var game = new GameSupaFun(consoleGameOutput, gameInput, questionManager, gameState);
            game.Run();
        }
    }
}
