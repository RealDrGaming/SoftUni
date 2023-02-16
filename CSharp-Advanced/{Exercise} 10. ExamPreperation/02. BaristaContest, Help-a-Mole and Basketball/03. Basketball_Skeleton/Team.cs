using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players { get; set; }
        public int Count { get { return Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (OpenPositions <= 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                Players.Add(player);
                OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Name == name)
                {
                    OpenPositions++;
                    Players.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int removedPlayers = 0;

            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Position == position)
                {
                    Players.RemoveAt(i);
                    removedPlayers++;
                }
            }
            OpenPositions += removedPlayers;
            return removedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Name == name)
                {
                    Players[i].Retired = true;
                    return Players[i];
                }
            }
            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> playersToAward = new List<Player>();

            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Games >= games)
                {
                    playersToAward.Add(Players[i]);
                }
            }

            return playersToAward;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {Group}:");

            foreach (var player in Players)
            {
                if (!player.Retired)
                {
                    sb.AppendLine(player.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}