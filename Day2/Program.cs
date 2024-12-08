using Day2;

var parser = new ReportParsingStrategy("input.txt");

var reports = parser.Parse();

reports.ForEach(x => x.SetStrategy(new DayOneReportStrategy()));
Console.WriteLine(reports.Count(x => x.IsSafe));

reports.ForEach(x => x.SetStrategy(new DayTwoReportStrategy()));
Console.WriteLine(reports.Count(x => x.IsSafe));