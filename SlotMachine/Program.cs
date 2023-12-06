
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

                SlotMachine.PrintRulesToConsole();
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

                SlotMachine.OutputArray(slotMachineArray);

                wonLines = SlotMachine.RowsWon(selectedOption, slotMachineArray);

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
    }
}