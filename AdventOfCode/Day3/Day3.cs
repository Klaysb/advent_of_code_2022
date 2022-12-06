namespace AdventOfCode.Day3;

public class Day3
{
    public static void Run_Day3()
    {
        var rucksacks = File.ReadAllLines("Day3/input.txt");

        var prioritySum = PrioritySum(rucksacks);
        var threePrioritySum = ThreePrioritySum(rucksacks);
        
        Console.WriteLine("Day 3:");
        Console.WriteLine($"\tPriority sum: {prioritySum}");
        Console.WriteLine($"\tThree priority sum: {threePrioritySum}");
        Console.WriteLine();
    }

    public static int PrioritySum(IEnumerable<string> rucksacks)
    {
        var totalSum = 0;

        foreach (var rucksack in rucksacks)
        {
            var firstHalf = rucksack[..(rucksack.Length / 2)];
            var secondHalf = rucksack[(rucksack.Length / 2)..];

            var repeatedItem = firstHalf.FirstOrDefault((item) => secondHalf.Contains(item), '.');

            switch (repeatedItem)
            {
                case >= 'a' and <= 'z':
                    totalSum += repeatedItem - 96;
                    break;
                case >= 'A' and <= 'Z':
                    totalSum += repeatedItem - 38;
                    break;
            }
        }

        return totalSum;
    }

    public static int ThreePrioritySum(IEnumerable<string> rucksacks)
    {
        var totalSum = 0;
        
        for (var index = 0; index < rucksacks.Count(); index += 3)
        {
            var sacks = rucksacks
                .Take(new Range(index, index + 3))
                .ToArray();
            
            var repeatedItem = sacks[0]
                .FirstOrDefault((item) => sacks[1].Contains(item) && sacks[2].Contains(item), '.');
            
            switch (repeatedItem)
            {
                case >= 'a' and <= 'z':
                    totalSum += repeatedItem - 96;
                    break;
                case >= 'A' and <= 'Z':
                    totalSum += repeatedItem - 38;
                    break;
            }
        }
        
        return totalSum;
    }
}