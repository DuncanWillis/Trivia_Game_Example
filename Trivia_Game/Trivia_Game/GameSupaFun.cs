using System;
using System.Reflection.Metadata;

namespace Trivia_Game {

    public class GameSupaFun
    {
        private readonly IGameOutput _consoleGameOutput;
        private readonly ConsoleGameInput _gameInput;
        private readonly QuestionManager _questionManager;
        private readonly GameState _gameState;

        public GameSupaFun(IGameOutput gameOutput, ConsoleGameInput gameInput, QuestionManager questionManager, GameState gameState)
        {
            _consoleGameOutput = gameOutput;
            _gameInput = gameInput;
            _questionManager = questionManager;
            _gameState = gameState;
        }

        public void Run()
        {
            _consoleGameOutput.DisplayWelcomeMessage();
            var questionCount = _gameInput.GetQuestionCount();
            _questionManager.SetupQuestions(questionCount);

            while (_questionManager.AreQuestionsLeft)
            {
                _consoleGameOutput.OutputPlayerTurn(_gameState);

                var (question, expectedAnswer) = _questionManager.GetNextQuestion();

                _consoleGameOutput.DisplayQuestion(question);

                var userAnswer = _gameInput.GetAnswer();

                if (userAnswer == expectedAnswer)
                {
                    _gameState.CorrectAnswer();
                    _consoleGameOutput.CorrectAnswer();
                }
                else
                {
                    _gameState.IncorrectAnswer();
                    _consoleGameOutput.IncorrectAnswer(expectedAnswer);
                }

                _consoleGameOutput.OutputScores(_gameState);
                _consoleGameOutput.OutputRemainingQuestion(_questionManager);

                _gameState.SwapPlayer();
            }

            _consoleGameOutput.OutputFinalScore(_gameState);
            Console.ReadKey();
        }
    }
}