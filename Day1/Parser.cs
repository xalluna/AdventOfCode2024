using System.Text.RegularExpressions;
using Common;

namespace Day1;

public partial class ListParsingStrategy(string filename): AbstractParsingStrategy<(List<int> First, List<int> Second)>(filename)
{
    private readonly Regex _numberListRegex = MyRegex();

    public override (List<int> First, List<int> Second) Parse()
    {
        var reader = new StreamReader(_stream);
        
        var list1 = new List<int>();
        var list2 = new List<int>();

        while (reader.Peek() > 0)
        {
            var line = reader.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            
            var match = _numberListRegex.Match(line);
            
            var values = match.Groups.Values.Select(x => x.Value).ToList();

            int.TryParse(values[1], out var item1);
            int.TryParse(values[2], out var item2);
            
            list1.Add(item1);
            list2.Add(item2);
        }

        return (list1, list2);
    }

    [GeneratedRegex(@"(\d+)\s+(\d+)")]
    private static partial Regex MyRegex();
}

public class PartOneStrategy(List<int> list1, List<int> list2)
{
    public int Execute()
    {
        var sortedList1 = list1.Order();
        var sortedList2 = list2.Order();

        var zippedList = sortedList1.Zip(sortedList2);

        return zippedList.Sum(x => Math.Abs(x.First - x.Second));
    }
}

public class PartTwoStrategy(List<int> list1, List<int> list2)
{
    private readonly Dictionary<int, int> _dictionary = new();
    
    public int Execute()
    {
        list2.ForEach(x =>
        {
            var success = _dictionary.TryGetValue(x, out var value);
            
            if (!success)
            {
                _dictionary.TryAdd(x, 1);
                return;
            }

            _dictionary[x] += 1;
        });

        return list1.Sum(x =>
        {
            _dictionary.TryGetValue(x, out var value);
            return x * value;
        });
    }
}
