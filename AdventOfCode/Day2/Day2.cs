namespace AdventOfCode.Day2;

public class Day2
{
    public static void Run_Day2()
    {
        var guide = File.ReadAllLines("Day2/input.txt");

        var totalScore = TotalScore(guide);
        var totalScoreCorrect = TotalScoreCorrect(guide);
        
        Console.WriteLine("Day 2:");
        Console.WriteLine($"\tTotal score: {totalScore}");
        Console.WriteLine($"\tTotal score correct: {totalScoreCorrect}");
        Console.WriteLine();
    }

    public static int TotalScore(IEnumerable<string> guide)
    {
        var score = 0;
        var losingPlay = new Dictionary<int, int> {
            {1, 3},
            {2, 1},
            {3, 2}
        };


        foreach (var entry in guide)
        {
            var splitEntry = entry.Split(' ');
            var opponentPlay = char.Parse(splitEntry[0]) - 64;
            var myPlay = char.Parse(splitEntry[1]) - 87;

            if (opponentPlay == myPlay)
            {
                score += 3;
            }
            else if (opponentPlay == losingPlay[myPlay])
            {
                score += 6;
            }

            score += myPlay;
        }
        
        return score;
    }
    
    public static int TotalScoreCorrect(IEnumerable<string> guide)
    {
        var score = 0;
        var losingPlay = new Dictionary<int, int> {
            {1, 3},
            {2, 1},
            {3, 2}
        };


        foreach (var entry in guide)
        {
            var splitEntry = entry.Split(' ');
            var opponentPlay = char.Parse(splitEntry[0]) - 64;
            var myPlay = char.Parse(splitEntry[1]);

            switch (myPlay)
            {
                case 'Y':
                    score += 3 + opponentPlay;
                    break;
                case 'X':
                    score += losingPlay[opponentPlay];
                    break;
                case 'Z':
                    score += 6 + losingPlay.First(pair => pair.Value == opponentPlay).Key;
                    break;
            }
        }
        
        return score;
    }
}