using System;
using System.Linq;

namespace CourseProject_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare variables 
            char[] Guess_Word = "Hello".ToLower().ToArray();            
            char Letter;
            int Counter = 0, Incorrect_Guess = 0, Max_Guess = 10;
            //promt welcome message
            Console.WriteLine("Welcome to the hangman game! \n\n");

            Console.Write("You have {0} tries to guess this word: " , Max_Guess);
            //displaying the word hidden with special characters
            foreach (var _letter in Guess_Word)
            {
                Console.Write("*");
            };           
  

            Console.Write("\nThe lower the score, the better you did");
            
            //array to hold values
            char[] GuessValues = new char[Guess_Word.Length];
            
            //settin each index to *
            for (var i = 0; i < Guess_Word.Length; i++)
            {
                GuessValues[i] = Convert.ToChar("*");
            }

            
            //run while loop to display message instructions
            while ((Counter <= Max_Guess) || (Guess_Word != GuessValues)) 
            {
                if (GuessValues.SequenceEqual(Guess_Word))
                {
                    Console.WriteLine("Congratulations! You've figured out the word! Your score is: {0}", Incorrect_Guess);
                    break;
                }
                
                if(Max_Guess == 0)
                {
                    Console.WriteLine("Sorry, you did not guess the word!");
                    Console.Write("The correct word was: ");
                    Console.WriteLine(Guess_Word);
                    break;
                }

                //Ask for user input
                Console.Write("\n\nEnter a letter: ");

                Letter = Char.ToLower(Convert.ToChar(Console.ReadLine()));

                //testing to see if the letter is in word
                if (Guess_Word.Contains(Letter))
                {
                    Console.WriteLine("You've guessed correctly!");

                    for (var i = 0; i < Guess_Word.Length; i++)
                    {

                        if (Letter == Guess_Word[i])
                        {
                            GuessValues[i] = Guess_Word[i];
                            
                        }
                        
                    }
                   
                    Console.WriteLine(GuessValues);

                }
                else
                {
                    Incorrect_Guess++;
                    Max_Guess--;                    

                    Console.WriteLine("You've guessed incorrectly!");                    
                    Console.WriteLine(GuessValues);
                    Console.WriteLine("You have {0} remaining", Max_Guess);
                    
                }
                Counter++;
            }
                       
            Console.ReadLine();
            
        }

    }
}
