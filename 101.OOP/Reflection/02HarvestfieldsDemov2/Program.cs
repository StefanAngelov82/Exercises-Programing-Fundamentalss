using HarvestFieldsDemo;
using System.Reflection;

namespace HarvestfieldsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FieldInfo[] fieldInfos = typeof(HarvestingFields).GetFields((BindingFlags)60);
            
            string? input = String.Empty;

            while ((input = Console.ReadLine()) != "HARVEST")    
            {
                FieldInfo[] filteredFields = (fieldInfos.Where(x => x.Attributes.ToString().ToLower() == input).ToArray());

                if (filteredFields.Length == 0)
                    filteredFields = fieldInfos;

                //switch (input)
                //{
                //    case "private":
                //        filteredFields = FilterFields(input, fieldInfos);
                //        break;

                //    case "protected":
                //        filteredFields = FilterFields(input, fieldInfos);
                //        break;

                //    case "public":
                //        filteredFields = FilterFields(input, fieldInfos);
                //        break;

                //    case "all":
                //        filteredFields = fieldInfos;
                //        break;
                //}

                foreach (FieldInfo field in filteredFields!)
                {
                    string modifier = (field.Attributes.ToString() == "Family") ? "protected" : field.Attributes.ToString();

                    Console.WriteLine($"{modifier.ToLower()} {field.FieldType.Name} {field.Name}");
                    //accessMod       field type                            field name
                }
            }
        }

        private static IEnumerable<FieldInfo>? FilterFields(string filter, FieldInfo[] fieldInfos)
        {
            if  (filter == "private")
                return fieldInfos.Where(f => f.IsPrivate);
            
            else if (filter == "protected")
                return fieldInfos.Where(f => f.IsFamily);

            else
                return fieldInfos.Where(f => f.IsPublic);
        }                   
        
    }
}
