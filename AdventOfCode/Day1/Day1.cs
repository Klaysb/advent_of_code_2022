namespace AdventOfCode.Day1;

public class Day1
{
    public static void Run_Day1()
    {
        var lines = File.ReadAllLines("Day1/input.txt");
        var caloriesList = CreateCaloriesList(lines);

        var caloriesSum = LargestCalories(caloriesList);
        var topThreeCaloriesSum = TopThreeCalories(caloriesList);
        
        Console.WriteLine("Day 1:");
        Console.WriteLine($"\tCalories sum: {caloriesSum}");
        Console.WriteLine($"\tTop three calories sum: {topThreeCaloriesSum}");
        Console.WriteLine();
    }

    public static IEnumerable<int[]> CreateCaloriesList(string[] text)
    {
        for (int index = 0, takeIndex = 0; index < text.Length; index++)
        {
            if (text[index] != "") continue;
            
            yield return text
                .Take(new Range(takeIndex, index))
                .Select(int.Parse)
                .ToArray();

            takeIndex = index + 1;
        }
    }

    public static int LargestCalories(IEnumerable<int[]> calories)
    {
        return calories
            .Select(caloriesList => caloriesList.Sum())
            .Max();
    }
    
    public static int TopThreeCalories(IEnumerable<int[]> calories)
    {
        return calories
            .Select(caloriesList => caloriesList.Sum())
            .OrderByDescending(num => num)
            .Take(3)
            .Sum();
    }
}