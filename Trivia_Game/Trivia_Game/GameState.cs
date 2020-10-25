namespace Trivia_Game {
    public class GameState
    {
        private int _currentPlayer = 1;
        private int _player1Score = 0;
        private int _player2Score = 0;

        public int CurrentPlayer => _currentPlayer;
        public int Player1Score => _player1Score;
        public int Player2Score => _player2Score;

        public void IncorrectAnswer()
        {
            if (_currentPlayer == 1)
            {
                _player1Score--;
            }
            else
            {
                _player2Score--;
            }
        }

        public void CorrectAnswer()
        {
            if (_currentPlayer == 1)
            {
                _player1Score++;
            }
            else
            {
                _player2Score++;
            }
        }

        public void SwapPlayer()
        {
            _currentPlayer = _currentPlayer == 1 ? 2 : 1;
        }

        public int GetPlayerScore(int gameStateCurrentPlayer)
        {
            return CurrentPlayer == 1 ? _player1Score : _player2Score;
        }

        public string GetWinner()
        {
            if (_player1Score == _player2Score)
                return string.Empty;

            return _player1Score > _player2Score ? "Player 1" : "Player 2";
        }
    }
}