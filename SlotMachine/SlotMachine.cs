namespace SlotMachine
{
    internal class SlotMachine
    {
        public static bool CompareHorizontalRows(int[,] passedSlotMachineArray, int rowNumber)
        {
            if (passedSlotMachineArray[rowNumber, 0] == passedSlotMachineArray[rowNumber, 1] &&
                passedSlotMachineArray[rowNumber, 1] == passedSlotMachineArray[rowNumber, 2])
            {
                return true;
            }
            return false;

        }

        public static bool CompareVerticalRows(int[,] passedSlotMachineArray, int rowNumber)
        {
            if ((passedSlotMachineArray[0, rowNumber] == passedSlotMachineArray[1, rowNumber] &&
                 passedSlotMachineArray[1, rowNumber] == passedSlotMachineArray[2, rowNumber]))
            {
                return true;
            }
            return false;
        }

        public static bool CompareDiagonalRows(int[,] passedSlotMachineArray, int rowNumber1, int rowNumber2)
        {
            if (passedSlotMachineArray[rowNumber1, 0] == passedSlotMachineArray[1, 1]
                && passedSlotMachineArray[1, 1] == passedSlotMachineArray[rowNumber2, 2])
            {
                return true;
            }
            return false;
        }

        public static int RowsWon(int selectedOption, int[,] slotMachineArray)
        {
            int wonLines = 0;
            if (selectedOption == (int)RowsEnum.MiddleHorizontalRow && SlotMachine.CompareHorizontalRows(slotMachineArray, 1))
            {
                wonLines++;
            }
            else if (selectedOption == (int)RowsEnum.TopHorizontalRow && SlotMachine.CompareHorizontalRows(slotMachineArray, 0))
            {
                wonLines++;
            }
            else if (selectedOption == (int)RowsEnum.BottomHorizontalRow && SlotMachine.CompareHorizontalRows(slotMachineArray, 2))
            {
                wonLines++;
            }
            else if (selectedOption == (int)RowsEnum.LeftVerticalRow && SlotMachine.CompareVerticalRows(slotMachineArray, 0))
            {
                wonLines++;
            }
            else if (selectedOption == (int)RowsEnum.MiddleVerticalRow && SlotMachine.CompareVerticalRows(slotMachineArray, 1))
            {
                wonLines++;
            }
            else if (selectedOption == (int)RowsEnum.RightVerticalRow && SlotMachine.CompareVerticalRows(slotMachineArray, 2))
            {
                wonLines++;
            }
            else if (selectedOption == (int)RowsEnum.DiagonalRow)
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
            else if (selectedOption == (int)RowsEnum.AllRows)
            {
                for (int i = 0; i <= 2; i++)
                {
                    if (SlotMachine.CompareHorizontalRows(slotMachineArray, i))
                    {
                        wonLines++;
                    }

                    if (SlotMachine.CompareVerticalRows(slotMachineArray, i))
                    {
                        wonLines++;
                    }
                }

                if (SlotMachine.CompareDiagonalRows(slotMachineArray, 2, 0))
                {
                    wonLines += 1;
                }

                if (SlotMachine.CompareDiagonalRows(slotMachineArray, 0, 2))
                {
                    wonLines += 1;
                }
            }

            return wonLines;
        }
    }
}
