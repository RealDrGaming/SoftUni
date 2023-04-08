using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;

            BatteryLevel = BatteryCapacity;

            interfaceStandards = new List<int>();
        }

        private string model;

        public string Model
        {
            get => model;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }

                model = value;
            }
        }


        private int batteryCapacity;

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }

                batteryCapacity = value; 
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        private List<int> interfaceStandards;

        public IReadOnlyCollection<int> InterfaceStandards{ get => interfaceStandards;}

        public void Eating(int minutes)
        {
            if (BatteryLevel + (ConvertionCapacityIndex * minutes) < batteryCapacity)
            {
                BatteryLevel += ConvertionCapacityIndex * minutes;
            }
            else
            {
                BatteryLevel = batteryCapacity;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            batteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            
            if (InterfaceStandards.Count == 0)
            {
                sb.AppendLine($"--Supplements installed: none");
            }
            else if (InterfaceStandards.Count > 0)
            {
                sb.AppendLine($"--Supplements installed: {string.Join(" ", InterfaceStandards)}");
            }

            return sb.ToString().Trim();
        }
    }
}
