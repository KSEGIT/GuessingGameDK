/*
Guessing Game Challenge
Author: Daniel Kiska <daniel.kiska@gmail.com>
Created: 23 / 10 / 2023
Updated: 23 / 10 / 2023
*/

using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        //Starting with simple cmd interface.
        Console.WriteLine("Welcome to Guessing Game Challenge\n by Daniel Kiska\n");
        Console.WriteLine("Choose a game mode option:");
        Console.WriteLine("(1) Computer will guess your number, (No cheating! :) )");
        Console.WriteLine("(2) You will try to guess computer number");

        //User options in requirements are to input 1 or 2 on keyboard. Program should not allow to input null or any other value.
        try
        {
            int option= int.Parse(Console.ReadLine()); //Using parse for better error handling.
            if (option == 1)
            {
                ComputerGuessNumber();
            }
            else if (option == 2)
            {
                HumanGuessNumber();
            }
            else
            {
                Console.WriteLine("Invalid input choice. Please restart and select option 1 or 2 on your keyboard.");
            }
        }
        //Catching Possible errors in the main loop when parsing input.
        catch (FormatException)
        {
            Console.WriteLine("Error: Parsing failed. Input is not a valid integer.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Error: Parsing failed. Input is null.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: An unexpected error occurred: " + ex.Message);
        }
    }

    //Function for Computer guessing User number game using binary serach.
    static void ComputerGuessNumber()
    {
        //Variable initialization
        Console.WriteLine("Think of a number between 1 and 10,000.");
        int min = 1;
        int max = 10000;
        int guess;
        string userResponse;

        //Background:
        //Binary search is an efficient algorithm for finding an item from a sorted list of items.
        //For binary search, the total iterations required to find a number would be atmost log2(total_array_size)
        //log2(10 000) = 13.29, so computer should always guess our number in maximum of 14 attempts

        //using do/while loop becouse I want to first block be executed atleast once.
        do
        {
            //Guessing the number.
            guess = (min + max) / 2;
            Console.WriteLine("Computer guess is: [" + guess + "], please let computer know if his guesed number is:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(1) Too low, (2) Too high, (3) Correct!");
            Console.ForegroundColor = ConsoleColor.Gray;
            userResponse = Console.ReadLine();

            //Handling User response.
            if (userResponse == "1")
            {
                min = guess + 1;
            }
            else if (userResponse == "2")
            {
                max = guess - 1;
            }
            else if (userResponse != "3")
            {
                Console.WriteLine("Error: Invalid user response. Please enter number 1, 2, or 3.");
            }
        } while (userResponse != "3");

        //Finishing the game.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Computer guessed your number!!! Thank you for playing.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    //Function for User guessing Computer number game using binary serach.
    static void HumanGuessNumber()
    {
        //Generating computer choice.
        Random random = new Random();
        int computerChoice = random.Next(1, 10000); // Dont know what do you ment by keeping it secret? (not showing to the user?)
        Console.WriteLine(computerChoice); //For debug only
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Computer generated a random number between 1 and 10 000 try to guess it!");
        Console.ForegroundColor = ConsoleColor.Gray;

        //Handling user guessing
        int userGuess = 0;

        do
        {
            //Error handling for user input
            try
            {
                Console.WriteLine("Please provide your guessed number: ");
                userGuess = int.Parse(Console.ReadLine());

                //Setting range for user input.
                if (userGuess < 1 || userGuess > 10000)
                {
                    Console.WriteLine("Error: Guess out of range, please provide correct number");
                }
                else if (userGuess == computerChoice)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have guessed Computer number!!! Thank you for playing!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (userGuess < computerChoice)
                {
                    Console.WriteLine("Too low.");
                }
                else if (userGuess > computerChoice)
                {
                    Console.WriteLine("Too high.");
                }
                else
                {
                    Console.WriteLine("Error: Invalid user response. Please enter number you are trying to guess.");
                }
            }
            //Catching Possible errors when parsing input.
            catch (FormatException)
            {
                Console.WriteLine("Error: Parsing failed. Input is not a valid integer.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Error: Parsing failed. Input is null.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: An unexpected error occurred: " + ex.Message);
            }
        //Keeping loop going until user guess computer number
        } while (userGuess != computerChoice);
    }
}
