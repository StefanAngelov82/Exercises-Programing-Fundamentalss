using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Utilities
{
    public static class Validator
    {       

        public static void ValidateValue(int values, string target)
        {
            if (values < 0 || values > 100 )
            {
                throw new ArgumentOutOfRangeException(string.Format(
                        ExceptionMessages.WrongStatsValues, target));
            }
        }

    }
}
