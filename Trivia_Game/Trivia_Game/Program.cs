using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Trivia_Game
{
    class Program
    { 
        static void Main(string[] args)
        {
            //members
            int player = 2;                      
            int player1Score = 0;
            int player2Score = 0;
            Random Generator = new Random();
            Console.WriteLine("Welcome to the Quiz!");
            Console.WriteLine("Please enter how many questions you would each like to answer");
            int input = int.Parse(Console.ReadLine());
            var numbers = Enumerable.Range(0, input*4).ToArray();
            int q;

            //the loop
            do
            {
                //change of player
                if (player == 2)
                {
                    player = 1;

                }
                else if (player == 1)
                {
                    player = 2;
                }

                //Random question generator
                var numbersList = numbers.ToList();
                int selector = Generator.Next(numbers.Length);
                int selection = numbers[selector];
                if (selection % 2 == 0)
                {
                    q = selection; //even
                }
                else
                {
                    q = --selection; //odd
                }

                //Asking and answering the questions
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Player {0}, It's your turn", player);
                string lineq = File.ReadLines(@"/Users\Duncan\Desktop\Mac Visual Studio C#\Projects\Personal Practise\Trivia_Game\Quiz_master.txt").Skip(q).Take(1).First();
                Console.WriteLine(lineq);
                string linea = File.ReadLines(@"/Users\Duncan\Desktop\Mac Visual Studio C#\Projects\Personal Practise\Trivia_Game\Quiz_master.txt").Skip(++q).Take(1).First();
                //Console.WriteLine(lineq);
                string inputi = Console.ReadLine();
                if (inputi == linea)
                {
                    Console.WriteLine("Correct! :) ");
                    if (player == 1)
                    {
                        player1Score++;
                        Console.WriteLine("Player {0} has score {1}", player, player1Score);
                    }
                    else
                    {
                        player2Score++;
                        Console.WriteLine("Player {0} has score {1}", player, player2Score);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect! :( ");
                    if (player == 1)
                    {
                        Console.WriteLine(linea);
                        Console.WriteLine("Player {0} has score {1}", player, player1Score);
                    }
                    else
                    {
                        Console.WriteLine(linea);
                        Console.WriteLine("Player {0} has score {1}", player, player2Score);
                    }

                }
                //editing the list of questions
                numbersList.Remove(selection);
                numbersList.Remove(++selection);
                numbers = numbersList.ToArray();
                Console.WriteLine("There are {0} questions remaining", (numbers.Length / 2));
                //deciding the winner
                if(numbers.Length == 0)
                {
                    if (player1Score > player2Score)
                    {
                        Console.WriteLine("Congratulations!, Player 1 is the winner!");
                    }else if (player2Score > player1Score)
                    {
                        Console.WriteLine("Congratulations!, Player 2 is the winner!");
                    }
                    else
                    {
                        Console.WriteLine("It's a draw");
                    }
                    Console.WriteLine("Player 1 has {0} points // Player 2 has {1} points",player1Score,player2Score);
                }

            } while (numbers.Length != 0);
            

            

            Console.ReadKey();

           
        }
    }
}
