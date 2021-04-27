using System;
using System.Text;

namespace Records
{
    public class RecordsSample
    {
        public static void Test()
        {
            Animal rabbit = new Animal("field", 4);
            rabbit.Habitat = String.Empty;
            // invalid - rabbit.LegsCount = 3;
            Console.WriteLine(rabbit.ToString());
            
            var rabbitWithFiveLegs = rabbit with {LegsCount = 5, Habitat = "Chernobyl"};
            Console.WriteLine(rabbitWithFiveLegs.ToString());

            var dog = new Pet("Dog", "Hose", 4);
            // invalid - dog.Name = "other dog";
            Console.WriteLine(dog);

            var cat = new Cat("cat");
            cat.Meow();
            Console.WriteLine(cat);
        }
        
        record Animal
        {
            public Animal(string habitat, int legsCount)
            {
                Habitat = habitat;
                LegsCount = legsCount;
            }
            
            public string Habitat { get; set; }
            public int LegsCount { get; init; }
        }

        record Pet(string Name, string Habitat, int Legs) : Animal(Habitat, Legs)
        {
            public void HowManyLegs() => Console.WriteLine($"I have {LegsCount} Legs");
        }

        sealed record Cat(string Name) : Pet(Name, "Home", 4)
        {
            public void Meow() => Console.WriteLine($"Meow Meow");

            public override string ToString()
            {
                var sb = new StringBuilder();
                base.PrintMembers(sb);
                return $"{sb} is a Cat";
            }
        }
    }
}