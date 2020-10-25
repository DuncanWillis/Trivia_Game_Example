namespace Trivia_Game {
    public static class IntExtensions
    {
        public static int ToEvenNumber(this int number)
        {
            return number % 2 == 0 ? number : --number;
        }
    }
}