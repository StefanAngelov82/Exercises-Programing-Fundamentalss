using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Interface;

namespace Wild_Farm.Factories.Interface
{
    public interface IFoodFactory
    {
        IFood Creator(params string[] foodData);

    }
}
