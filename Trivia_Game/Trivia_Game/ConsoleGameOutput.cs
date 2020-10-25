using System;

namespace Trivia_Game {
    public class ConsoleGameOutput : IGameOutput
    {
        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Quiz!");
        }

        public void DisplayQuestion(string question)
        {
            Console.WriteLine(question);
        }

        public void OutputScores(GameState gameState)
        {
            Console.WriteLine($"Player { gameState.CurrentPlayer } has score { gameState.GetPlayerScore(gameState.CurrentPlayer) }");

        }

        public void CorrectAnswer()
        {
            Console.WriteLine("Correct! :) ");
        }

        public void IncorrectAnswer(string actualAnswer)
        {
            Console.WriteLine("Incorrect! :( ");
            Console.WriteLine($"The actual answer was: {actualAnswer}");
        }

        public void OutputRemainingQuestion(QuestionManager questionManager)
        {
            Console.WriteLine($"There are {questionManager.RemainingQuestionCount} questions remaining");
        }

        public void OutputFinalScore(GameState gameState)
        {
            var winner = gameState.GetWinner();
            Console.WriteLine(string.IsNullOrEmpty(winner)
                ? "It's a draw"
                : $"Congratulations!, {winner} is the winner!");

            Console.WriteLine($"Player 1 has {gameState.Player1Score} points // Player 2 has {gameState.Player2Score} points");
        }

        public void OutputPlayerTurn(GameState gameState)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Player {gameState.CurrentPlayer}, It's your turn");
        }
    }
}