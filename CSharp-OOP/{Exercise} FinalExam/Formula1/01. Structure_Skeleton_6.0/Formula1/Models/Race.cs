using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Race : IRace
    {
        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            Pilots = new List<IPilot>();
        }

        private string raceName;

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                raceName = value;
            }
        }

        private int numberOfLaps;

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                numberOfLaps = value;
            }
        }


        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots { get; private set; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {raceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {numberOfLaps}");

            if (TookPlace) sb.AppendLine($"Took place: Yes"); 
            else sb.AppendLine($"Took place: No"); 


            return sb.ToString().TrimEnd();
        }
    }
}
