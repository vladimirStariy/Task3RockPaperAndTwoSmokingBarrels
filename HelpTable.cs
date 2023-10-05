using ConsoleTables;

namespace Task3RockPaperAndTwoSmokingBarrels
{
    public class HelpTable
    {
        private string[,] matrix;
        private int length;

        public HelpTable(MovesList movesList)
        {
            length = movesList.Items.Length+1;
            matrix = new string[length, length];
            FillMatrix(movesList);
        }

        private void FillMatrix(MovesList movesList)
        {
            matrix[0, 0] = "Bot/User";
            for(int i = 0; i < movesList.Items.Length; i++)
            {
                matrix[0, i+1] = movesList.Items[i].Name;
                matrix[i+1, 0] = movesList.Items[i].Name;
            }

            for(int i = 0; i < movesList.Items.Length;i++)
            {
                for(int j = 0; j < movesList.Items.Length; j++)
                {
                    if (movesList.Items[i].Id == movesList.Items[j].Id)
                    {
                        matrix[i + 1, j + 1] = "Draw";
                    }
                    else
                    {
                        var max = Math.Max(movesList.Items[i].Id, movesList.Items[j].Id);
                        if (movesList.Items[i].Id < movesList.Items[j].Id)
                        {
                            var a_dist = max - movesList.Items[i].Id;
                            if (a_dist <= movesList.offset)
                            {
                                matrix[i + 1, j + 1] = "Lose";
                            }
                            else
                            {
                                matrix[i + 1, j + 1] = "Win";
                            }
                 
                        }
                        else
                        {
                            var a_dist = movesList.Items.Count() - max + movesList.Items[j].Id;

                            if (a_dist <= movesList.offset)
                            {
                                matrix[i + 1, j + 1] = "Lose";
                            }
                            else
                            {
                                matrix[i + 1, j + 1] = "Win";
                            }
                        }
                    }
                }
            }
        }

        private string[] GetMax()
        {
            string[] max = new string[length];

            for (int i = 0; i < length; i++)
            {
                max[i] = "";
                for (int j = 0; j < length; j++)
                {
                    if (matrix[i,j].Length > max[i].Length)
                    {
                        max[i] = matrix[i,j];
                    }
                }
            }

            return max;
        }

        private void PrintStr(string[] values, int offsetSpace)
        {
            for (int xr = 0; xr < length; xr++)
            {
                for (int xy = 0; xy < values[xr].Length + offsetSpace + 1; xy++)
                {
                    Console.Write("=");
                }
            }
            Console.Write("=");
        }

        private void PrintLowStr(string[] values, int offsetSpace)
        {
            for (int xr = 0; xr < length; xr++)
            {
                for (int xy = 0; xy < values[xr].Length + offsetSpace + 1; xy++)
                {
                    Console.Write("-");
                }
            }
            Console.Write("-");
        }

        public void Print()
        {
            string [] maxArray = GetMax();
            int offsetSpace = 2;

            PrintStr(maxArray, offsetSpace);

            for (int i = 0; i < length; i++)
            {
                if(i!=0)
                    PrintLowStr(maxArray, offsetSpace);
                Console.WriteLine();
                for (int j = 0; j < length; j++)
                {
                    if(j == 0)
                        Console.Write('|');

                    if (matrix[i, j] == "Draw")
                    { 
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else if (matrix[i, j] == "Win")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (matrix[i, j] == "Lose")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.ResetColor();

                    Console.Write("{0,-" + (maxArray[j].Length + offsetSpace) + "}", matrix[i, j]);
                    Console.ResetColor();
                    Console.Write('|');
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            PrintStr(maxArray, offsetSpace);
            Console.WriteLine();
        }
    }

}
