using System.Text.RegularExpressions;
using Common;

namespace Day2;

public partial class ReportParsingStrategy(string filename): AbstractParsingStrategy<List<Report>>(filename)
{
    public override List<Report> Parse()
    {
        var reader = new StreamReader(_stream);
        var reports = new List<Report>();

        while (reader.Peek() > 0)
        {
            var line = reader.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var numbers = line.Split(' ');

            var report = new Report();
            
            foreach (var number in numbers)
            {
                report.AddData(int.Parse(number));    
            }
            
            reports.Add(report);
        }

        return reports;
    }
}

public class PartOneStrategy(List<Report> reports)
{
    public int Execute()
    {
        return reports.Count(x => x.IsSafe);
    }
}