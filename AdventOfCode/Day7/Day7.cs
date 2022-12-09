namespace AdventOfCode.Day7;

public class Day7
{
    public static void Run_Day7()
    {
        var lines = File.ReadAllLines("Day7/input.txt");
       
        var totalSizes = TotalSizes(lines);
        var totalSizesDelete = TotalSizesDelete(lines);

        Console.WriteLine("Day 7:");
        Console.WriteLine($"\tTotal sizes: {totalSizes}");
        Console.WriteLine($"\tTotal sizes delete: {totalSizesDelete}");
        Console.WriteLine();
    }

    public static int TotalSizes(IEnumerable<string> lines)
    {
        var folderStack = new Stack<string>();
        var foldersDictionary = new Dictionary<string, int>();
        foreach (var line in lines)
        {
            var split = line.Split(' ');

            if (split[0] == "$" && split[1] == "cd")
            {
                if (split[2] == "..")
                {
                    folderStack.Pop();
                }
                else
                {
                    var previousFolder = folderStack.Count == 0 ? "" : $"{folderStack.Peek()}-";
                    var folderName = $"{previousFolder}{split[2]}";
                    foldersDictionary[folderName] = 0;
                    folderStack.Push(folderName);
                }
                continue;
            }

            if (int.TryParse(split[0], out var size))
            {
                foreach (var folder in folderStack)
                {
                    foldersDictionary[folder] += size;
                }
            }
        }
        
        return foldersDictionary.Values.Where(size => size <= 100000).Sum();
    }
    
    public static int TotalSizesDelete(IEnumerable<string> lines)
    {
        var folderStack = new Stack<string>();
        var foldersDictionary = new Dictionary<string, int>();
        foreach (var line in lines)
        {
            var split = line.Split(' ');

            if (split[0] == "$" && split[1] == "cd")
            {
                if (split[2] == "..")
                {
                    folderStack.Pop();
                }
                else
                {
                    var previousFolder = folderStack.Count == 0 ? "" : $"{folderStack.Peek()}-";
                    var folderName = $"{previousFolder}{split[2]}";
                    foldersDictionary[folderName] = 0;
                    folderStack.Push(folderName);
                }
                continue;
            }

            if (int.TryParse(split[0], out var size))
            {
                foreach (var folder in folderStack)
                {
                    foldersDictionary[folder] += size;
                }
            }
        }

        var remaining = 30000000 - (70000000 - foldersDictionary["/"]);
        return foldersDictionary.Values.Where(size => size >= remaining).MinBy(size => size);
    }
}