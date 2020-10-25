namespace Trivia_Game {
    public interface IGameOutput
    {
        public void DisplayWelcomeMessage();
        public void DisplayQuestion(string question);
        public void OutputScores(GameState gameState);
        public void CorrectAnswer();
        public void IncorrectAnswer(string actualAnswer);
        public void OutputRemainingQuestion(QuestionManager questionManager);
        public void OutputFinalScore(GameState gameState);
        public void OutputPlayerTurn(GameState gameState);
    }
}