using Raiding.GlobalConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : base(name)
        {
        }

        public override int Power => GlobalConstants.PowerDruidOrRouge;

        public override string CastAbility()
            => string.Format(GlobalConstants.CastRougeOrWarrior, GetType().Name, Name, Power);
    }
}
