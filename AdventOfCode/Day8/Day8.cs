namespace AdventOfCode.Day8;

public class Day8
{
    public static void Run_Day8()
    {
        var lines = File.ReadAllLines("Day8/input.txt");
       
        var visibleTrees = VisibleTrees(lines);
        var maxScenicScore = MaxScenicScore(lines);

        Console.WriteLine("Day 8:");
        Console.WriteLine($"\tVisible trees: {visibleTrees}");
        Console.WriteLine($"\tMax scenic score: {maxScenicScore}");
        Console.WriteLine();
    }

    public static int VisibleTrees(IEnumerable<string> lines)
    {
        var matrix = lines
            .Select(line => line
                .Select(character => int.Parse(character.ToString()))
                .ToArray())
            .ToArray();

        var count = 0;
        for (var i = 1; i < matrix.Length - 1; i++)
        {
            for (var j = 1; j < matrix[i].Length - 1; j++)
            {
                var blockedCount = 0;
                // check left
                for (var index = j - 1; index >= 0; index--)
                {
                    if (matrix[i][index] < matrix[i][j]) continue;
                    blockedCount++;
                    break;
                }
                
                // check right
                for (var index = j + 1; index < matrix[i].Length; index++)
                {
                    if (matrix[i][index] < matrix[i][j]) continue;
                    blockedCount++;
                    break;
                }
                
                // check up
                for (var index = i - 1; index >= 0; index--)
                {
                    if (matrix[index][j] < matrix[i][j]) continue;
                    blockedCount++;
                    break;
                }
                
                // check down
                for (var index = i + 1; index < matrix[i].Length; index++)
                {
                    if (matrix[index][j] < matrix[i][j]) continue;
                    blockedCount++;
                    break;
                }

                if (blockedCount != 4)
                {
                    count++;
                }
            }
            
        }

        return count + 4 * (matrix.Length - 1);
    }
    
    public static int MaxScenicScore(IEnumerable<string> lines)
    {
        var matrix = lines
            .Select(line => line
                .Select(character => int.Parse(character.ToString()))
                .ToArray())
            .ToArray();

        var maxScenicScore = 0;
        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                var currentScenicScore = 1;
                // check left
                for (var index = j - 1; index >= 0; index--)
                {
                    if (matrix[i][index] < matrix[i][j] && index > 0) continue;
                    currentScenicScore *= j - index;
                    break;
                }
                
                // check right
                for (var index = j + 1; index < matrix[i].Length; index++)
                {
                    if (matrix[i][index] < matrix[i][j] && index < matrix[i].Length - 1) continue;
                    currentScenicScore *= index - j;
                    break;
                }
                
                // check up
                for (var index = i - 1; index >= 0; index--)
                {
                    if (matrix[index][j] < matrix[i][j] && index > 0) continue;
                    currentScenicScore *= i - index;
                    break;
                }
                
                // check down
                for (var index = i + 1; index < matrix[i].Length; index++)
                {
                    if (matrix[index][j] < matrix[i][j] && index < matrix[i].Length - 1) continue;
                    currentScenicScore *= index - i;
                    break;
                }

                if (currentScenicScore > maxScenicScore)
                {
                    maxScenicScore = currentScenicScore;
                }
            }
            
        }

        return maxScenicScore;
    }
}