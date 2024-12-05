using Day1;

var parser = new ListParsingStrategy("input.txt");

var (list1, list2) = parser.Parse();

var partOne = new PartOneStrategy(list1, list2);
var partTwo = new PartTwoStrategy(list1, list2);

Console.WriteLine(partOne.Execute());
Console.WriteLine(partTwo.Execute());
