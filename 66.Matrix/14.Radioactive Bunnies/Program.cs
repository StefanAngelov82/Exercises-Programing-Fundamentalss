using System;
using System.Linq;

namespace Radioactive_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[][] layer = new char[rowCol[0]][];

            for (int i = 0; i < layer.Length; i++)
            {
                layer[i] = Console.ReadLine().ToCharArray();
            }

            char[] commands = Console.ReadLine().ToCharArray();

            int oldPlayerY = 0;
            int oldPlayerX = 0;
            int playerY = 0;
            int playerX = 0;

            PlayerInitialPosition(layer, ref playerY, ref playerX);

            oldPlayerX = playerX;
            oldPlayerY = playerY;

            bool isDead = false;
            bool isWin = false;
            int count = 0;

            while (!isDead && !isWin)
            {
                PlayerCurrentPosition(commands, ref playerY, ref playerX, ref count);

                if ((playerY < 0 || playerY >= layer.Length) ||
                    (playerX < 0 || playerX >= layer[0].Length))
                {
                    isWin = true;
                }

                if (!isWin && layer[playerY][playerX] == 'B')
                {
                    isDead = true;
                }

                layer[oldPlayerY][oldPlayerX] = '.';

                if (!isDead && !isWin)
                {
                    layer[playerY][playerX] = 'P';
                }              

                isDead = BREED(layer, isDead);               

                if (!isDead && !isWin)
                {
                    oldPlayerX = playerX;
                    oldPlayerY = playerY;
                }
            }

            foreach (var array in layer)
            {
                Console.WriteLine(string.Join("", array));
            }

            if (isDead)
            {
                Console.WriteLine($"dead: {playerY} {playerX}");
            }
            else
            {
                Console.WriteLine($"won: {oldPlayerY} {oldPlayerX}");
            }
        }

        private static bool BREED(char[][] layer, bool isDead)
        {
            for (int i = 0; i < layer.Length; i++)
            {
                for (int j = 0; j < layer[i].Length; j++)
                {
                    if (layer[i][j] == 'B')
                    {
                        int incrementI = i + 1;
                        int decrementI = i - 1;
                        int incrementJ = j + 1;
                        int decrementJ = j - 1;

                        if (decrementI >= 0)
                        {
                            if (layer[i - 1][j] == '.')
                            {
                                layer[i - 1][j] = '*';
                            }
                            else if (layer[i - 1][j] == 'P')
                            {
                                layer[i - 1][j] = '*';
                                isDead = true;
                            }
                        }

                        if (incrementI < layer.Length)
                        {
                            if (layer[i + 1][j] == '.')
                            {
                                layer[i + 1][j] = '*';
                            }
                            else if (layer[i + 1][j] == 'P')
                            {
                                layer[i + 1][j] = '*';
                                isDead = true;
                            }
                        }

                        if (decrementJ >= 0)
                        {
                            if (layer[i][j - 1] == '.')
                            {
                                layer[i][j - 1] = '*';
                            }
                            else if (layer[i][j - 1] == 'P')
                            {
                                layer[i][j - 1] = '*';
                                isDead = true;
                            }
                        }

                        if (incrementJ < layer[i].Length)
                        {
                            if (layer[i][j + 1] == '.')
                            {
                                layer[i][j + 1] = '*';
                            }
                            else if (layer[i][j + 1] == 'P')
                            {
                                layer[i][j + 1] = '*';
                                isDead = true;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < layer.Length; i++)
            {
                for (int j = 0; j < layer[i].Length; j++)
                {
                    if (layer[i][j] == '*')
                    {
                        layer[i][j] = 'B';
                    }
                }
            }

            return isDead;
        }

        private static void PlayerCurrentPosition(char[] commands, ref int playerY, ref int playerX, ref int count)
        {
            if      (commands[count] == 'U') playerY--;
            else if (commands[count] == 'D') playerY++;
            else if (commands[count] == 'L') playerX--;
            else if (commands[count] == 'R') playerX++;

            count++;
        }

        private static void PlayerInitialPosition(char[][] layer, ref int playerY, ref int playerX)
        {
            for (int i = 0; i < layer.Length; i++)
            {
                for (int j = 0; j < layer[i].Length; j++)
                {
                    if (layer[i][j] == 'P')
                    {
                        playerY = i;
                        playerX = j;
                        return;
                    }
                }
            }
        }
    }
}
