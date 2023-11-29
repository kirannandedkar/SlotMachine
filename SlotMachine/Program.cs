
namespace SlotMachine
{
    internal class Program
    {
        const double WIN_MONEY_AMOUNT_PER_LINE = 2;
        private static double TOTAL_CREDIT = 10;


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Slot Machine Game");
            Console.WriteLine("Here are few rules on how to play the game");
            
            int[,] slotMachineArray = new int[3, 3];
                
            bool continueToPlay;
            Random rnd = new Random();
            bool isInputValid;
            do
            {
                int selectedOption;
                int wonLines = 0;

                PrintRulesToConsole();
                Console.WriteLine($"Your current credit is {TOTAL_CREDIT} USD");

                if (TOTAL_CREDIT <= 0)
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
                    else if (selectedOption == 8 && TOTAL_CREDIT < 8)
                    {
                        Console.WriteLine("Sorry you dont have enough credit left. select different input");
                        isInputValid = int.TryParse(Console.ReadLine(), out selectedOption);
                        isInputValid = false;
                    }

                    if (!isInputValid)
                    {
                        Console.WriteLine("Wrong input, Please select valid input");
                        
                    }
                    
                } while (!isInputValid);

                if(selectedOption == 8)
                {
                    TOTAL_CREDIT -= 8;
                }
                else
                {
                    TOTAL_CREDIT -= 1;
                }

                for (int i = 0; i < slotMachineArray.GetLength(0); i++)
                {
                    for (int j = 0; j < slotMachineArray.GetLength(1); j++)
                    {
                        slotMachineArray[i, j] = rnd.Next(0, 2);

                    }
                }
                OutputArray(slotMachineArray);

                
                if (selectedOption == 1 && CompareHorizontalRows(slotMachineArray, 1)) //center line and middle horizontal row
                {
                    wonLines++;
                }
                else if (selectedOption == 2 && CompareHorizontalRows(slotMachineArray, 0)) //Top horizontal row
                {
                        wonLines++;
                }
                else if (selectedOption == 3 && CompareHorizontalRows(slotMachineArray, 2)) //bottom horizontal row
                {
                    wonLines++;
                }
                else if (selectedOption == 4 && CompareVerticalRows(slotMachineArray, 0)) //left vertical row
                {
                    wonLines++;
                }
                else if (selectedOption == 5 && CompareVerticalRows(slotMachineArray, 1)) //middle vertical row
                {
                    wonLines++;
                }
                else if (selectedOption == 6 && CompareVerticalRows(slotMachineArray, 2)) //right vertical row
                {
                    wonLines++;
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
                    for (int i = 0; i <= 2; i++)
                    {
                        if (CompareHorizontalRows(slotMachineArray, i))
                        {
                            wonLines++;
                        }
                    
                        if (CompareVerticalRows(slotMachineArray, i))
                        {
                            wonLines++;
                        }
                    }

                    if(CompareDiagonalRows(slotMachineArray, 2,0))
                    {
                        wonLines += 1;
                    }

                    if(CompareDiagonalRows(slotMachineArray, 0,2))
                    {
                        wonLines += 1;
                    }
                    
                    
                }

                if (wonLines > 0)
                {
                    TOTAL_CREDIT += (WIN_MONEY_AMOUNT_PER_LINE * wonLines);
                    Console.WriteLine($"Congrats you won. You won {WIN_MONEY_AMOUNT_PER_LINE * wonLines} dollars");
                }
                else
                {
                    Console.WriteLine($"Bad Luck you lost. Now you have {TOTAL_CREDIT} USD credit remaining");
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

                Console.WriteLine($"Amount won so far is {TOTAL_CREDIT} USD");
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

        static void PrintRulesToConsole()
        {
            Console.WriteLine("Press 1 if you want to play center line/middle horizontal line" +
                              "\nPress 2 if you want to play top horizontal line" +
                              "\nPress 3 if you want to play bottom horizontal line" +
                              "\nPress 4 if you want to play left vertical line" +
                              "\nPress 5 if you want to play middle vertical line" +
                              "\nPress 6 if you want to play right vertical line" +
                              "\nPress 7 if you want to play diagonal lines" +
                              "\nPress 8 if you want to play all lines" +
                              "\n Each line cost 1 dollar. So if you select input from 1 to 7 then it will cost you 1 dollar and selecting input 8 costs you 8 dollars" +
                              "\n For each winning line you win 2 dollars. So if you win more than 1 line you get no of lines * 2 dollars back" +
                              "\n Please enter your choice of line you want to play");
        }

        static bool CompareHorizontalRows(int[,] passedSlotMachineArray, int lineNumber)
        {
            if (passedSlotMachineArray[lineNumber, 0] == passedSlotMachineArray[lineNumber, 1] &&
                passedSlotMachineArray[lineNumber, 1] == passedSlotMachineArray[lineNumber, 2])
            {
                return true;
            }
            return false;

        }
        static bool CompareVerticalRows(int[,] passedSlotMachineArray, int lineNumber)
        {
            if ((passedSlotMachineArray[0, lineNumber] == passedSlotMachineArray[1, lineNumber] && 
                 passedSlotMachineArray[1, lineNumber] == passedSlotMachineArray[2, lineNumber]))
            {
                return true;
            }
            return false;
        }
        static bool CompareDiagonalRows(int[,] passedSlotMachineArray, int lineNumber1, int lineNumber2)
        {
            if (passedSlotMachineArray[lineNumber1, 0] == passedSlotMachineArray[1, 1] 
                && passedSlotMachineArray[1, 1] == passedSlotMachineArray[lineNumber2, 2])  //diagonal line
            {
                return true;
            }
            return false;
        }
    }
}