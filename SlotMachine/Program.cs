
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
            
            double startingCredit = 10;
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
                int selectedOption;
                int wonLines = 0;
                int totalLinesWonPlayingAllLines = 0;
                double moneyWon = 0;

                Console.WriteLine($"Your current credit is {startingCredit} USD");

                if (startingCredit <= 0)
                {
                    Console.WriteLine("Sorry you cant play anymore as you have no credit remaining");
                    break;
                }
                
                do
                {
                    isInputValid = int.TryParse(Console.ReadLine(), out selectedOption);
                    
                    if (selectedOption > 8 || selectedOption <= 0)
                    {
                        isInputValid = false;
                    }

                    if (!isInputValid)
                    {
                        Console.WriteLine("Wrong input, Please select valid option");
                        
                    }
                    
                } while (!isInputValid);

                if (selectedOption == 8)
                {
                    startingCredit -= 8;
                }
                else
                {
                    startingCredit -= 1;
                }

                for (int i = 0; i < slotMachineArray.GetLength(0); i++)
                {
                    for (int j = 0; j < slotMachineArray.GetLength(1); j++)
                    {
                        slotMachineArray[i, j] = rnd.Next(0, 2);

                    }
                }
                OutputArray(slotMachineArray);

                if (selectedOption == 1) //center line and middle horizontal row
                {
                    if (slotMachineArray[1, 0] == slotMachineArray[1, 1] &&
                        slotMachineArray[1, 1] == slotMachineArray[1, 2])
                    {
                        wonLines++;
                    }
                   
                }
                else if (selectedOption == 2) //Top horizontal row
                {
                    if ((slotMachineArray[0, 0] == slotMachineArray[0, 1] && slotMachineArray[0, 1] == slotMachineArray[0, 2]))
                    {
                        wonLines++;
                    }
                }

                else if (selectedOption == 3) //bottom horizontal row
                {
                    if ((slotMachineArray[2, 0] == slotMachineArray[2, 1] && slotMachineArray[2, 1] == slotMachineArray[2, 2]))
                    {
                        wonLines++;
                    }
                }

                else if (selectedOption == 4) //left vertical row
                {
                    if ((slotMachineArray[0, 0] == slotMachineArray[1, 0] && slotMachineArray[1, 0] == slotMachineArray[2, 0]))
                    {
                        wonLines++;
                    }
                }

                else if (selectedOption == 5) //middle vertical row
                {
                    if ((slotMachineArray[0, 1] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[2, 1]))
                    {
                        wonLines++;
                    }
                }

                else if (selectedOption == 6) //right vertical row
                {
                    if ((slotMachineArray[0, 2] == slotMachineArray[1, 2] && slotMachineArray[1, 2] == slotMachineArray[2, 2]))
                    {
                        wonLines++;
                    }
                }

                else if (selectedOption == 7) //diagonal lines
                {
                    if (slotMachineArray[2, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[0, 2])
                    {
                        wonLines++;
                    }
                    if (slotMachineArray[0, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[2, 2])
                    {
                        wonLines++;
                    }
                }

                else if (selectedOption == 8) //all lines
                {
                    if (slotMachineArray[0, 0] == slotMachineArray[0, 1] && slotMachineArray[0, 1] == slotMachineArray[0, 2]) //Top horizontal row
                    {
                        wonLines += 1;
                    }

                    if ((slotMachineArray[1, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[1, 2]))  //center line and middle horizontal row
                    {
                        wonLines += 1;
                    }

                    if (slotMachineArray[2, 0] == slotMachineArray[2, 1] && slotMachineArray[2, 1] == slotMachineArray[2, 2])  //bottom horizontal
                    {
                        wonLines += 1;
                    }

                    if ((slotMachineArray[0, 0] == slotMachineArray[1, 0] && slotMachineArray[1, 0] == slotMachineArray[2, 0])) //left vertical row
                    {
                        wonLines += 1;
                    }

                    if ((slotMachineArray[0, 1] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[2, 1])) //middle vertical row
                    {
                        wonLines += 1;
                    }

                    if ((slotMachineArray[0, 2] == slotMachineArray[1, 2] && slotMachineArray[1, 2] == slotMachineArray[2, 2])) //right vertical row
                    {
                        wonLines += 1;
                    }

                    if (slotMachineArray[2, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[0, 2])  //diagonal line
                    {
                        wonLines += 1;
                    }

                    if (slotMachineArray[0, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[2, 2])  //diagonal line
                    {
                        wonLines += 1;
                    }
                }

                if (wonLines > 0)
                {
                    startingCredit += (WIN_MONEY_AMOUNT_PER_LINE * wonLines);
                    Console.WriteLine($"Congrats you won. You won {WIN_MONEY_AMOUNT_PER_LINE} dollars");
                }
                else
                {
                    startingCredit -= (1 * wonLines);
                    Console.WriteLine($"Bad Luck you lost. Now you have {startingCredit} USD credit remaining");
                }

                Console.WriteLine("Press Y to continue to play");
                
                if (continueToPlay = Console.ReadLine().ToLower() == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Please select options again");
                }
                else
                {
                    continueToPlay = false;
                }

                Console.WriteLine($"Amount won so far is {startingCredit} USD");
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