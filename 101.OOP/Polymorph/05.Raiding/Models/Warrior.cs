using Raiding.GlobalConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) 
            : base(name)
        {
        }
        public override int Power => GlobalConstants.PowerPaladinOrWarrior;

        public override string CastAbility()
            => string.Format(GlobalConstants.CastRougeOrWarrior, GetType().Name, Name, Power);
    }
}
