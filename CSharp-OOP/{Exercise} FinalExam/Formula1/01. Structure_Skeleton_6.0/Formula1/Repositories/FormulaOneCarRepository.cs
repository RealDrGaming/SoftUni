using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> cars = new List<IFormulaOneCar>();

        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get => cars.AsReadOnly();
        }

        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return cars.FirstOrDefault(c => c.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return cars.Remove(model);
        }
    }
}
