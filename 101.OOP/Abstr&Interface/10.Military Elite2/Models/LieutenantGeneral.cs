using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Military_Elite2.Models
{
    public class LieutenantGeneral : Private
    {
        private List<Private> _team;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            _team = new List<Private>();
        }

        public IReadOnlyCollection<Private> Team => _team.AsReadOnly();


        public void AddPrivate(Private @private)
            => _team.Add(@private);
        
        public void RemovePrivate(Private @private)
            => _team.Remove(@private);

        public override string ToString()
        {
            StringBuilder sb =new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine("Privates:");

            _team.ForEach(x =>sb.AppendLine(x.ToString()));

            return sb.ToString().Trim();
        }

    }
}
