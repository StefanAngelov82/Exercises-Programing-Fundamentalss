using P02_BlackBoxInteger;
using System;
using System.Reflection;

namespace BlackBoxIntegerDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type? type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == nameof(BlackBoxInteger));

             BlackBoxInteger? instance =  GenerateInstance(type);

            MethodInfo[] methods = type!.GetMethods((BindingFlags)60);

            string? input = String.Empty;

            while((input = Console.ReadLine()) != "END")
            {
                string[] inputArg = input.Split("_");
                string MethodName = inputArg[0];
                int methodArgument = int.Parse(inputArg[1]);

                MethodInfo? method = methods.FirstOrDefault(m => m.Name == MethodName);

                method?.Invoke(instance, [methodArgument]);

                FieldInfo field = instance!.GetType().GetField("innerValue", (BindingFlags)60)!;

                var value = field.GetValue(instance);

                Console.WriteLine(value);
            }
            
        }

        static BlackBoxInteger? GenerateInstance(Type? type)
        {
            ConstructorInfo constructor = type!.GetConstructors((BindingFlags)60).First();
            ParameterInfo[] constructorInfo = constructor.GetParameters();

            var constructorParameters = new List<object>();

            foreach (var parameter in constructorInfo)
            {
                Console.WriteLine($"Enter parameter value {parameter.Name}");
                var parameterValue = int.Parse(Console.ReadLine()!);

                constructorParameters.Add(parameterValue);
            }

             return  Activator.CreateInstance(type!,
                                                (BindingFlags)60,
                                                null,
                                                constructorParameters.ToArray(),
                                                null,
                                                null)! as BlackBoxInteger;
        }
    }
}
