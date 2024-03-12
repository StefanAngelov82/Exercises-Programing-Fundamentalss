using Raiding.GlobalConst;
using Raiding.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) 
            : base(name)
        {
        }

        public override int Power => GlobalConstants.PowerPaladinOrWarrior;
        public override string CastAbility()        
           =>  string.Format(GlobalConstants.CastDruidOrPaladin, GetType().Name, Name, Power);
       
    }
}
