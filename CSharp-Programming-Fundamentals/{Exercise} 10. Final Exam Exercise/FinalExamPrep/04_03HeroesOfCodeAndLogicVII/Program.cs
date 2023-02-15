using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPrep
{
    class Hero 
    {
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }
    }

    class HeroesOfCodeAndLogicVII
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split(" ");

                Hero hero = new Hero();
                hero.HitPoints = int.Parse(args[1]);
                hero.ManaPoints = int.Parse(args[2]);

                heroes.Add(args[0], hero);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandInfo = command.Split(" - ");
                string commandName = commandInfo[0];
                string heroName = commandInfo[1];

                if (commandName == "CastSpell")
                {
                    int manaPointsNeeded = int.Parse(commandInfo[2]);
                    string spellName = commandInfo[3];

                    if (heroes[heroName].ManaPoints >= manaPointsNeeded)
                    {
                        heroes[heroName].ManaPoints -= manaPointsNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].ManaPoints} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (commandName == "TakeDamage")
                {
                    int damage = int.Parse(commandInfo[2]);
                    string attacker = commandInfo[3];

                    if (heroes[heroName].HitPoints > damage)
                    {
                        heroes[heroName].HitPoints -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HitPoints} HP left!");
                    }
                    else
                    {
                        heroes.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (commandName == "Recharge")
                {
                    int amount = int.Parse(commandInfo[2]);

                    int actualAmount = Math.Min(amount, 200 - heroes[heroName].ManaPoints);

                    heroes[heroName].ManaPoints += actualAmount;

                    Console.WriteLine($"{heroName} recharged for {actualAmount} MP!");
                }
                else if (commandName == "Heal")
                {
                    int amount = int.Parse(commandInfo[2]);

                    int actualAmount = Math.Min(amount, 100 - heroes[heroName].HitPoints);

                    heroes[heroName].HitPoints += actualAmount;

                    Console.WriteLine($"{heroName} healed for {actualAmount} HP!");
                }

                command = Console.ReadLine();
            }

            foreach (var (heroName, hero) in heroes)
            {
                Console.WriteLine($"{heroName}");
                Console.WriteLine($"  HP: {hero.HitPoints}");
                Console.WriteLine($"  MP: {hero.ManaPoints}");
            }
        }
    }
}