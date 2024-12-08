using System.Text.RegularExpressions;
using Common;

namespace Day3;

public partial class DayOneParser(string filename) : AbstractParsingStrategy<List<Multiplicand>>(filename)
{
    private readonly Regex _regex = MyRegex();
    
    public override List<Multiplicand> Parse()
    {
        var reader = new StreamReader(_stream);
        var multiplicands = new List<Multiplicand>();
        
        while (reader.Peek() > 0)
        {
            var line = reader.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            
            var matches = _regex.Matches(line);

            if (matches.Count == 0)
            {
                continue;
            }

            foreach (Match match in matches)
            {
                int.TryParse(match.Groups[1].Value, out var x);
                int.TryParse(match.Groups[2].Value, out var y);
                
                multiplicands.Add(new Multiplicand(x,y));
            }
        }
        
        return multiplicands;
    }

    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex MyRegex();
}


public partial class DayTwoParser(string filename) : AbstractParsingStrategy<List<string>>(filename)
{
    private readonly Regex _tokenRegex = TokenRegex();
    
    public override List<string> Parse()
    {
        var reader = new StreamReader(_stream);
        var tokens = new List<string>();
        
        while (reader.Peek() > 0)
        {
            var line = reader.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }
            
            var matches = _tokenRegex.Matches(line);

            if (matches.Count == 0)
            {
                continue;
            }

            tokens.AddRange(matches.Select(x => x.Value));
        }
        
        return tokens;
    }
    
    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)")]
    private static partial Regex TokenRegex(); 
}