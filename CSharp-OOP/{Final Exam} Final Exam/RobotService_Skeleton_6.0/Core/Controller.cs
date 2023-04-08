using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements = new SupplementRepository();
        private RobotRepository robots = new RobotRepository();

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            if (typeName == nameof(DomesticAssistant))
            {
                DomesticAssistant robotDA = new DomesticAssistant(model);
                robots.AddNew(robotDA);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                IndustrialAssistant robotIA = new IndustrialAssistant(model);
                robots.AddNew(robotIA);
            }

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            if (typeName == nameof(SpecializedArm))
            {
                SpecializedArm supplementSA = new SpecializedArm();
                supplements.AddNew(supplementSA);
            }
            else if (typeName == nameof(LaserRadar))
            {
                LaserRadar supplementLR = new LaserRadar();
                supplements.AddNew(supplementLR);
            }

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }
        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supp = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            int interfaceValue = supp.InterfaceStandard;

            List<IRobot> rob = robots.Models().Where(r => r.InterfaceStandards.All(r1 => r1 != interfaceValue)).Where(r2 => r2.Model == model).ToList();

            if (rob.Count <= 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            rob.FirstOrDefault().InstallSupplement(supp);

            supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> rob = robots.Models().Where(r => r.InterfaceStandards.Any(r1 => r1 == intefaceStandard)).ToList();

            if (rob.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            rob = rob.OrderByDescending(r => r.BatteryLevel).ToList();

            int availablePower = 0;

            foreach (var item in rob)
            {
                availablePower += item.BatteryLevel;
            }

            if (availablePower < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - availablePower);
            }

            int robotTakingPartCounter = 0;

            foreach (var robot in rob)
            {
                if (robot.BatteryLevel < totalPowerNeeded)
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    robotTakingPartCounter++;
                }
                else
                {
                    robot.ExecuteService(totalPowerNeeded);
                    robotTakingPartCounter++;
                    break;
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotTakingPartCounter);
        }
        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> rob = robots.Models().Where(r => r.BatteryLevel < 0.5 * r.BatteryCapacity).Where(r => r.Model == model).ToList();

            foreach (var robo in rob)
            {
                robo.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, rob.Count);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            List<IRobot> rob = robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity).ToList();

            foreach (var robot in rob)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
