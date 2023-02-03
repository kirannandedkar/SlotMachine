using System.Runtime.InteropServices;

namespace SlotMachine
{
    internal class Program
    {
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
            string input = Console.ReadLine();
            int[,] slotMachineArray = new int[3, 3];

            bool continueToPlay = false;
            int moneyWon = 0;

            do
            {
                Random rnd = new Random();

                for (int i = 0; i < slotMachineArray.GetLength(0); i++)
                {
                    for (int j = 0; j < slotMachineArray.GetLength(1); j++)
                    {
                        slotMachineArray[i, j] = rnd.Next(0, 2);
                    }
                }

                if (input == "1") //center line
                {
                    if (slotMachineArray[1, 0] == slotMachineArray[1, 1] &&
                        slotMachineArray[1, 1] == slotMachineArray[1, 2])
                    {
                        Console.WriteLine("Congrats you won");
                    }
                    else
                    {
                        Console.WriteLine("Bad Luck you lost");
                    }


                }

                if (input == "2")
                {

                }

                Console.WriteLine("Press Y to continue to play");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() == "y")
                {
                    continueToPlay = true;
                }



            } while (continueToPlay);
            

        }
    }
}