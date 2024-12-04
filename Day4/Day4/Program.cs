using System.Text.RegularExpressions;

string[] input = await File.ReadAllLinesAsync("input.txt");

int count = 0;
int count2 = 0;

//PART 1
for (int i = 0; i < input.Length; i++)
{
    string line = input[i];
    count += Regex.Matches(line, "XMAS").Count;
    count += Regex.Matches(line, "SAMX").Count;

    for (int j = 0; j < line.Length; j++)
    {
        if (getRightDiag(input, i, j)) { count++; }
        if (getLeftDiag(input, i, j)) { count++; }
        if (getVerticalDown(input, i, j)) { count++; }
    }

}

//PART 2
for (int i = 0; i < input.Length; i++)
{
    string line = input[i];
    for (int j = 0; j < line.Length; j++)
    {
        if (getRightDiagPart2(input, i, j))
        {
            if (getLeftDiagPart2(input, i, j + 2))
            {
                count2++;
            }
        }
    }

}

Console.WriteLine(count);
Console.WriteLine(count2);
Console.ReadLine();

bool getVerticalDown(string[] input, int startRow, int startIndex)
{
    if (startRow + 4 <= input.Length)
    {
        string xmas = "";
        for (int i = startRow; i < startRow + 4; i++)
        {
            xmas += input[i][startIndex];
        }

        if (xmas.ToLower() == "xmas" || xmas.ToLower() == "samx") 
        { 
            return true; 
        }
    }
    return false;
}

//PART 1
bool getRightDiag(string[] input, int startRow, int startIndex)
{
    if (startRow + 3 < input.Length && startIndex + 3 < input[startRow].Length)
    {
        string xmas = "";
        for (int i = 0; i < 4; i++)
        {
            string row = input[i + startRow];
            char nextChar = row[startIndex + i];
            xmas += nextChar;
        }

        if (xmas.ToLower() == "xmas" || xmas.ToLower() == "samx")
        {
            return true;
        }
    }
    return false;
}

bool getLeftDiag(string[] input, int startRow, int startIndex)
{
    if (startRow + 3 < input.Length && startIndex - 3 >= 0)
    {
        string xmas = "";
        for (int i = 0; i < 4; i++)
        {
            string row = input[i + startRow];
            char nextChar = row[startIndex - i];
            xmas += nextChar;
        }

        if (xmas.ToLower() == "xmas" || xmas.ToLower() == "samx")
        {
            return true;
        }
    }

    return false;
}

//PART 2
bool getRightDiagPart2(string[] input, int startRow, int startIndex)
{
    if (startRow + 2 < input.Length && startIndex + 2 < input[startRow].Length)
    {
        string xmas = "";
        for (int i = 0; i < 3; i++)
        {
            string row = input[i + startRow];
            char nextChar = row[startIndex + i];
            xmas += nextChar;
        }

        if (xmas.ToLower() == "mas" || xmas.ToLower() == "sam")
        {
            return true;
        }
    }

    return false;
}

bool getLeftDiagPart2(string[] input, int startRow, int startIndex)
{
    if (startRow + 2 < input.Length)
    {
        string xmas = "";
        for (int i = 0; i < 3; i++)
        {
            string row = input[i + startRow];
            char nextChar = row[startIndex - i];
            xmas += nextChar;
        }

        if (xmas.ToLower() == "mas" || xmas.ToLower() == "sam")
        {
            return true;
        }
    }

    return false;
}