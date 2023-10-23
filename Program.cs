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
                Console.WriteLine("option 1");
            }
            else if (option == 2)
            {
                Console.WriteLine("option 2");
            }
            else
            {
                Console.WriteLine("Invalid input choice. Please restart and select option 1 or 2 on your keyboard.");
            }
        }
        //Catching Possible errors in the main loop.
        catch (FormatException)
        {
            Console.WriteLine("Parsing failed. Input is not a valid integer.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Parsing failed. Input is null.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }

    //Function for Computer guessing User number game using binary serach.
    static void ComputerGuessNumber()
    {
        //Variable initialization
        Console.WriteLine("Think of a number between 1 and 10,000.");
        int lowerBound = 1;
        int upperBound = 10000;
        int guess;
        string userResponse;

        //Background:
        //Binary search is an efficient algorithm for finding an item from a sorted list of items.
        //For binary search, the total iterations required to find a number would be atmost log2(total_array_size)
        //log2(10 000) = 13.29, so computer should always guess our number in maximum of 14 attempts




    }

    //Function for User guessing Computer number game using binary serach.
    static void HumanGuessNumber()
    {
        Console.WriteLine("");
    }

}
