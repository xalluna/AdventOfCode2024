using Day2;

var parser = new ReportParsingStrategy("input.txt");

var reports = parser.Parse();

var partOne = new PartOneStrategy(reports);

Console.WriteLine(partOne.Execute());