using Day3;

var parser = new DayOneParser("input.txt");
var multiplicands = parser.Parse();

Console.WriteLine(multiplicands.Sum(x => x.Result));

parser.Dispose();

var dayTwoParser = new DayTwoParser("input.txt");
var multiplicandEvaluator = new MultiplicandEvaluator(dayTwoParser.Parse());

Console.WriteLine(multiplicandEvaluator.Evaluate());