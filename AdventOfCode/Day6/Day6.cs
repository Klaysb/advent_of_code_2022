namespace AdventOfCode.Day6;

public class Day6
{
    public static void Run_Day6()
    {
        var line = string.Join(string.Empty, File.ReadAllLines("Day6/input.txt"));
       
        var packetMarker = PacketMarker(line);
        var messageMarker = MessageMarker(line);

        Console.WriteLine("Day 6:");
        Console.WriteLine($"\tPacket marker: {packetMarker}");
        Console.WriteLine($"\tMessage marker: {messageMarker}");
        Console.WriteLine();
    }

    public static int PacketMarker(string line)
    {
        var characterSet = new LinkedList<char>();
        for (var index = 0; index < line.Length; index++)
        {
            var currentChar = line[index];
            
            if (characterSet.Contains(currentChar))
            {
                while (characterSet.First() != currentChar)
                {
                    characterSet.RemoveFirst();
                }
                characterSet.RemoveFirst();
            }
            
            characterSet.AddLast(currentChar);

            if (characterSet.Count != 0 && characterSet.Count % 4 == 0)
            {
                return index + 1;
            }
        }

        return -1;
    }
    
    public static int MessageMarker(string line)
    {
        var characterSet = new LinkedList<char>();
        for (var index = 0; index < line.Length; index++)
        {
            var currentChar = line[index];
            
            if (characterSet.Contains(currentChar))
            {
                while (characterSet.First() != currentChar)
                {
                    characterSet.RemoveFirst();
                }
                characterSet.RemoveFirst();
            }
            
            characterSet.AddLast(currentChar);

            if (characterSet.Count != 0 && characterSet.Count % 14 == 0)
            {
                return index + 1;
            }
        }

        return -1;
    }
}