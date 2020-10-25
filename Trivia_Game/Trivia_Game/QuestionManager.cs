using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Trivia_Game {
    public class QuestionManager
    {
        private List<int> _remainingQuestionIndexes;
        private List<string> _questionAndAnswers;

        public int RemainingQuestionCount => _remainingQuestionIndexes.Count;
        public bool AreQuestionsLeft => RemainingQuestionCount > 0;

        private readonly Random _randomNumberGenerator = new Random();

        public void SetupQuestions(in int questionCount)
        {
            _remainingQuestionIndexes = Enumerable.Range(0, questionCount * 2).ToList();
            _questionAndAnswers = File.ReadLines(
                    @"..\..\..\..\Quiz_master.txt")
                .ToList();
        }

        public (string question, string answer) GetNextQuestion()
        {
            var questionIndex = GetRandomSelection();
            var question = _questionAndAnswers.ElementAt(questionIndex);
            var answer = _questionAndAnswers.ElementAt(questionIndex + 1);

            _remainingQuestionIndexes.RemoveAt(questionIndex);
            _remainingQuestionIndexes.RemoveAt(questionIndex);

            return (question, answer);
        }

        private int GetRandomSelection()
        {
            var remainingQuestionListIndex = _randomNumberGenerator.Next(_remainingQuestionIndexes.Count);
            var remainingQuestionIndex = _remainingQuestionIndexes[remainingQuestionListIndex];
            return remainingQuestionIndex.ToEvenNumber();
        }
    }
}