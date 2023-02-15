Queue<string> songs = new (Console.ReadLine().Split(", ").ToArray());

while (songs.Count != 0)
{
    string[] commandInfo = Console.ReadLine().Split();
    string command = commandInfo[0];

    if (command == "Play")
    {
        songs.Dequeue();
    }
    else if (command == "Add")
    {
        string songName = string.Join(" ", commandInfo.Skip(1));

        if (!songs.Contains(songName))
        {
            songs.Enqueue(songName);
        }
        else 
        {
            Console.WriteLine($"{songName} is already contained!");
        }
    }
    else if (command == "Show")
    {
        Console.WriteLine(string.Join(", ", songs));
    }
}

Console.WriteLine("No more songs!");