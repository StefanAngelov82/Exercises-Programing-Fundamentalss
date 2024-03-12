using Raiding.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories.Interface
{
    public interface IHeroesFactory
    {
        IHero Creator(string type, string name);
    }
}
