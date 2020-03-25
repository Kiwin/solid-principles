/// <author> Kiwin Bendtsen Andersen </author>

/// <summary>
/// This namespace contains a bad example of the open/closed principle.
/// </summary>
namespace OpenClosedPrinciple.BadExample
{

    public enum AnimalType
    {
        DOG, CAT, FROG
    }

    public class AnimalSoundFetcher
    {
        public string FetchAnimalSound(AnimalType animal)
        {
            switch (animal)
            {
                case AnimalType.DOG:
                    return "woof";
                case AnimalType.CAT:
                    return "nyaa";
                case AnimalType.FROG:
                    return "REEE";
                default:
                    return "I don´t know what the animal says";
            }
        }
    }

}

/// <summary>
/// This namespace contains a good example of the open/closed principle.
/// </summary>
namespace OpenClosedPrinciple.GoodExample
{

    public enum AnimalType
    {
        DOG, CAT, FROG
    }

    public abstract class Animal
    {
        public readonly AnimalType Type { get; }
        public readonly string Sound { get; }

        public Animal(AnimalType type, string sound)
        {
            this.Type = type;
            this.Sound = sound;
        }
    }

    public class Dog : Animal
    {
        public Dog() : base(AnimalType.DOG, "woof") { }
    }

    public class Cat : Animal
    {
        public Cat() : base(AnimalType.CAT, "nyaa") { }
    }

    public class Frog : Animal
    {
        public Frog() : base(AnimalType.FROG, "REEE") { }
    }

    public class AnimalSoundFetcher
    {
        public string FetchAnimalSound(Animal animal)
        {
            return animal.Sound;
        }
    }
}
