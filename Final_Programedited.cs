using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;

namespace Yhatzee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Yahtzee");
            Console.WriteLine("Here are your five dice:");
            Console.ReadLine();
            Random random = new Random();
            Dice one = new Dice(random.Next(1, 6));
            Dice two = new Dice(random.Next(1, 6));
            Dice three = new Dice(random.Next(1, 6));
            Dice four = new Dice(random.Next(1, 6));
            Dice five = new Dice(random.Next(1, 6));
            //Create five random dice

            int reRollsLeft = 3;
            //Int to represent how many rools are left, there are three roles

            ArrayList diceArray = new ArrayList();
            //Created an array list for the dice
            diceArray.Add(one);
            diceArray.Add(two);
            diceArray.Add(three);
            diceArray.Add(four);
            diceArray.Add(five);

            //Added five dice to the array list 



            for (int i = 0; i < diceArray.Count; i++)
            {
                Dice temp = (Dice)diceArray[i];
                temp.getValue();
                Console.WriteLine(temp.getValue());
                //Created a temp variable to hold the dice number 
                //the temp variable will get a dice number from the dice array
            }

            while (reRollsLeft > 0)
            {
                Console.WriteLine("Would you like to re-roll, you can do so up to three times including this time Y/N");
                string answer = Console.ReadLine();
                //Console asks player if they want to reroll, and the player can answer in a string
                if (answer == "Y")
                {
                    reRollsLeft--;
                    for (int i = 0; i < diceArray.Count; i++)
                    {
                        Dice temp = (Dice)diceArray[i];

                        Console.Write("Dice " + i + "  Has a value of " + temp.getValue());
                        Console.WriteLine();
                        //Lists the final dice number

                    }
                    Console.WriteLine("Enter the dice you would like to re-roll");
                    string pool = Console.ReadLine();
                    List<int> diceChoices = pool.Split(',').Select(int.Parse).ToList();
                    //This allows the player to enter the number of the dice they want to change seperated by commas
                    for (int i = 0; i < diceChoices.Count; i++)
                    {
                        Dice temp = (Dice)diceArray[diceChoices[i]];
                        temp.setValue(random.Next(1, 6));
                    }
                    for (int i = 0; i < diceArray.Count; i++)
                    {
                        Dice temp = (Dice)diceArray[i];
                        Console.Write(" Dice " + i + " Now has a value of " + temp.getValue());
                        Console.WriteLine("");
                        //Lists the final dice number
                    }

                }
                else
                {
                    reRollsLeft--;
                    Console.WriteLine("You frofeited your re-roll and now have " + reRollsLeft);
                    //If they player writes N or something other then Y then it will mean that they did not want to reroll
                }

            }
            for (int i = 0; i < diceArray.Count; i++)
            {
                Dice temp = (Dice)diceArray[i];
                Console.WriteLine("Final Value for Dice " + i + " is " + temp.getValue());
                //Will list all of the final numbers of the dice 

            }
            {// created location for the player to add responses named answer
                string answer;
                Console.WriteLine("Three of a kind: Get three dice with the same number | Y or N ");
                answer = Console.ReadLine();
                if (answer == "Y")
                    // if and else statements to give the player a score
                {
                    int number1;
                    Console.Write("Enter the number: ");
                    number1 = Convert.ToInt32(Console.ReadLine());
                    // converts the entered number into an integer that can be calculated
                    Console.WriteLine("First game score" + (number1 * 3));
                    Console.ReadLine();
                }

                else
                {

                    Console.WriteLine("Four of a kind: Get four dice with the same number.| Y or N ");
                    if (answer == "Y")
                    {
                        int number1;
                        Console.Write("Enter the number: ");
                        number1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("First game score" + (number1 * 4));
                        Console.ReadLine();
                    }

                    else
                    {

                        Console.WriteLine("Full house: Get three of a kind and a pair | Y or N");
                        if (answer == "Y")
                        {
                            int number1;
                            int number2;
                            Console.Write("Enter the 1st number: ");
                            Console.Write("Enter the 2nd number: ");
                            number1 = Convert.ToInt32(Console.ReadLine());
                            number2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("First game score" + ((number1 * 3) + (number1 * 2)));
                            Console.ReadLine();
                        }
                        else
                        {
                            {
                                Console.WriteLine("Small straight: Get four sequential dice | Y or N");
                            }
                            if (answer == "yes")
                            {
                                Console.WriteLine("First game score:" + (30));
                                Console.ReadLine();
                            }
                            else

                            {
                                Console.WriteLine("Large straight: Get four sequential dice Y or N");
                                if (answer == "Y")
                                {
                                    Console.WriteLine("First game score:" + (40));
                                    Console.ReadLine();
                                }
                                else
                                {

                                    Console.WriteLine("YAHTZEE: Five of a kind.| Y or N ");
                                    if (answer == "Y")
                                    {
                                        Console.WriteLine("First game score:" + (50));
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("First game score:" + (0));
                                        Console.ReadLine();
                                    }


                                    {// this sends the player to a website with the price of the game if they wish to purchase
                                        String answer6;
                                        Console.WriteLine("Would you like to purchase the full Game? | Y OR N?");
                                        answer6 = Console.ReadLine();
                                        if (answer6 == "Y")
                                        {
                                            var prs = new ProcessStartInfo("chrome.exe");
                                            prs.Arguments = "https://www.walmart.com/ip/Yahtzee-Game/878158";
                                            Process.Start(prs);
                                        }// show price of yahtzee on website
                                        else
                                        { // if players no then they can escape the game to stop
                                            Console.Write("Press <Escape> to exit... ");
                                            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
          } 





        class Dice
        //Created a class named dice
        {
            int x = 0;
            public Dice(int y)
            {
                x = y;
            }
            public int getValue()
            {
                return x;
            }
            public void setValue(int y)
            {
                x = y;
            }
        }
    }

  }




    







    


