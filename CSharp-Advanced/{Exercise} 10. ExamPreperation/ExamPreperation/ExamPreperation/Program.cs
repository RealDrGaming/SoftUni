List<string> peaksToClimb = new List<string>
{
    "Vihren",
    "Kutelo",
    "Banski Suhodol",
    "Polezhan",
    "Kamenitza"
};

List<string> peaksClimbed = new List<string>();

Stack<int> dailyFood = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> dailyStamina = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

while (dailyFood.Count > 0 && dailyStamina.Count > 0)
{
    if (peaksToClimb.Contains("Vihren"))
    {
        if (dailyStamina.Dequeue() + dailyFood.Pop() >= 80)
        {
            peaksToClimb.Remove("Vihren");
            peaksClimbed.Add("Vihren");
        }
    }
    else if (peaksToClimb.Contains("Kutelo"))
    {
        if (dailyStamina.Dequeue() + dailyFood.Pop() >= 90)
        {
            peaksToClimb.Remove("Kutelo");
            peaksClimbed.Add("Kutelo");
        }
    }
    else if (peaksToClimb.Contains("Banski Suhodol"))
    {
        if (dailyStamina.Dequeue() + dailyFood.Pop() >= 100)
        {
            peaksToClimb.Remove("Banski Suhodol");
            peaksClimbed.Add("Banski Suhodol");
        }
    }
    else if (peaksToClimb.Contains("Polezhan"))
    {
        if (dailyStamina.Dequeue() + dailyFood.Pop() >= 60)
        {
            peaksToClimb.Remove("Polezhan");
            peaksClimbed.Add("Polezhan");
        }
    }
    else if (peaksToClimb.Contains("Kamenitza"))
    {
        if (dailyStamina.Dequeue() + dailyFood.Pop() >= 70)
        {
            peaksToClimb.Remove("Kamenitza");
            peaksClimbed.Add("Kamenitza");
        }
    }
    else
    {
        break;
    }
}

if (peaksToClimb.Count == 0)
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
else
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}

if (peaksToClimb.Count < 5)
{
    Console.WriteLine("Conquered peaks:");
    foreach (var item in peaksClimbed)
    {
        Console.WriteLine(item);
    }
}