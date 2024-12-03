using System.Text.RegularExpressions;

string input = await File.ReadAllTextAsync("input.txt");

//PART 1
//string regex = "mul\\([0-9]{1,3},[0-9]{1,3}\\)";

//var matches = Regex.Matches(input, regex);

//int total = 0;

//foreach (Match match in matches)
//{
//    string text = match.Value.Remove(match.Value.Length - 1, 1).Remove(0, 4);
//    string[] parts = text.Split(',');
//    int left = int.Parse(parts[0]);
//    int right = int.Parse(parts[1]);
//    total += left * right;
//}

//Console.WriteLine(total);
//Console.ReadLine();

//PART 2
string regex = "mul\\([0-9]{1,3},[0-9]{1,3}\\)|do\\(\\)|don\\'t\\(\\)";

var matches = Regex.Matches(input, regex);

int total = 0;
bool multiply = true;
foreach (Match match in matches)
{
    if (match.Value == "do()")
    {
        multiply = true;
        continue;
    }
    else if (match.Value == "don't()")
    {
        multiply = false;
        continue;
    }
    else if (multiply)
    {
        string text = match.Value.Remove(match.Value.Length - 1, 1).Remove(0, 4);
        string[] parts = text.Split(',');
        int left = int.Parse(parts[0]);
        int right = int.Parse(parts[1]);
        total += left * right;
    }

}

Console.WriteLine(total);
Console.ReadLine();