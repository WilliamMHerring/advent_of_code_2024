string[] input = await File.ReadAllLinesAsync("input.txt");

int safeCount = 0;
foreach (string line in input)
{
    string[] parts = line.Split(' ');
    List<int> report = parts.Select(x => int.Parse(x)).ToList();

    //PART 1
    //if (IsSafe(report))
    //{
    //    safeCount++;
    //}

    //PART 2
    for (int i = 0; i < report.Count; i++)
    {
        var newReport = new List<int>(report);
        newReport.RemoveAt(i);
        if (IsSafe(newReport))
        {
            safeCount++;
            break;
        }
    }
}

Console.WriteLine(safeCount);


static bool IsSafe(List<int> report)
{
    int sign = Math.Sign(report[1] - report[0]);
    bool safe = report
        .Zip(report.Skip(1), (n1, n2) => n2 - n1)
        .All(d => Math.Sign(d) == sign && Math.Abs(d) is >= 1 and <= 3);

    if (safe)
    {
        return true;
    }

    return false;
}