using Raiding.GlobalConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name)
            : base(name)
        {
        }

        public override int Power => GlobalConstants.PowerDruidOrRouge;

        public override string CastAbility()       
             => string.Format(GlobalConstants.CastDruidOrPaladin, GetType().Name, Name, Power);
        
    }
}
