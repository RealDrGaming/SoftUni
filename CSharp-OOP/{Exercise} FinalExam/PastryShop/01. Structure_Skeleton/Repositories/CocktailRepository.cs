using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        public CocktailRepository()
        {
            cocktails = new List<ICocktail>();
        }

        private List<ICocktail> cocktails;

        public IReadOnlyCollection<ICocktail> Models { get => cocktails.AsReadOnly(); }

        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}
