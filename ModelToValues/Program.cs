using ModelToValues.Helpers;
using System;
using System.Text.Json;

namespace ModelToValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Extracting Test1");

            var test1 = new Test1
            {
                First1 = "My first one",
                First2 = "My first two",
                First3 = false,
                FirstSecond = new Test2
                {
                    Second1 = "My second one",
                    Second3 = true
                }
            };

            // Convert to name/value pairs
            var props = Model.GetProperties(test1);
            foreach (var prop in props)
            {
                Console.WriteLine($"Property: {prop.Key} Value: {prop.Value}");
            }

            // Convert back to a model
            Test1 model = (Test1)Model.SetProperties(props);

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true
            };

            Console.WriteLine(JsonSerializer.Serialize(model, jsonOptions));
        }
    }
}
