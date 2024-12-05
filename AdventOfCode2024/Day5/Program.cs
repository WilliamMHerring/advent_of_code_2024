string[] input = await File.ReadAllLinesAsync("input.txt");


List<KeyValuePair<int, int>> keyValuePairs = new List<KeyValuePair<int, int>>();
List<List<int>> pageLines = new List<List<int>>();
foreach (string line in input)
{
    if (line.Contains('|'))
    {
        string[] parts = line.Split('|');
        int left = int.Parse(parts[0]);
        int right = int.Parse(parts[1]);
        string combined = $"{parts[0]}{parts[1]}";
        int combinedInt = int.Parse(combined);
        keyValuePairs.Add(new KeyValuePair<int, int>(left, right));
    }

    else if (line.Contains(','))
    {
        List<int> pages = new List<int>();
        string[] parts = line.Split(",");
        foreach (var part in parts)
        {
            pages.Add(int.Parse(part));
        }
        pageLines.Add(pages);
    }
}
int total = 0;
//PART 1
//foreach (List<int> line in pageLines)
//{
//    bool incorrectOrder = false;
//    foreach (int page in line)
//    {
//        List<KeyValuePair<int, int>> printFirstRules = keyValuePairs.Where(o => o.Key == page).ToList();
//        incorrectOrder = printFirstRules.Any(rule =>
//        {
//            if (line.Contains(rule.Value) && line.IndexOf(rule.Value) < line.IndexOf(page))
//            {
//                return true;
//            }
//            return false;
//        });
//        if (incorrectOrder)
//        {
//            break;
//        }
//    }

//    if (!incorrectOrder)
//    {
//        int middle = line[line.Count / 2];
//        total += middle;
//    }

//}

//PART 2
foreach (List<int> line in pageLines)
{
    bool incorrectOrder = false;
    foreach (int page in line)
    {
        List<KeyValuePair<int, int>> printFirstRules = keyValuePairs.Where(o => o.Key == page).ToList();
        incorrectOrder = printFirstRules.Any(rule =>
        {
            if (line.Contains(rule.Value) && line.IndexOf(rule.Value) < line.IndexOf(page))
            {
                return true;
            }
            return false;
        });
        if (incorrectOrder)
        {
            break;
        }
    }

    if (incorrectOrder)
    {
        line.Sort((right, left) =>
        {
            var hasRule = keyValuePairs.Any(r => r.Key == left && r.Value == right);

            if (hasRule)
            {
                return 1;
            }

            return -1;
        });

        int middle = line[line.Count / 2];
        total += middle;
    }

}

Console.WriteLine(total);
Console.ReadLine();