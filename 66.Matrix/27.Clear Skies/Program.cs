
int N = int.Parse(Console.ReadLine());

char[][] air = new char[N][];

for (int i = 0; i < air.Length; i++)
{
    air[i] = Console.ReadLine().Trim().ToCharArray();
}

int currentRow = -1;
int currentCol = -1;
int enemyCrafts = 0;
int armor = 300;

InitialPosition(air, ref currentRow, ref currentCol, ref enemyCrafts);


while (armor > 0 && enemyCrafts > 0 )
{
    string command = Console.ReadLine();

    air[currentRow][currentCol] = '-';

    switch (command)
    {
        case"up":
            currentRow--;
            break;

        case "down":
            currentRow++;
            break;

        case "left":
            currentCol--;
            break;

        case "right":
            currentCol++;
            break;
    }


    if (air[currentRow][currentCol] == 'E')
    {
        armor -= 100;
        enemyCrafts--;
    }
    else if (air[currentRow][currentCol] == 'R')
    {
        armor = 300;
    }

    air[currentRow][currentCol] = 'J';

}



if (armor <= 0 )
{
    Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
}
else
{
    Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
}

for (int i = 0; i < air.Length; i++)
{
    Console.WriteLine($"{string.Join("", air[i])}");
}


static void InitialPosition(char[][] air, ref int currentRow, ref int currentCol, ref int enemyCrafts)
{
    for (int i = 0; i < air.Length; i++)
    {
        for (int j = 0; j < air[i].Length; j++)
        {
            if (air[i][j] == 'J')
            {
                currentRow = i;
                currentCol = j;                
            }
            else if (air[i][j] == 'E')
            {
                enemyCrafts++;
            }
        }
    }
}
