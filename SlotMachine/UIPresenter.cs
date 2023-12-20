using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public class UIPresenter
    {
        public static void OutputArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine("\n");
            }
        }

        public static void PrintRulesToConsole()
        {
            Console.WriteLine("Press 1 if you want to play center row/middle horizontal row" +
                              "\nPress 2 if you want to play top horizontal row" +
                              "\nPress 3 if you want to play bottom horizontal row" +
                              "\nPress 4 if you want to play left vertical row" +
                              "\nPress 5 if you want to play middle vertical row" +
                              "\nPress 6 if you want to play right vertical row" +
                              "\nPress 7 if you want to play diagonal rows" +
                              "\nPress 8 if you want to play all rows" +
                              "\n Each row cost 1 dollar. So if you select input from 1 to 7 then it will cost you 1 dollar and selecting input 8 costs you 8 dollars" +
                              "\n For each winning row you win 2 dollars. So if you win more than 1 row you get no of rows * 2 dollars back" +
                              "\n Please enter your choice of row you want to play");
        }

        public static void PlayTilValidInputIsEntered(int selectedOption1, double totalCredit, bool isInputValid1)
        {
            do
            {
                isInputValid1 = int.TryParse(Console.ReadLine(), out selectedOption1);
                if (selectedOption1 > (int)RowsEnum.AllRows || selectedOption1 <= 0)
                {
                    isInputValid1 = false;
                }
                else if (selectedOption1 == (int)RowsEnum.AllRows && totalCredit < (int)RowsEnum.AllRows)
                {
                    Console.WriteLine("Sorry you dont have enough credit left. select different input");
                    isInputValid1 = false;
                }

                if (!isInputValid1)
                {
                    Console.WriteLine("Wrong input, Please select valid input");

                }

            } while (!isInputValid1);
        }
    }
}
