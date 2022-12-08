namespace AdventOfCode.Day4;

public class Day4
{
    public static void Run_Day4()
    {
        var assignments = File.ReadAllLines("Day4/input.txt");

        var assignmentPairs = AssignmentPairs(assignments);
        var assignmentPairsOverlap = AssignmentPairsOverlap(assignments);

        Console.WriteLine("Day 4:");
        Console.WriteLine($"\tAssignment pairs: {assignmentPairs}");
        Console.WriteLine($"\tAssignment pairs overlap: {assignmentPairsOverlap}");
        Console.WriteLine();
    }

    public static int AssignmentPairs(IEnumerable<string> assignments)
    {
        return assignments
            .Select(assignment => assignment
                .Split(',') // { "2-4", "6-8" }
                .Select(pair => pair.Split('-').Select(int.Parse).ToArray()) // { [2,4], [6,8] }
                .Select(pair => (pair[0], pair[1])) // { (2,4), (6,8) }
                .ToArray()) // [ (2,4), (6,8) ]
            .Count(pairs => 
                pairs[0].Item1 >= pairs[1].Item1 && pairs[0].Item2 <= pairs[1].Item2 || 
                pairs[1].Item1 >= pairs[0].Item1 && pairs[1].Item2 <= pairs[0].Item2);
    }
    
    public static int AssignmentPairsOverlap(IEnumerable<string> assignments)
    {
        return assignments
            .Select(assignment => assignment
                .Split(',') // { "2-4", "6-8" }
                .Select(pair => pair.Split('-').Select(int.Parse).ToArray()) // { [2,4], [6,8] }
                .Select(pair => (pair[0], pair[1])) // { (2,4), (6,8) }
                .ToArray()) // [ (2,4), (6,8) ]
            .Count(pairs => 
                pairs[0].Item2 >= pairs[1].Item1 && pairs[0].Item2 <= pairs[1].Item2 ||
                pairs[1].Item2 >= pairs[0].Item1 && pairs[1].Item2 <= pairs[0].Item2);
    }
}