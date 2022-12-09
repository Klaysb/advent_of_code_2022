using System.Text.RegularExpressions;

namespace AdventOfCode.Day5;

public class Day5
{
    public static void Run_Day5()
    {
        var rearrangementLines = File.ReadAllLines("Day5/input.txt");
       
        var rearrangement = CreateRearrangement(rearrangementLines);
        var topCrates = TopCrates(rearrangement.Item1, rearrangement.Item2);
        
        rearrangement = CreateRearrangement(rearrangementLines);
        var topCrates9001 = TopCrates9001(rearrangement.Item1, rearrangement.Item2);

        Console.WriteLine("Day 5:");
        Console.WriteLine($"\tTop crates: {topCrates}");
        Console.WriteLine($"\tTop crates 9001: {topCrates9001}");
        Console.WriteLine();
    }

    public static (Dictionary<int, LinkedList<string>>, IEnumerable<(int, int, int)>) CreateRearrangement(
        IEnumerable<string> lines)
    {
        using var enumerator = lines.GetEnumerator();
        
        var cratesDictionary = new Dictionary<int, LinkedList<string>>();
        while (enumerator.MoveNext() && enumerator.Current.Contains('['))
        {
            int crateIndex = -1, lineIndex = 0;
            foreach (var currentValue in enumerator.Current.Split(' '))
            {
                if (currentValue == string.Empty)
                {
                    lineIndex++;
                    continue;
                }
                
                var crateValue = Regex.Match(currentValue, "\\[([\\w]+)\\]").Groups[1].Value;
                crateIndex += lineIndex / 4 + 1;
                
                if (!cratesDictionary.ContainsKey(crateIndex))
                {
                    cratesDictionary[crateIndex] = new LinkedList<string>();
                }
                
                cratesDictionary[crateIndex].AddLast(crateValue);
                lineIndex = 0;
            }
        }
        
        enumerator.MoveNext();
        var directions = new List<(int, int, int)>();
        while (enumerator.MoveNext())
        {
            var direction = enumerator.Current
                .Split(' ')
                .Where(str => int.TryParse(str, out _))
                .Select(int.Parse)
                .ToArray();
            
            directions.Add((direction[0], direction[1] - 1, direction[2] - 1));
        }

        return (cratesDictionary, directions);
    }

    public static string TopCrates(Dictionary<int, LinkedList<string>> stacks, IEnumerable<(int, int, int)> directions)
    {
        // direction -> (unit, from, to)
        foreach (var direction in directions)
        {
            var amountToMove = direction.Item1;
            while (amountToMove-- > 0)
            {
                var stack = stacks[direction.Item2];
                var crate = stack.First();
                stack.RemoveFirst();
                stacks[direction.Item3].AddFirst(crate);
            }
        }
        
        return string.Join(string.Empty, stacks.OrderBy(stack => stack.Key).Select(stack => stack.Value.First()));
    }
    
    public static string TopCrates9001(Dictionary<int, LinkedList<string>> stacks, IEnumerable<(int, int, int)> directions)
    {
        // direction -> (unit, from, to)
        foreach (var direction in directions)
        {
            var amountToMove = direction.Item1;
            var cratesToMove = new Stack<string>();
            
            while (amountToMove-- > 0)
            {
                var stack = stacks[direction.Item2];
                var crate = stack.First();
                stack.RemoveFirst();
                cratesToMove.Push(crate);
            }

            foreach (var crate in cratesToMove)
            {
                stacks[direction.Item3].AddFirst(crate);
            }
        }
        
        return string.Join(string.Empty, stacks.OrderBy(stack => stack.Key).Select(stack => stack.Value.First()));
    }
}