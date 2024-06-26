﻿using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players = new List<IPlayer>();

        public IReadOnlyCollection<IPlayer> Models => players.AsReadOnly();

        public void AddModel(IPlayer model)
        {
            players.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return players.Any(x => x.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            return players.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(string name)
        {
            IPlayer player = players.FirstOrDefault(x => x.Name == name);
            if (player == null)
            {
                return false;
            }
            return players.Remove(player);
        }
    }
}
