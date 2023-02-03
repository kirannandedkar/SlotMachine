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
            
            Random rnd = new Random();
            var s = slotMachineArray.GetLength(0);
            for (int i = 0; i < slotMachineArray.GetLength(0); i++)
            {
                for (int j = 0; j < slotMachineArray.GetLength(0); j++)
                {
                    slotMachineArray[i,j] = rnd.Next(0, 2);
                }
            }
            


        }
    }
}