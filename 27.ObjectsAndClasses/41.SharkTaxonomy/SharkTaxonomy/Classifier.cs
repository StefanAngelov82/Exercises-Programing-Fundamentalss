using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount 
        {
            get => Species.Count;
        }

        public void AddShark(Shark shark)
        {
            if (Species.Count < Capacity && !Species.Any(x => x.Kind == shark.Kind))            
                Species.Add(shark);            
        }

        public bool RemoveShark(string kind)
        {
            Shark? target = Species.FirstOrDefault(x => x.Kind == kind);

            if (target == null)
                return false;

            Species.Remove(target);
            return true;
        }

        public string GetLargestShark()
        {
            return Species.OrderByDescending(x => x.Length).First().ToString();
        }

        public double GetAverageLength()
        {
            return Species.Average(x => x.Length);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Species.Count} sharks classified:");

            foreach (var item in Species)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
