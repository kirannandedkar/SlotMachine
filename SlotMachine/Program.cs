
using System.ComponentModel.Design;

namespace SlotMachine
{
    internal class Program
    {
        const double WIN_MONEY_AMOUNT_PER_LINE = 2;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Slot Machine Game");
            Console.WriteLine("Here are few rules on how to play the game");
            
            int[,] slotMachineArray = new int[3, 3];

            bool continueToPlay;
            Random rnd = new Random();
            int[] validInputs = { 1, 2, 3, 4, 5, 6, 7, 8 };
            double moneyWon = 0;
            do
            {
                Console.WriteLine("Press 1 if you want to play center line/middle horizontal line" +
                                  "\nPress 2 if you want to play top horizontal line" +
                                  "\nPress 3 if you want to play bottom horizontal line" +
                                  "\nPress 4 if you want to play left vertical line" +
                                  "\nPress 5 if you want to play middle vertical line" +
                                  "\nPress 6 if you want to play right vertical line" +
                                  "\nPress 7 if you want to play diagonal lines" +
                                  "\nPress 8 if you want to play all lines" +
                                  "\n Each line cost 1 dollar. So if you select 5 then it will cost you 5 dollars" +
                                  "\n For each winning line you win 2 dollars. So if you win more than 1 line you get no of lines * 2 dollars back" +
                                  "\n Please enter your choice of line you want to play");
                

                bool isInputValid;
                int input;
                int wonLines = 0;
                
                do
                {
                    isInputValid = int.TryParse(Console.ReadLine(), out input);
                    
                    foreach (var t in validInputs)
                    {
                        if (t == input)
                        {
                            isInputValid = true;
                        }
                    }

                    if (!isInputValid)
                    {
                        Console.WriteLine("Wrong input, Please select valid option");
                        
                    }
                    
                } while (!isInputValid);

                for (int i = 0; i < slotMachineArray.GetLength(0); i++)
                {
                    for (int j = 0; j < slotMachineArray.GetLength(1); j++)
                    {
                        slotMachineArray[i, j] = rnd.Next(0, 2);

                    }
                }
                OutputArray(slotMachineArray);

                if (input == 1) //center line and middle horizontal row
                {
                    if (slotMachineArray[1, 0] == slotMachineArray[1, 1] &&
                        slotMachineArray[1, 1] == slotMachineArray[1, 2])
                    {
                        wonLines++;
                    }
                   
                }
                else if (input == 2) //Top horizontal row
                {
                    if ((slotMachineArray[0, 0] == slotMachineArray[0, 1] && slotMachineArray[0, 1] == slotMachineArray[0, 2]))
                    {
                        wonLines++;
                    }
                }

                else if (input == 3) //bottom horizontal row
                {
                    if ((slotMachineArray[2, 0] == slotMachineArray[2, 1] && slotMachineArray[2, 1] == slotMachineArray[2, 2]))
                    {
                        wonLines++;
                    }
                }

                else if (input == 4) //left vertical row
                {
                    if ((slotMachineArray[0, 0] == slotMachineArray[1, 0] && slotMachineArray[1, 0] == slotMachineArray[2, 0]))
                    {
                        wonLines++;
                    }
                }

                else if (input == 5) //middle vertical row
                {
                    if ((slotMachineArray[0, 1] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[2, 1]))
                    {
                        wonLines++;
                    }
                }

                else if (input == 6) //right vertical row
                {
                    if ((slotMachineArray[0, 2] == slotMachineArray[1, 2] && slotMachineArray[1, 2] == slotMachineArray[2, 2]))
                    {
                        wonLines++;
                    }
                }

                else if (input == 7) //diagonal lines
                {
                    if ((slotMachineArray[2, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[0, 2]) ||
                        (slotMachineArray[0, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[2, 2]))
                    {
                        wonLines++;
                    }
                }

                else if (input == 8) //all lines
                {
                    int noOfLinesWon = 0;

                    if (slotMachineArray[0, 0] == slotMachineArray[0, 1] && slotMachineArray[0, 1] == slotMachineArray[0, 2]) //Top horizontal row
                    {
                        noOfLinesWon += 1;
                    }

                    if ((slotMachineArray[1, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[1, 2]))  //center line and middle horizontal row
                    {
                        noOfLinesWon += 1;
                    }

                    if (slotMachineArray[2, 0] == slotMachineArray[2, 1] && slotMachineArray[2, 1] == slotMachineArray[2, 2])  //bottom horizontal
                    {
                        noOfLinesWon += 1;
                    }

                    if ((slotMachineArray[0, 0] == slotMachineArray[1, 0] && slotMachineArray[1, 0] == slotMachineArray[2, 0])) //left vertical row
                    {
                        noOfLinesWon += 1;
                    }

                    if ((slotMachineArray[0, 1] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[2, 1])) //middle vertical row
                    {
                        noOfLinesWon += 1;
                    }

                    if ((slotMachineArray[0, 2] == slotMachineArray[1, 2] && slotMachineArray[1, 2] == slotMachineArray[2, 2])) //right vertical row
                    {
                        noOfLinesWon += 1;
                    }

                    if (slotMachineArray[2, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[0, 2])  //diagonal line
                    {
                        noOfLinesWon += 1;
                    }

                    if (slotMachineArray[0, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[2, 2])  //diagonal line
                    {
                        noOfLinesWon += 1;
                    }
                    
                    if (noOfLinesWon == 0)
                    {
                        moneyWon -= 1 * 8;
                        Console.WriteLine($"Bad Luck you lost. Now you have {moneyWon} USD amount remaining");
                    }
                    else
                    {
                        moneyWon += WIN_MONEY_AMOUNT_PER_LINE * noOfLinesWon;
                        Console.WriteLine($"Congrats you won. You have total {moneyWon} dollars");
                    }
                }

                if (wonLines > 0)
                {
                    moneyWon += WIN_MONEY_AMOUNT_PER_LINE ;
                    Console.WriteLine($"Congrats you won. You have total {moneyWon} dollars");
                }
                else
                {
                    moneyWon -= 1;
                    Console.WriteLine($"Bad Luck you lost. Now you have {moneyWon} USD amount remaining");
                }

                Console.WriteLine("Press Y to continue to play");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() == "y")
                {
                    continueToPlay = true;
                    Console.Clear();
                    Console.WriteLine("Please select options again");
                }
                else
                {
                    continueToPlay = false;
                }

                Console.WriteLine($"Amount won so far is {moneyWon} USD");
            } while (continueToPlay);
            

        }

        static void OutputArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i,j] + " ");
                }

                Console.WriteLine("\n");
            }
        }
    }
}