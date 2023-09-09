using System;
using System.Collections.Generic;
using System.Linq;

namespace Social_Media_Posts
{
    internal class Program
    {
        static Dictionary<string, int> commentsLikes = new Dictionary<string, int>();
        static Dictionary<string, int> commentsDislikes = new Dictionary<string, int>();
        static Dictionary<string, Dictionary<string, string>> PostComents = new Dictionary<string, Dictionary<string, string>>();

        static void Main(string[] args)
        {           

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "drop the media")
            {
                switch (InputREcagnition(input, 0))
                {
                    case "post":
                        {
                            CreatePost(input);
                            break;
                        }                  
                    case "like":
                        {
                            AddLikes(input);
                            break;
                        }
                    case "dislike":
                        {
                            AddDisllikes(input);
                            break;
                        }
                    case "comment":
                        {
                            AddComents(input);
                            break;
                        }
                }                
            }

            foreach (var post in commentsLikes.Keys)
            {
                Console.Write($"Post: {post} | Likes: {commentsLikes[post]} | ");               
                Console.Write($"Dislikes: {commentsDislikes[post]}");
                Console.WriteLine();
                Console.WriteLine("Comments:");

                if (PostComents[post].Count == 0)
                {
                    Console.WriteLine("None");
                }
                foreach (var kvp in PostComents[post])
                {
                    Console.WriteLine($"*  {kvp.Key}: {kvp.Value}");
                }

            }
        }

        private static void AddComents(string input)
        {
            string postName = InputREcagnition(input, 1);
            string comentatorname = InputREcagnition(input, 2);
            string coments = InputREcagnition(input, 3);

            PostComents[postName][comentatorname] = coments;
        }

        static void AddDisllikes(string input)
        {
            string postName = InputREcagnition(input, 1);

            commentsDislikes[postName]++;
        }

        static void AddLikes(string input)
        {
            string postName = InputREcagnition(input, 1);

            commentsLikes[postName]++;
        }

        static void CreatePost(string input)
        {
            string postName = InputREcagnition(input, 1);

            commentsLikes.Add(postName, 0);
            commentsDislikes.Add(postName, 0);
            PostComents[postName] = new Dictionary<string, string>();
        }

        static string InputREcagnition(string input, int Arg)
        {
            string[] inputArg = input.Split().ToArray();           

            if      (Arg == 0)  return inputArg[0];
            else if (Arg == 1)  return inputArg[1];
            else if (Arg == 2)  return inputArg[2];
            else
            {
                string postContend = string.Join(" ", inputArg.Skip(3));
                return postContend;
            }

        } 
    }
}
