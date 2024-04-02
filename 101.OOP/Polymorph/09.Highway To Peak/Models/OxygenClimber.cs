using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        private const int INITIAL_STAMINA = 10;
        public OxygenClimber(string name) : base(name, INITIAL_STAMINA)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount;
        }
    }
}
