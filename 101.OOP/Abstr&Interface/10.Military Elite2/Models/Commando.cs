using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Military_Elite2.Models
{
    public class Commando : SpecialisedSoldier
    {
        private Dictionary<string, string> _missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            _missions = new Dictionary<string, string>();
        }

        public IReadOnlyDictionary<string, string> Missions => _missions;

        public void AddMission(string missionName, string status)
        {
            if (status != "inProgress" && status != "Finished")
                throw new ArgumentException();

            if (!_missions.ContainsKey(missionName)) 
            _missions[missionName] = status;

            else
                throw new ArgumentException();       
           
        }
        public void CompleteMission(string missionName)
        {
            if (_missions.ContainsKey(missionName))
                _missions[missionName] = "Finished";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine("Missions:");

            foreach (var mission in _missions)
            {
                sb.AppendLine($"Code Name: {mission.Key} State: {mission.Value}");
            }

            return sb.ToString().Trim(); 
        }


    }
}
