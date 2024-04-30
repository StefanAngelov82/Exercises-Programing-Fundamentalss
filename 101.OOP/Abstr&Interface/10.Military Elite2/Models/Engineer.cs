using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.Models
{
    public class Engineer : SpecialisedSoldier
    {
        private List<KeyValuePair<string, int>> _repair;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            _repair = new List<KeyValuePair<string, int>>();
        }

        public IReadOnlyCollection<KeyValuePair<string, int>> Repairs => _repair; 

        public void AddRepairs(string partName, int ours)
        {
            _repair.Add(new KeyValuePair<string, int>(partName, ours));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine("Repairs:");

            foreach (var kvp in _repair)           
                sb.AppendLine($"Part Name:{kvp.Key} Hours Worked: {kvp.Value}");

            return sb.ToString().Trim();
        }
    }
}
