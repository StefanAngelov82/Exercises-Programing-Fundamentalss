using Raiding.Core.Interface;
using Raiding.Factories.Interface;
using Raiding.IO.Interface;
using Raiding.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        public readonly IReader reader;
        public readonly IWriter writer;
        public readonly IHeroesFactory heroesFactory;

        public readonly ICollection<IHero> heroesParty;

        public Engine(IReader reader, IWriter writer, IHeroesFactory heroesFactory)
        {
            this.reader = reader;
            this.writer = writer;
            heroesParty = new List<IHero>();
            this.heroesFactory = heroesFactory;

        }

        public void Run()
        {
            AssemblyParty();
            Battle();

        }

        private void Battle()
        {
            int bossPower = int.Parse(reader.ReadLine());
            int partyPower = heroesParty.Sum(x => x.Power);

            foreach (var hero in heroesParty)
                writer.WriteLine(hero.CastAbility());


            if (bossPower <= partyPower)
                writer.WriteLine("Victory!");

            else
                writer.WriteLine("Defeat...");
        }

        private void AssemblyParty()
        {
            int partyNumber = int.Parse(reader.ReadLine());
            int counter = 0;

            while (counter < partyNumber)
            {
                try
                {
                    heroesParty.Add(CreateHero());
                    counter++;
                }
                catch (Exception ex)
                {                    
                    writer.WriteLine(ex.Message.ToString());
                }                
            }
        }

        private IHero CreateHero()
        {
            string name = reader.ReadLine();
            string type = reader.ReadLine();

            return heroesFactory.Creator(type, name);
        }
    }
}
