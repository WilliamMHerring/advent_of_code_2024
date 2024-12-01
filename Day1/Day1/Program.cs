string[] input = await File.ReadAllLinesAsync("input.txt");
int total = 0;

List<int> leftList = new List<int>();
List<int> rightList = new List<int>();


for (int i = 0; i < input.Length; i++)
{
    var parts = input[i].Split("   ");
    var left = parts[0];
    var right = parts[1];

    if (int.TryParse(left, out int leftInt) && int.TryParse(right, out int rightInt))
    {
        leftList.Add(leftInt);
        rightList.Add(rightInt);
    }
}

leftList = leftList.OrderBy(x => x).ToList();
rightList = rightList.OrderBy(x => x).ToList();

//PART 1
//for (int i = 0; i < leftList.Count; i++)
//{
//    if (rightList.Count > i)
//    {
//        var left = leftList[i];
//        var right = rightList[i];

//        total += Math.Abs(left - right);
//    }
//}


//PART 2
for (int i = 0; i < leftList.Count; i++)
{
    int matchAmount = 0;
    for (int j = 0; j < rightList.Count; j++)
    {
        if (rightList[j] == leftList[i])
        {
            matchAmount++;
        }
        else if (rightList[j] > leftList[i])
        {
            break;
        }
    }

    int amount = leftList[i] * matchAmount;
    total += amount;
}
Console.WriteLine(total);
Console.ReadLine();