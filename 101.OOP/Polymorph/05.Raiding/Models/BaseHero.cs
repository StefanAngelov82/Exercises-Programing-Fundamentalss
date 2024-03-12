using Raiding.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name)
        {
            Name = name;            
        }

        public string Name { get; private set; }

        public virtual int Power { get; private set; }

        public abstract string CastAbility();
        
    }
}
