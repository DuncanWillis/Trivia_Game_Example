using System;

namespace Trivia_Game {
    public class ConsoleGameInput
    {
        public int GetQuestionCount()
        {
            Console.WriteLine("Please enter how many questions you would each like to answer");
            var input = Console.ReadLine();
            int result; 
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Sorry that's not a number try again");
                input = Console.ReadLine();
            }

            return result;
        }

        public string GetAnswer()
        {
            Console.WriteLine("Please enter your answer:");
            var input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Actually write an answer this time..");
                input = Console.ReadLine();
            }

            return input;
        }
    }
}