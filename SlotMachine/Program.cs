using System.Runtime.InteropServices;

namespace SlotMachine
{
    internal class Program
    {
        const double MONEY_AMOUNT = 2;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Slot Machine Game");
            Console.WriteLine("Here are few rules on how to play the game");
            Console.WriteLine("Press 1 if you want to play center line" +
                              "\nPress 2 if you want to play horizontal lines" +
                              "\nPress 3 if you want to play vertical lines" +
                              "\nPress 4 if you want to play diagonal line" +
                              "\nPress 5 if you want to play all lines" +
                              "\n Each line cost 2 dollars. So if you select 5 then it will cost you 10 dollars");
           
            int[,] slotMachineArray = new int[3, 3];

            bool continueToPlay = false;
            double moneyWon = 0;

            do
            {
                string input = Console.ReadLine();
                Random rnd = new Random();

                for (int i = 0; i < slotMachineArray.GetLength(0); i++)
                {
                    for (int j = 0; j < slotMachineArray.GetLength(1); j++)
                    {
                        slotMachineArray[i, j] = rnd.Next(0, 2);
                        
                    }
                }
                OutputArray(slotMachineArray);

                if (input == "1") //center line
                {
                    if (slotMachineArray[1, 0] == slotMachineArray[1, 1] &&
                        slotMachineArray[1, 1] == slotMachineArray[1, 2])
                        
                    {
                        Console.WriteLine("Congrats you won");
                        moneyWon += MONEY_AMOUNT;
                    }
                    else
                    {
                        Console.WriteLine("Bad Luck you lost");
                    }


                }

                if (input == "2")
                {
                    if ((slotMachineArray[0, 0] == slotMachineArray[0, 1] && slotMachineArray[0, 1] == slotMachineArray[0, 2]) ||
                        (slotMachineArray[1, 0] == slotMachineArray[1, 1] && slotMachineArray[1, 1] == slotMachineArray[1, 2]) ||
                        (slotMachineArray[2, 0] == slotMachineArray[2, 1] && slotMachineArray[2, 1] == slotMachineArray[2, 2]))
                    {
                        Console.WriteLine("Congrats you won");
                        moneyWon += MONEY_AMOUNT;
                    }
                    else
                    {
                        Console.WriteLine("Bad Luck you lost");
                    }

                }

                Console.WriteLine("Press Y to continue to play");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() == "y")
                {
                    continueToPlay = true;
                    Console.WriteLine("Please select options again");
                }



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