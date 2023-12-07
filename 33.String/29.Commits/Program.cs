using System.Data;
using System.Text.RegularExpressions;

namespace Commits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            SortedDictionary<string, SortedDictionary<string, List<Commit>>> data = new SortedDictionary<string, SortedDictionary<string, List<Commit>>>();

            while ((input = Console.ReadLine()) != "git push")
            {
                string pattern = @"(?<=https:\/\/github\.com\/)(?<user>[A-Za-z-0-9]+)\/(?<repo>[A-ZA-z-_]+)\/commit\/(?<hash>[0-9a-f]{40}),(?<massage>[^\n]+?),(?<additions>[0-9]+),(?<deletions>[0-9]+)";

                foreach (Match match in Regex.Matches(input, pattern))
                {
                    string name = match.Groups["user"].Value;
                    string repo = match.Groups["repo"].Value;
                    string hash = match.Groups["hash"].Value;
                    string massage = match.Groups["massage"].Value;

                    int additions = int.Parse(match.Groups["additions"].Value);
                    int deletions = int.Parse(match.Groups["deletions"].Value);

                    Commit current = new Commit(hash, massage, additions, deletions);

                    if (!data.ContainsKey(name))
                    {
                        data[name] = new SortedDictionary<string, List<Commit>>();
                        data[name][repo] = new List<Commit> ();
                    }
                    else if (!data[name].ContainsKey(repo))
                    {
                        data[name][repo] = new List<Commit>();
                    }

                    data[name][repo].Add(current);
                }
            }

            foreach (var person in data)
            {
                Console.WriteLine($"{person.Key}:");
                
                foreach (var repo in person.Value)
                {
                    Console.WriteLine($"  {repo.Key}:");

                    foreach (var item in repo.Value)
                    {
                        Console.WriteLine($"    {item}");
                    }
                }

                int totalAdditionsCount = person.Value.Sum(x => x.Value.Sum(x => x.Additions));
                int totalDeletionsCount = person.Value.Sum(x => x.Value.Sum(x => x.Deletions));

                Console.WriteLine($"    Total: {totalAdditionsCount} additions, {totalDeletionsCount} deletions");
            }
        }
    }
    class Commit
    {
        public string Hash { get; set; }
        public string Message { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }

        public Commit(string hash, string message, int additions, int deletions)
        {
            this.Hash = hash;
            this.Message = message;
            this.Additions = additions;
            this.Deletions = deletions;
        }

        public override string ToString()
        {
            return $"commit {this.Hash}: {this.Message} ({this.Additions} addition, {this.Deletions} deletions)";
        }
    }
}