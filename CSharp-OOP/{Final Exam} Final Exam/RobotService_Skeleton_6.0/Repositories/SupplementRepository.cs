using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }

        private readonly List<ISupplement> supplements;

        public IReadOnlyCollection<ISupplement> Models()
        {
            return supplements.AsReadOnly();
        }

        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }
        public bool RemoveByName(string typeName)
        {
            ISupplement supplement = supplements.FirstOrDefault(s => s.GetType().Name == typeName);

            if (supplement != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
        }
    }
}
