using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int totalPokemonvalue = 0;

            while (pokemons.Count > 0)
            {
                int indexOfPokemon = int.Parse(Console.ReadLine());

                int removedPokemonValue = PokemonRemove(pokemons, indexOfPokemon);

                totalPokemonvalue += removedPokemonValue;
            }

            Console.WriteLine(totalPokemonvalue);
        }
        static int PokemonRemove(List<int> pokemons, int indexOfPokemon)
        {
            int removedPokemonValue = 0;

            if (indexOfPokemon >= 0 && indexOfPokemon < pokemons.Count)
            {
                removedPokemonValue = pokemons[indexOfPokemon];
                pokemons.RemoveAt(indexOfPokemon);

                PokemonValueIncreaseDecrease(pokemons, removedPokemonValue);
            }
            else if (indexOfPokemon < 0)
            {
                removedPokemonValue = pokemons[0];
                pokemons.RemoveAt(0);
                pokemons.Insert(0, pokemons[pokemons.Count - 1]);

                PokemonValueIncreaseDecrease(pokemons, removedPokemonValue);
            }
            else if (indexOfPokemon >= pokemons.Count)
            {
                removedPokemonValue = pokemons[pokemons.Count - 1];
                pokemons.RemoveAt(pokemons.Count - 1);
                pokemons.Add (pokemons[0]);

                PokemonValueIncreaseDecrease(pokemons, removedPokemonValue);
            }

            return removedPokemonValue;
        }
        static void PokemonValueIncreaseDecrease(List<int> pokemons, int removedPokemonValue)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (pokemons[i] <= removedPokemonValue)
                {
                    pokemons[i] += removedPokemonValue;
                }
                else
                {
                    pokemons[i] -= removedPokemonValue;
                }
            }
        }
    }
}
