namespace SlotMachine
{
    internal class Program
    {
        const double WIN_MONEY_AMOUNT_PER_LINE = 2;
        const double STARTING_CREDIT = 10;

        static void Main(string[] args)
        {
            double TOTAL_CREDIT = STARTING_CREDIT;
            Console.WriteLine("Welcome to Slot Machine Game");
            Console.WriteLine("Here are few rules on how to play the game");
            int columnLength = 3;
            int rows = 3;
            int[,] slotMachineArray = new int[columnLength, rows];
                
            bool continueToPlay;
            Random rnd = new Random();
            bool isInputValid = false;
            do
            {
                int selectedOption = 0;
                int wonLines = 0;

                UIPresenter.PrintRulesToConsole();
                Console.WriteLine($"Your current credit is {TOTAL_CREDIT} USD");

                if (TOTAL_CREDIT <= 0)
                {
                    Console.WriteLine("Sorry you cant play anymore as you have no credit remaining");
                    break;
                }

                UIPresenter.PlayTilValidInputIsEntered(selectedOption1: selectedOption, totalCredit: TOTAL_CREDIT, isInputValid1: isInputValid);
                                

                if(selectedOption == (int)RowsEnum.AllRows)
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

                UIPresenter.OutputArray(slotMachineArray);

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