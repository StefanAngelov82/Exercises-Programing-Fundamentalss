using Football_Team_Generator.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.Core
{
    public class Engine : IEngine
    {
        private IController _controller;

        public Engine()
        {
            _controller = new Controller();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
