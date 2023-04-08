using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        public RobotRepository()
        {
            robots = new List<IRobot>();
        }

        private readonly List<IRobot> robots;

        public IReadOnlyCollection<IRobot> Models()
        {
            return robots.AsReadOnly();
        }

        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            IRobot robot = robots.FirstOrDefault(r => r.Model == typeName);

            if (robot != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return robots.FirstOrDefault(r => r.InterfaceStandards.Any(ri => ri == interfaceStandard));
        }
    }
}
