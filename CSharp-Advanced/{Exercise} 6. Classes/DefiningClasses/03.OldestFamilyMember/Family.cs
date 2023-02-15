namespace DefiningClasses;

public class Family
{
    private List<Person> family = new List<Person>();

    public void AddMember(Person member)
    {
        family.Add(member);
    }

    public Person GetOldestMember() 
    {
        Person oldestGuy = new Person();
        int maxAge = int.MinValue;

        foreach (Person currGuy in family)
        {
            if (currGuy.Age > maxAge)
            {
                oldestGuy = currGuy;
                maxAge = currGuy.Age;
            }
        }

        return oldestGuy;
    } 
}