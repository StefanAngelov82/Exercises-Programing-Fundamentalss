using System.Threading.Channels;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Trainers> data = new List<Trainers>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inputArg = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inputArg[0];
                string pokemonName = inputArg[1];
                string pokemonElement = inputArg[2];
                int pokemonHealth = int.Parse(inputArg[3]);

                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainers currentTrainer = data.FirstOrDefault(x => x.Name == trainerName);

                if (currentTrainer != null)
                {
                    currentTrainer.Pokemons.Add(currentPokemon);
                }
                else
                {
                    currentTrainer = new Trainers(trainerName);
                    currentTrainer.Pokemons.Add(currentPokemon);
                    data.Add(currentTrainer);
                }               
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in data)
                {
                    if (trainer.Pokemons.Any(x => x.Element == input))
                    {
                        trainer.Badges += 1;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(x => x.Health -= 10);
                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            data.OrderByDescending(x => x.Badges).ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.Badges} {x.Pokemons.Count}"));            
        }
    }
}